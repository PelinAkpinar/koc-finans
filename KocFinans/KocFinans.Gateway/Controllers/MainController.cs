using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using KocFinans.Gateway.Service;
using KocFinans.Public.IO;
using KocFinans.Public.MicroServices.Credits;
using KocFinans.Public.MicroServices.CreditScore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;

namespace KocFinans.Gateway.Controllers
{
    public class MainController : ControllerBase
    {
        private readonly ICreditScoreMicroservice _creditScoreMicroService;
        private readonly ICreditsMicroService _creditsMicroService;
        private readonly MessagingService _messagingService;
        public MainController(ICreditScoreMicroservice creditScoreMicroService
            , ICreditsMicroService creditsMicroService, ConnectionFactory connectionFactory)
        {
            _creditScoreMicroService = creditScoreMicroService;
            _creditsMicroService = creditsMicroService;
            _messagingService = new MessagingService(connectionFactory);
        }
        [HttpPost]
        [Route("api/useCredit")]
        //[Produces("application/x-protobuf")]
        public async Task<JsonResult> UseCredit
            ( UseCreditRequest request)
        {
            if (TryValidateModel(request))
            {
                var service = new CreditUsageService(_creditScoreMicroService, _creditsMicroService, _messagingService);
                var creditResult = service.UseCredit(request);
                return new JsonResult(creditResult);
            }
            var creditResultWithError = new UseCreditResponse();
            creditResultWithError.ErrorMessage = "Zorunlu alanlari doldurmalisiniz!";
            return new JsonResult(creditResultWithError);

        }

        private bool ValidateRequest(UseCreditRequest request)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("api/getCreditScore/{id}")]
        public async Task<JsonResult> GetCreditScore([FromRoute] int id)
        {
            var result = await _creditScoreMicroService
                .GetCreditScoreByIdentityId(id);

            //_messagingService.QueueMessage(credit);
            //_messagingService.QueueMessage();
            //var serializer = JsonSerializer.Serialize(result);
            return new JsonResult(result);
            //return new JsonRe
            //{
            //    s
            //}

        }
    }
}
