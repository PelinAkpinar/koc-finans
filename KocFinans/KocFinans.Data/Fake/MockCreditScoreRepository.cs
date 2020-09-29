using KocFinans.Data.CreditScore;
using KocFinans.Public.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KocFinans.Data.Fake
{
    public class MockCreditScoreRepository : ICreditScoreRepository
    {
        private List<UserCreditScore> _userCreditScores;
        public MockCreditScoreRepository()
        {
            _userCreditScores = new List<UserCreditScore>()
            {
              new UserCreditScore()
              {
                  Id = "1",
                  IdentityNo = 4,
                  CreditScore = 1432
              },
              new UserCreditScore()
              {

                  Id = "3",
                  IdentityNo = 1,
                  CreditScore = 32
              }
            };
        }

        public UserCreditScore GetCreditScoreAsync(int identityNo)
        {
            var score = _userCreditScores.FirstOrDefault(x => x.IdentityNo == identityNo);
            return score;
        }


        public IList<UserCreditScore> GetAllCreditScores()
        {
            throw new NotImplementedException();
        }

        public UserCreditScore GetCreditScore(int identityNo)
        {
            throw new NotImplementedException();
        }

        Task<UserCreditScore> ICreditScoreRepository.GetCreditScoreAsync(int identityNo)
        {
            throw new NotImplementedException();
        }

        Task<List<UserCreditScore>> ICreditScoreRepository.GetAllCreditScores()
        {
            throw new NotImplementedException();
        }



        //UserCreditScore ICreditScoreRepository.GetCreditScoreAsync(int identityNo)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
