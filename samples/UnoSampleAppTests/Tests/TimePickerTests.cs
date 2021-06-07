namespace UnoSampleAppTests.Tests
{
    using System;
    using System.Collections.Generic;
    using Legerity;
    using Legerity.Windows;
    using NUnit.Framework;
    using Pages;

    [TestFixtureSource(nameof(TestPlatformOptions))]
    public class TimePickerTests : BaseTestClass
    {
        public TimePickerTests(AppManagerOptions options) : base(options)
        {
        }

        static IEnumerable<AppManagerOptions> TestPlatformOptions => new List<AppManagerOptions>
        {
            new WindowsAppManagerOptions(WindowsApplication)
            {
                DriverUri = "http://127.0.0.1:4723", LaunchWinAppDriver = true, Maximize = true
            }
        };

        [Test]
        public void ShouldSetTime()
        {
            var expectedTime = new TimeSpan(7, 5, 0);
            new ControlsPage().SetTime(expectedTime).VerifyTime(expectedTime);
        }
    }
}