using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Han.Server.Tests.Common.Steps
{
    [Binding]
    public class RequestSteps
    {
        private readonly TestHost testHost;

        public RequestSteps(TestHost testHost)
        {
            this.testHost = testHost;
        }

        [When("the (.*) request is made")]
        public async Task WhenTheRequestIsMade(string method)
        {
            switch (method)
            {
                case "GET":
                    await this.testHost.GetAsync();
                    break;

                case "POST":
                    await this.testHost.PostAsync();
                    break;

                default:
                    break;
            }
        }
    }
}