using NUnit.Framework;
using TechTalk.SpecFlow;

[assembly: NonParallelizable]

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
