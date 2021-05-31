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
    using Shouldly;

    [TestFixtureSource(nameof(TestPlatformOptions))]
    public class AppBarToggleButtonTests : BaseTestClass
    {
        public AppBarToggleButtonTests(AppManagerOptions options) : base(options)
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
        public void SetToggleSymbolIconButtonOn()
        {
            // Arrange
            AppBarToggleButton toggle = UnoAppManager.App.FindElementByAutomationId("SampleAppBarToggleButton");

            // Act
            toggle.ToggleOn();

            // Assert
            toggle.IsOn.ShouldBeTrue();
        }

        [Test]
        public void SetToggleSymbolIconButtonOff()
        {
            // Arrange
            AppBarToggleButton toggle = UnoAppManager.App.FindElementByAutomationId("SampleAppBarToggleButton");

            // Act
            toggle.ToggleOff();

            // Assert
            toggle.IsOn.ShouldBeFalse();
        }
    }
}