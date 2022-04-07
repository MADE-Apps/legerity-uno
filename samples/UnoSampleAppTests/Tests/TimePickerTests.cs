namespace UnoSampleAppTests.Tests
{
    using System;
    using Legerity;
    using NUnit.Framework;
    using Pages;

    [TestFixtureSource(nameof(TestPlatformOptions))]
    public class TimePickerTests : BaseTestClass
    {
        public TimePickerTests(AppManagerOptions options) : base(options)
        {
        }
        
        [Test]
        public void ShouldSetTime()
        {
            var expectedTime = new TimeSpan(7, 5, 0);
            new ControlsPage().SetTime(expectedTime).VerifyTime(expectedTime);
        }
    }
}