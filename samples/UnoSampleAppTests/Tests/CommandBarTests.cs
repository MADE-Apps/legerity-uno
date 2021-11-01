namespace UnoSampleAppTests.Tests
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Legerity;
    using Legerity.Web;
    using Legerity.Windows;
    using NUnit.Framework;
    using Pages;

    [TestFixtureSource(nameof(TestPlatformOptions))]
    public class CommandBarTests : BaseTestClass
    {
        public CommandBarTests(AppManagerOptions options) : base(options)
        {
        }

        static IEnumerable<AppManagerOptions> TestPlatformOptions => new List<AppManagerOptions>
        {
            new WindowsAppManagerOptions(WindowsApplication)
            {
                DriverUri = "http://127.0.0.1:4723", LaunchWinAppDriver = true, Maximize = true
            }
        };

        [TestCase("addButton")]
        [TestCase("editButton")]
        public void ShouldClickPrimaryButton(string primaryButton)
        {
            new ControlsPage().Invoke(page => page.CommandBar.ClickPrimaryButton(primaryButton));
        }

        [TestCase("settingsButton")]
        public void ShouldClickSecondaryButton(string secondaryButton)
        {
            this.SkipForPlatform(typeof(WebAppManagerOptions), "Uno Wasm doesn't support secondary buttons in CommandBar elements.");

            new ControlsPage().Invoke(page => page.CommandBar.ClickSecondaryButton(secondaryButton));
        }
    }
}