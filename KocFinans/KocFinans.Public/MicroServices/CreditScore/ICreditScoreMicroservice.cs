using KocFinans.Public.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KocFinans.Public.MicroServices.CreditScore
{
    public interface ICreditScoreMicroservice
    {
        Task<UserCreditScore> GetCreditScoreByIdentityId(int identityNo);
    }
}
