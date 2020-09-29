using System.Net.Http;
using System.Net.Http.Headers;


namespace KocFinans.Public.Helpers
{
    public static class HttpRequestBuilder
    {
        public static HttpRequestMessage BuildRequest(HttpMethod method, string uri)
        {
            var request = new HttpRequestMessage(method, uri);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-protobuf"));
            return request;
        }

        public static HttpRequestMessage BuildRequest(ByteArrayContent content, string uri)
        {

            content.Headers.ContentType = new MediaTypeHeaderValue("application/x-protobuf");
            var request = new HttpRequestMessage(HttpMethod.Post, uri)
            {
                Content = content
            };

            return request;
        }
    }
}
