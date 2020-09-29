using KocFinans.Public.IO;
using KocFinans.Public.MicroServices.Credits;
using KocFinans.Public.MicroServices.CreditScore;
using KocFinans.Public.Models;

namespace KocFinans.Gateway.Service
{
    public  class CreditUsageService
    {
        private readonly ICreditScoreMicroservice _creditScoreService;
        private readonly ICreditsMicroService _creditsService;
        private readonly MessagingService _messagingService;
        private const int CreditMultiplier = 4;
        public CreditUsageService(ICreditScoreMicroservice creditScoreMicroService,
            ICreditsMicroService creditsMicroService,
            MessagingService messagingService)
        {
            _creditsService = creditsMicroService;
            _creditScoreService = creditScoreMicroService;
            _messagingService = messagingService;
        }


        public UseCreditResponse UseCredit(UseCreditRequest request)
        {

            var creditScore = GetUserCreditScore(request.IdentityNo);
            var creditAmount = CalculateCreditAmount(creditScore,request.Salary);
            var response = BuildResponseFromCreditAmount(request,creditAmount);
            return response;    
        }
        private UserCreditScore GetUserCreditScore(int identityNo)
        {
            var result = _creditScoreService
                .GetCreditScoreByIdentityId(identityNo).Result;
            return result;
        }
        private double CalculateCreditAmount(UserCreditScore score,double salary)
        {
            if (score == null)
                return 0;
            var creditScore = score.CreditScore;
            if (creditScore < 500)
                return 0;
            if (creditScore < 1000 )
            {
                if(salary < 5000)
                {
                    return 10000;
                }
                else
                {
                    //Eksik case
                    return salary * CreditMultiplier / 2;
                }
            }
            return salary * CreditMultiplier;
        }
        private UseCreditResponse BuildResponseFromCreditAmount(UseCreditRequest request, double creditAmount)
        {
            var response = new UseCreditResponse() { Amount = creditAmount, Success = false };
            if (response.Amount == 0)
                return response;
           
            var credit = new Credit()
            {
                CreditAmount = creditAmount,
                Name = request.Name,
                Surname = request.SurName,
                IdentityNo = request.IdentityNo,
                PhoneNumber = request.PhoneNumber
            };
            var dbCredit = _creditsService.InsertCreditResult(credit).Result;
            response.ApplicationId = dbCredit.Id;
            response.Success = true;
            SendMessage(dbCredit);
            return response;
            
        }
        private void SendMessage(Credit credit)
        {
            _messagingService.QueueMessage(credit);
        }
    }
}
