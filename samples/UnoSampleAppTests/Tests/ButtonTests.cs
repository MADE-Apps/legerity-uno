namespace UnoSampleAppTests.Tests
{
    using Legerity;
    using NUnit.Framework;
    using Pages;

    [TestFixtureSource(nameof(TestPlatformOptions))]
    public class ButtonTests : BaseTestClass
    {
        public ButtonTests(AppManagerOptions options) : base(options)
        {
        }

        [Test]
        public void ShouldClickButtonByAutomationId()
        {
            new ControlsPage().Invoke(page => page.Button.Click());
        }
    }
}