using TechTalk.SpecFlow;

namespace Han.Server.Tests.Common
{
    [Binding]
    public class ResponseSteps
    {
        [Then(@"\((.*)\) Created is returned")]
        public void ThenStatusCodeIsReturned(int statusCode)
        {

        }
    }
}
