namespace UnoSampleAppTests.Tests
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Legerity;
    using Legerity.Android;
    using Legerity.Web;
    using Legerity.Windows;
    using NUnit.Framework;
    using Pages;

    [TestFixtureSource(nameof(TestPlatformOptions))]
    public class HyperlinkButtonTests : BaseTestClass
    {
        public HyperlinkButtonTests(AppManagerOptions options) : base(options)
        {
        }

        static IEnumerable<AppManagerOptions> TestPlatformOptions => new List<AppManagerOptions>
        {
            new AndroidAppManagerOptions
            {
                AppId = AndroidApplication,
                AppActivity = AndroidApplicationActivity,
                DriverUri = "http://localhost:4723/wd/hub",
                LaunchAppiumServer = false
            },
            new WebAppManagerOptions(
                WebAppDriverType.EdgeChromium,
                Path.Combine(Environment.CurrentDirectory))
            {
                Maximize = true, Url = WasmApplication, ImplicitWait = TimeSpan.FromSeconds(10)
            },
            new WebAppManagerOptions(
                WebAppDriverType.Chrome,
                Path.Combine(Environment.CurrentDirectory))
            {
                Maximize = true, Url = WasmApplication, ImplicitWait = TimeSpan.FromSeconds(10)
            },
            new WindowsAppManagerOptions(WindowsApplication)
            {
                DriverUri = "http://127.0.0.1:4723", LaunchWinAppDriver = true, Maximize = true
            }
        };

        [Test]
        public void ShouldClickHyperlinkButtonByAutomationId()
        {
            new ControlsPage().Invoke(page => page.HyperlinkButton.Click());
        }
    }
}