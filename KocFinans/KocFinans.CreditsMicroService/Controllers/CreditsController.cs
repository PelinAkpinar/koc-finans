using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KocFinans.CreditsMicroService.Service;
using KocFinans.Data.Credits;
using KocFinans.Public.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KocFinans.CreditsMicroService.Controllers
{
    public class CreditsController : ControllerBase
    {
        private readonly ICreditsRepository _creditsRepository;
        public CreditsController(ICreditsRepository creditsRepository)
        {
            _creditsRepository = creditsRepository;
        }
        [HttpGet]
        [Route("api/healthCheck")]
        public  string GetHealth()
        {
            return "Health : OK";
        }
        [HttpGet]
        [Route("api/getCreditByApplicationId/{id}")]
        [Produces("application/x-protobuf")]
        public async Task<Credit> GetCreditScoreAsync([FromRoute] string id)
        {
            var service = new CreditsService(_creditsRepository);
            return await service.GetCreditById(id);
        }
        [HttpGet]
        [Route("api/getCreditsByIdentityId/{id}")]
        [Produces("application/x-protobuf")]
        public async Task<IList<Credit>> GetCreditScoreAsync([FromRoute] int id)
        {
            var service = new CreditsService(_creditsRepository);
            return await service.GetCreditsByIdendityNo(id);
        }
        [HttpPost]
        [Route("api/insertCreditResult")]
        [Produces("application/x-protobuf")]
        public async Task<Credit> InsertCreditResult([FromBody] Credit credit)
        {
            var service = new CreditsService(_creditsRepository);
            return await service.InsertCreditResult(credit);
        }
    }
}
