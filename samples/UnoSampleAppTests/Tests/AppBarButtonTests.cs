namespace UnoSampleAppTests.Tests
{
    using Legerity;
    using NUnit.Framework;
    using Pages;

    [TestFixtureSource(nameof(TestPlatformOptions))]
    public class AppBarButtonTests : BaseTestClass
    {
        public AppBarButtonTests(AppManagerOptions options) : base(options)
        {
        }

        [Test]
        public void ShouldClickAppBarButtonByAutomationId()
        {
            new ControlsPage().AppBarButton.Click();
        }
    }
}