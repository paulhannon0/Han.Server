using System.Threading.Tasks;
using Han.Server.Tests.Helpers;
using TechTalk.SpecFlow;

namespace Han.Server.Tests.Endpoints.Widgets.GetWidget
{
    [Binding]
    public class GetWidgetSteps
    {
        private readonly TestHost testHost;
        private readonly TestDataHelper testDataHelper;
        private ulong validId;
        private string invalidId = "invalid_id";
        private ulong nonExistentId = 0;

        public GetWidgetSteps(TestHost testHost, TestDataHelper testDataHelper)
        {
            this.testHost = testHost;
            this.testDataHelper = testDataHelper;
        }

        [BeforeScenario]
        public async Task BeforeScenario()
        {
            this.validId = await this.testDataHelper.CreateWidgetAsync("WidgetName");
        }

        [Given("a valid request path for the \'Get Widget\' endpoint")]
        public void GivenAValidRequestPathForTheGetWidgetEndpoint()
        {
            this.SetEndpointPath(this.validId);
        }

        [Given("a request path for the \'Get Widget\' endpoint with an invalid (.*) parameter")]
        public void GivenARequestPathForTheGetWidgetEndpointWithAnInvalidParameter(string field)
        {
            this.SetEndpointPath(this.invalidId);
        }

        [Given("a request path for the \'Get Widget\' endpoint with an ID for a non-existent resource")]
        public void GivenARequestPathForTheGetWidgetEndpointWithAnIdForANonExistentResource()
        {
            this.SetEndpointPath(this.nonExistentId);
        }

        [Then(@"the Widget record can be found in the response body")]
        public void ThenTheWidgetRecordCanBeFoundInTheResponseBody()
        {
            var something = 1;
        }

        private void SetEndpointPath(object widgetId)
        {
            this.testHost.EndpointPath = $"/widgets/{widgetId}";
        }
    }
}
