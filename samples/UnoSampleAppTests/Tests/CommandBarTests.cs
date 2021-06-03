namespace UnoSampleAppTests.Tests
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Legerity;
    using Legerity.Uno.Elements;
    using Legerity.Uno.Extensions;
    using Legerity.Web;
    using Legerity.Windows;
    using NUnit.Framework;

    [TestFixtureSource(nameof(TestPlatformOptions))]
    public class CommandBarTests : BaseTestClass
    {
        public CommandBarTests(AppManagerOptions options) : base(options)
        {
        }

        static IEnumerable<AppManagerOptions> TestPlatformOptions => new List<AppManagerOptions>
        {
            new WebAppManagerOptions(
                WebAppDriverType.Edge,
                Path.Combine(Environment.CurrentDirectory, "Tools\\Edge"))
            {
                Maximize = true, Url = WasmApplication, ImplicitWait = TimeSpan.FromSeconds(10)
            },
            new WindowsAppManagerOptions(WindowsApplication)
            {
                DriverUri = "http://127.0.0.1:4723", LaunchWinAppDriver = true, Maximize = true
            }
        };

        [TestCase("addButton")]
        [TestCase("editButton")]
        public void ShouldClickPrimaryButton(string primaryButton)
        {
            CommandBar commandBar = App.FindElementByAutomationId("SampleCommandBar");
            commandBar.ClickPrimaryButton(primaryButton);
        }

        [TestCase("settingsButton")]
        public void ShouldClickSecondaryButton(string secondaryButton)
        {
            CommandBar commandBar = App.FindElementByAutomationId("SampleCommandBar");
            commandBar.ClickSecondaryButton(secondaryButton);
        }
    }
}