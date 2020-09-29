using KocFinans.Data.Credits;
using KocFinans.Public.MicroServices.Credits;
using KocFinans.Public.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KocFinans.CreditsMicroService.Service
{
    public class CreditsService : ICreditsMicroService
    {
        private readonly ICreditsRepository _creditsRepository;
        public CreditsService(ICreditsRepository creditsRepository)
        {
            _creditsRepository = creditsRepository;
        }
        public  Task<Credit> GetCreditById(string applicationId)
        {
            return _creditsRepository.GetCreditById(applicationId);
        }

        public  Task<List<Credit>> GetCreditsByIdendityNo(int identityNo)
        {
            return _creditsRepository.GetCreditsByIdendityNo(identityNo);
        }

        public  Task<Credit> InsertCreditResult(Credit credit)
        {
            return _creditsRepository.InsertCreditResult(credit);
        }
    }
}
