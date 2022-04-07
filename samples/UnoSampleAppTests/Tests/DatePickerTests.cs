namespace UnoSampleAppTests.Tests
{
    using System;
    using Legerity;
    using NUnit.Framework;
    using Pages;

    [TestFixtureSource(nameof(TestPlatformOptions))]
    public class DatePickerTests : BaseTestClass
    {
        public DatePickerTests(AppManagerOptions options) : base(options)
        {
        }

        [Test]
        public void ShouldSetDate()
        {
            var expectedDate = new DateTime(2020, 3, 30);
            new ControlsPage().SetDate(expectedDate).VerifyDate(expectedDate);
        }
    }
}