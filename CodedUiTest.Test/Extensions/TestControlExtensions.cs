using System;
using Microsoft.VisualStudio.TestTools.UITesting;

namespace IKEA.SalesCoworker.CodedUI.Tests.Extensions
{
    public static class TestControlExtensions
    {
        public static int DefaultWaitingTimeInSecondes = 1;

        public static bool WaitForReady(this UITestControl control)
        {
            return WaitForReady(control, TimeSpan.FromSeconds(DefaultWaitingTimeInSecondes));
        }

        public static bool WaitForReady(this UITestControl control, TimeSpan timeSpan)
        {
            return control.WaitForControlReady(timeSpan.Milliseconds);
        }
        public static bool WaitForNotVisible(this UITestControl control, TimeSpan timeSpan)
        {
            return control.WaitForControlNotExist(timeSpan.Milliseconds);
        }
    }
}
