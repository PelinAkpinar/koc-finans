using KocFinans.Public.Helpers;
using KocFinans.Public.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace KocFinans.Public.MicroServices.Credits
{
    public class CreditsMicroService : ICreditsMicroService
    {
        private const string BaseUri = "http://localhost:61004/";
        private const string GetCreditsByIdentityNoUri = "api/getCreditsByIdentityId";
        private const string GetCreditByApplicationIdUri = "api/getCreditByApplicationId";
        private const string InsertCreditResultUri = "api/insertCreditResult";

        private readonly HttpClient _client;
        public CreditsMicroService()
        {
            _client = new HttpClient();
        }


        public async Task<Credit> GetCreditById(string applicationId)
        {
            var request = HttpRequestBuilder.BuildRequest(HttpMethod.Get, BaseUri
                                                                   + GetCreditByApplicationIdUri + "/" +
                                                                   applicationId);
            var result = await _client.SendAsync(request);
            var credit = ProtoBuf.Serializer.Deserialize<Credit>
                (await result.Content.ReadAsStreamAsync());
            return credit;
        }

        public async Task<List<Credit>> GetCreditsByIdendityNo(int identityNo)
        {
            var request = HttpRequestBuilder.BuildRequest(HttpMethod.Get, BaseUri
                                                                   + GetCreditsByIdentityNoUri + "/" +
                                                                   identityNo);
            var result = await _client.SendAsync(request);
            var credits = ProtoBuf.Serializer.Deserialize<List<Credit>>
                (await result.Content.ReadAsStreamAsync());
            return credits;
        }

        public async Task<Credit> InsertCreditResult(Credit input)
        {
            MemoryStream stream = new MemoryStream();
            ProtoBuf.Serializer.Serialize(stream, new Credit
            {
                IdentityNo = input.IdentityNo,
                Name = input.Name,
                Surname = input.Surname,
                CreditAmount = input.CreditAmount,
                PhoneNumber = input.PhoneNumber
            });
            var data = stream.ToArray();
            var content = new ByteArrayContent(data, 0, data.Length);
            var request = HttpRequestBuilder.BuildRequest(content, BaseUri + InsertCreditResultUri);
            var result = await _client.SendAsync(request);
            var credit = ProtoBuf.Serializer.Deserialize<Credit>(await result.Content.ReadAsStreamAsync());
            return credit;
        }
    }
}
