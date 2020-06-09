using System;

namespace Han.Server.Tests.Endpoints.Widgets.CreateWidget
{
    public static class CreateWidgetFixtures
    {
        public static string ValidName { get; } = Guid.NewGuid().ToString();

        public static int InvalidName { get; } = 1;
    }
}
