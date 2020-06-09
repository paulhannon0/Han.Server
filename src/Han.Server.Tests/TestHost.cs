using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Han.Server.Api;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Han.Server.Tests
{
    public class TestHost
    {
        public IDictionary<string, object> RequestBody { get; set; }

        public string EndpointPath { get; set; }

        public HttpResponseMessage LastResponseMessage { get; set; }

        public string LocationResponseHeader { get; set; }

        private readonly HttpClient client;

        public TestHost()
        {
            this.RequestBody = new Dictionary<string, object>();

            this.client = new WebApplicationFactory<Startup>().CreateClient();
        }

        public async Task<HttpResponseMessage> PostAsync()
        {
            var bodyContent = new StringContent(JsonSerializer.Serialize(this.RequestBody), Encoding.UTF8, "application/json");
            var response = await this.client.PostAsync(this.EndpointPath, bodyContent);

            this.LastResponseMessage = response;

            return response;
        }

        public async Task<HttpResponseMessage> GetAsync()
        {
            var response = await this.client.GetAsync(this.EndpointPath);

            this.LastResponseMessage = response;

            return response;
        }
    }
}
