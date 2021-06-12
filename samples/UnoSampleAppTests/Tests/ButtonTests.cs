namespace UnoSampleAppTests.Tests
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Legerity;
    using Legerity.Android;
    using Legerity.Web;
    using Legerity.Windows;
    using NUnit.Framework;
    using Pages;

    [TestFixtureSource(nameof(TestPlatformOptions))]
    public class ButtonTests : BaseTestClass
    {
        public ButtonTests(AppManagerOptions options) : base(options)
        {
        }

        static IEnumerable<AppManagerOptions> TestPlatformOptions => new List<AppManagerOptions>
        {
            new AndroidAppManagerOptions(Path.Combine(Environment.CurrentDirectory, AndroidApplication))
            {
                DriverUri = "http://localhost:4723/wd/hub",
                LaunchAppiumServer = false
            },
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

        [Test]
        public void ShouldClickButtonByAutomationId()
        {
            new ControlsPage().Invoke(page => page.Button.Click());
        }
    }
}