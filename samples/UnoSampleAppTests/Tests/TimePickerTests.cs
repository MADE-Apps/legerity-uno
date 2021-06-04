namespace UnoSampleAppTests.Tests
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Legerity;
    using Legerity.Uno;
    using Legerity.Uno.Elements;
    using Legerity.Uno.Extensions;
    using Legerity.Web;
    using Legerity.Windows;
    using NUnit.Framework;
    using Shouldly;

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
            // Arrange
            var expectedTime = new TimeSpan(7, 5, 0);
            TimePicker timePicker = UnoAppManager.App.FindElementByAutomationId("SampleTimePicker");

            // Act
            timePicker.SetTime(expectedTime);

            // Assert
            timePicker.SelectedTime.ShouldBe(expectedTime);
        }
    }
}