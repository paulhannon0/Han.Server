using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Han.Server.Api.Models.Widgets;

namespace Han.Server.Tests.Helpers
{
    public class TestDataHelper
    {
        private readonly TestHost testHost;

        public TestDataHelper(TestHost testHost)
        {
            this.testHost = testHost;
        }

        public async Task<ulong> CreateWidgetAsync(string name)
        {
            var responseMessage = await this.testHost.PostAsync
            (
                "/widgets",
                new Dictionary<string, object>()
                {
                    { "Name", name }
                }
            );

            return ulong.Parse(await responseMessage.Content.ReadAsStringAsync());
        }
    }
}
