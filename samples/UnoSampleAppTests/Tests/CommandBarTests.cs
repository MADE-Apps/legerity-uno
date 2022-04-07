namespace UnoSampleAppTests.Tests
{
    using Legerity;
    using NUnit.Framework;
    using Pages;

    [TestFixtureSource(nameof(TestPlatformOptions))]
    public class CommandBarTests : BaseTestClass
    {
        public CommandBarTests(AppManagerOptions options) : base(options)
        {
        }

        [TestCase("BarAddButton")]
        [TestCase("BarEditButton")]
        public void ShouldClickPrimaryButton(string primaryButton)
        {
            new ControlsPage().Invoke(page => page.CommandBar.ClickPrimaryButton(primaryButton));
        }

        [TestCase("BarSettingsButton")]
        public void ShouldClickSecondaryButton(string secondaryButton)
        {
            new ControlsPage().Invoke(page => page.CommandBar.ClickSecondaryButton(secondaryButton));
        }
    }
}