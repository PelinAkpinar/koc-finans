using KocFinans.Public.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace KocFinans.Data.CreditScore
{
    public interface ICreditScoreRepository
    {
        Task<UserCreditScore> GetCreditScoreAsync(int identityNo);
        
        Task<List<UserCreditScore>> GetAllCreditScores();
    }
}
