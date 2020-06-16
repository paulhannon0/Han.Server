using System;
using TechTalk.SpecFlow;

namespace Han.Server.Tests.Endpoints.Widgets.CreateWidget
{
    [Binding]
    public class CreateWidgetSteps
    {
        private readonly TestHost testHost;
        private readonly string validName;
        private readonly int invalidName;

        public CreateWidgetSteps(TestHost testHost)
        {
            this.testHost = testHost;
            this.testHost.EndpointPath = "/widgets";
            this.validName = Guid.NewGuid().ToString();
            this.invalidName = 1;
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
