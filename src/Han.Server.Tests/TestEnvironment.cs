using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Han.Server.Tests
{
    public static class TestEnvironment
    {
        private static HttpClient httpClient;

        public static readonly string ServiceBaseAddress = "http://192.168.99.100:8080";

        public static HttpClient GetHttpClient()
        {
            if (httpClient == null)
            {
                httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri(TestEnvironment.ServiceBaseAddress);
            }

            return httpClient;
        }
    }
}
