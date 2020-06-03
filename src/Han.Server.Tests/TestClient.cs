using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Han.Server.Tests
{
    public static class TestClient
    {
        public static HttpResponseMessage LastResponseMessage { get; set; }

        public static async Task<HttpResponseMessage> PostAsync(string path, object body)
        {
            var bodyContent = new StringContent(body.ToString(), Encoding.UTF8, "application/json");
            var response = await TestEnvironment.GetHttpClient().PostAsync(path, bodyContent);
            LastResponseMessage = response;

            return response;
        }

        public static async Task<HttpResponseMessage> GetAsync(string path)
        {
            var response = await TestEnvironment.GetHttpClient().GetAsync(path);
            LastResponseMessage = response;

            return response;
        }
    }
}
