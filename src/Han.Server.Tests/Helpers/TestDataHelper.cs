using System.Collections.Generic;
using System.Threading.Tasks;
using Han.Server.Data.Repositories;

namespace Han.Server.Tests.Helpers
{
    public class TestDataHelper
    {
        private readonly TestHost testHost;

        public TestDataHelper(TestHost testHost)
        {
            this.testHost = testHost;
        }

        public async Task<bool> DoesRecordExist<T>(ulong id) where T : class
        {
            var record = await RepositoryHelper.GetByIdAsync<T>(id);

            return record != null;
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
