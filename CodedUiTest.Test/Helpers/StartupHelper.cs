using Microsoft.VisualStudio.TestTools.UITesting;

namespace IKEA.SalesCoworker.CodedUI.Tests.Helpers
{
    public static class StartupHelper
    {
        public static void ConfigurePlayBack(bool collectSnappoints = true)
        {
            if (collectSnappoints)
            {
                Playback.PlaybackSettings.LoggerOverrideState = HtmlLoggerState.AllActionSnapshot;
            }
        }

    }
}
