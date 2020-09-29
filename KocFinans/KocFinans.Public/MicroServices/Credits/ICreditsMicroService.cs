using KocFinans.Public.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KocFinans.Public.MicroServices.Credits
{
    public interface ICreditsMicroService
    {
        Task<Credit> InsertCreditResult(Credit credit);
        Task<List<Credit>> GetCreditsByIdendityNo(int identityNo);
        Task<Credit> GetCreditById(string applicationId);
    }
}
