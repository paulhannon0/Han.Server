using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Han.Server.Tests.Endpoints.Widgets.CreateWidget
{
    [Binding]
    public class CreateWidgetSteps
    {
        private readonly TestHost testHost;

        public CreateWidgetSteps(TestHost testHost)
        {
            this.testHost = testHost;
            this.testHost.EndpointPath = "/widgets";
        }

        [Given("a valid request body for the \'Create Widget\' endpoint")]
        public void GivenAValidRequestBodyForTheCreateWidgetEndpoint()
        {
            this.testHost.RequestBody.Add("Name", CreateWidgetFixtures.ValidName);
        }

        [Given("a request body for the \'Create Widget\' endpoint containing an invalid (.*) parameter")]
        public void GivenARequestBodyForTheCreateWidgetEndpointContainingAnInvalidParameter(string field)
        {
            switch (field)
            {
                case "Name":
                    this.testHost.RequestBody.Add("Name", CreateWidgetFixtures.InvalidName);
                    break;

                default:
                    break;
            }
        }

        [When("the request is made")]
        public async Task WhenTheRequestIsMade()
        {
            await this.testHost.PostAsync();
        }
    }
}
