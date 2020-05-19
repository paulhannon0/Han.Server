using System.Net.Http;
using System.Threading.Tasks;

namespace Han.Server.Tests
{
    public class TestClient : ITestClient
    {
        private readonly HttpClient httpClient;

        public TestClient()
        {
            this.httpClient = new HttpClient();
        }

        public async Task<HttpResponseMessage> PostAsync(string path, object body)
        {
            var bodyContent = new StringContent(body.ToString());
            return await this.httpClient.PostAsync(path, bodyContent);
        }

        public async Task<HttpResponseMessage> GetAsync(string path)
        {
            return await this.httpClient.GetAsync(path);
        }
    }
}
