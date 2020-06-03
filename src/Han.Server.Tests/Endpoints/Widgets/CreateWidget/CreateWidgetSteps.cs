using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Han.Server.Tests.Endpoints.Widgets.CreateWidget
{
    [Binding]
    public class CreateWidgetSteps
    {
        private Dictionary<string, object> requestBody;
        private HttpResponseMessage responseMessage;
        private readonly string path;

        public CreateWidgetSteps()
        {
            this.path = "/widgets";
        }

        [Given("a valid request body for the \'Create Widget\' endpoint")]
        public void GivenAValidRequestBodyForTheCreateWidgetEndpoint()
        {
            this.requestBody = new Dictionary<string, object>
            {
                { "Name", Guid.NewGuid().ToString() }
            };
        }

        [When("the request is made")]
        public async Task WhenTheRequestIsMade()
        {
            this.responseMessage = await TestClient.PostAsync
            (
                this.path,
                this.requestBody
            );
        }

        [Then("the widget is created")]
        public void ThenTheWidgetIsCreated()
        {

        }

        [Then("the ID of the widget is returned in the Location response header")]
        public void ThenTheIdOfTheWidgetIsReturnedInTheLocationResponseHeader()
        {

        }
    }
}
