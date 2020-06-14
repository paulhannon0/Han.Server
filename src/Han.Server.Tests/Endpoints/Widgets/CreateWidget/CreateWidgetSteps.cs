using System;
using TechTalk.SpecFlow;

namespace Han.Server.Tests.Endpoints.Widgets.CreateWidget
{
    [Binding]
    public class CreateWidgetSteps
    {
        private readonly TestHost testHost;
        private string validName = Guid.NewGuid().ToString();
        private int invalidName = 1;

        public CreateWidgetSteps(TestHost testHost)
        {
            this.testHost = testHost;
            this.testHost.EndpointPath = "/widgets";
        }

        [Given("a valid request for the \'Create Widget\' endpoint")]
        public void GivenAValidRequestBodyForTheCreateWidgetEndpoint()
        {
            this.testHost.RequestBody.Add("Name", this.validName);
        }

        [Given("a request for the \'Create Widget\' endpoint containing an invalid (.*) parameter")]
        public void GivenARequestBodyForTheCreateWidgetEndpointContainingAnInvalidParameter(string field)
        {
            switch (field)
            {
                case "Name":
                    this.testHost.RequestBody.Add("Name", this.invalidName);
                    break;

                default:
                    break;
            }
        }
    }
}
