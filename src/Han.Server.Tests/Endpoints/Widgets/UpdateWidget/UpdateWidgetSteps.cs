using System;
using System.Threading.Tasks;
using Han.Server.Tests.Helpers;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Han.Server.Tests.Endpoints.Widgets.UpdateWidget
{
    [Binding]
    [Scope(Feature = "Update Widget")]
    public class UpdateWidgetSteps
    {
        private readonly TestHost testHost;
        private readonly TestDataHelper testDataHelper;
        private ulong validId;
        private readonly string invalidId;
        private readonly ulong nonExistentId;
        private readonly string widgetName;
        private readonly string updatedWidgetName;

        public UpdateWidgetSteps(TestHost testHost, TestDataHelper testDataHelper)
        {
            this.testHost = testHost;
            this.testDataHelper = testDataHelper;
            this.invalidId = "invalid_id";
            this.nonExistentId = 0;
            this.widgetName = "WidgetName";
            this.updatedWidgetName = "UpdatedWidgetName";
        }

        [BeforeScenario]
        [Scope(Feature = "Update Widget")]
        public async Task BeforeScenario()
        {
            this.validId = await this.testDataHelper.CreateWidgetAsync(this.widgetName);
        }

        [Given("a valid request path for the \'Update Widget\' endpoint")]
        public void GivenAValidRequestPathForTheUpdateWidgetEndpoint()
        {
            this.SetEndpointPath(this.validId);
        }

        [Given("a valid request body for the \'Update Widget\' endpoint")]
        public void GivenAValidRequestBodyForTheUpdateWidgetEndpoint()
        {
            this.testHost.RequestBody.Add("Name", this.updatedWidgetName);
        }

        [Given("a request path for the \'Update Widget\' endpoint with an invalid (.*) parameter")]
        public void GivenARequestPathForTheUpdateWidgetEndpointWithAnInvalidParameter(string field)
        {
            this.SetEndpointPath(this.invalidId);
        }

        [Given("a request path for the \'Update Widget\' endpoint with an ID for a non-existent resource")]
        public void GivenARequestPathForTheUpdateWidgetEndpointWithAnIdForANonExistentResource()
        {
            this.SetEndpointPath(this.nonExistentId);
        }

        [Then("the Widget record has been updated in the database")]
        public async Task ThenTheWidgetRecordHasBeenUpdatedInTheDatabase()
        {
            var record = await this.testDataHelper.GetWidgetAsync(this.validId);

            Assert.AreEqual(this.updatedWidgetName, record.Name);
        }
        private void SetEndpointPath(object widgetId)
        {
            this.testHost.EndpointPath = $"/widgets/{widgetId}";
        }
    }
}
