namespace UnoSampleAppTests.Tests
{
    using Legerity;
    using NUnit.Framework;
    using Pages;

    [TestFixtureSource(nameof(TestPlatformOptions))]
    public class HyperlinkButtonTests : BaseTestClass
    {
        public HyperlinkButtonTests(AppManagerOptions options) : base(options)
        {
        }
        
        [Test]
        public void ShouldClickHyperlinkButtonByAutomationId()
        {
            new ControlsPage().Invoke(page => page.HyperlinkButton.Click());
        }
    }
}