
using System.Net.Http;

using System.Threading.Tasks;
using KocFinans.Public.Models;
using KocFinans.Public.Helpers;

namespace KocFinans.Public.MicroServices.CreditScore
{
    public class CreditScoreMicroService : ICreditScoreMicroservice
    {
        private const string BaseUri = "http://localhost:51004/api";
        private const string GetCreditScoreByIdentityNoUri = "/getScoreByIdentityNo";

        private readonly HttpClient _client;
        public CreditScoreMicroService()
        {
            _client = new HttpClient();
        }

        public async Task<UserCreditScore> GetCreditScoreByIdentityId(int identityNo)
        {
            var request = HttpRequestBuilder.BuildRequest(HttpMethod.Get, BaseUri
                                                                        + GetCreditScoreByIdentityNoUri + "/" + identityNo);
            var result = await _client.SendAsync(request);
            var score = ProtoBuf.Serializer.Deserialize<UserCreditScore>
                (await result.Content.ReadAsStreamAsync());
            return score;
        }
    }
}
