using Kocfinans.CreditScoreMicroService.Service;
using KocFinans.Data.CreditScore;
using KocFinans.Public.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kocfinans.CreditScoreMicroService.Controllers
{
    public class CreditScoreController : ControllerBase
    {
        private readonly ICreditScoreRepository _creditScoreRepository;
        public CreditScoreController(ICreditScoreRepository creditScoreRepository)
        {
            _creditScoreRepository = creditScoreRepository;
        }
        [HttpGet]
        [Route("api/healthCheck")]
        public string GetHealth()
        {
            return "Health : OK";
        }
        [HttpGet]
        [Route("api/getScoreByIdentityNo/{id}")]
        [Produces("application/x-protobuf")]
        public async Task<UserCreditScore> GetCreditScoreAsync([FromRoute] int id)
        {
            var service = new CreditScoreService(_creditScoreRepository);
            return await service.GetCreditScoreByIdentityId(id);
        }
    }
}
