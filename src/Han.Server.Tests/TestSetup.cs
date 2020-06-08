using TechTalk.SpecFlow;

namespace Han.Server.Tests
{
    [Binding]
    public class TestSetup
    {
        [BeforeTestRun]
        public static void SetUp()
        {
            TestConfiguration.Apply();
        }
    }
}
