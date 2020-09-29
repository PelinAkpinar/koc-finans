using KocFinans.Data.CreditScore;
using KocFinans.Public.MicroServices.CreditScore;
using KocFinans.Public.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kocfinans.CreditScoreMicroService.Service
{
    public class CreditScoreService : ICreditScoreMicroservice
    {
        private readonly ICreditScoreRepository _creditScoreRepository;
        public CreditScoreService(ICreditScoreRepository creditScoreRepository)
        {
            _creditScoreRepository = creditScoreRepository;
        }
        public async Task<UserCreditScore> GetCreditScoreByIdentityId(int identityNo)
        {

          
            return (await _creditScoreRepository.GetCreditScoreAsync(identityNo));
        }
    }
}
