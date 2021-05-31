namespace UnoSampleAppTests.Tests
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Legerity;
    using Legerity.Uno;
    using Legerity.Uno.Elements;
    using Legerity.Uno.Extensions;
    using Legerity.Web;
    using Legerity.Windows;
    using NUnit.Framework;

    [TestFixtureSource(nameof(TestPlatformOptions))]
    public class AppBarButtonTests : BaseTestClass
    {
        public AppBarButtonTests(AppManagerOptions options) : base(options)
        {
        }

        static IEnumerable<AppManagerOptions> TestPlatformOptions => new List<AppManagerOptions>
        {
            new WebAppManagerOptions(
                WebAppDriverType.Edge,
                Path.Combine(Environment.CurrentDirectory, "Tools\\Edge"))
            {
                Maximize = true, Url = "http://localhost:49247", ImplicitWait = TimeSpan.FromSeconds(10)
            },
            new WindowsAppManagerOptions("com.madeapps.unosampleapp_7mzr475ysvhxg!App")
            {
                DriverUri = "http://127.0.0.1:4723", LaunchWinAppDriver = true, Maximize = true
            }
        };

        [Test]
        public void ShouldClickAppBarButtonByAutomationId()
        {
            AppBarButton button = UnoAppManager.App.FindElementByAutomationId("SampleAppBarButton");
            button.Click();
        }
    }
}