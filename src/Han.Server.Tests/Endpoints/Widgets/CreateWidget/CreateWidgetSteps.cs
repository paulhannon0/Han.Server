using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Han.Server.Tests.Endpoints.Widgets.CreateWidget
{
    [Binding]
    public class CreateWidgetSteps
    {
        private readonly TestHost testHost;
        private Dictionary<string, object> requestBody;
        private HttpResponseMessage responseMessage;
        private readonly string path;

        public CreateWidgetSteps(TestHost testHost)
        {
            this.testHost = testHost;
            this.testHost.EndpointPath = "/widgets";
        }

        [Given("a valid request body for the \'Create Widget\' endpoint")]
        public void GivenAValidRequestBodyForTheCreateWidgetEndpoint()
        {
            this.testHost.RequestBody = new Dictionary<string, object>
            {
                { "Name", Guid.NewGuid().ToString() }
            };
        }

        [When("the request is made")]
        public async Task WhenTheRequestIsMade()
        {
            this.responseMessage = await this.testHost.PostAsync();
        }
    }
}
