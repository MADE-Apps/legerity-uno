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
    public class CheckBoxTests : BaseTestClass
    {
        public CheckBoxTests(AppManagerOptions options) : base(options)
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

        [Test]
        public void ShouldCheckOn()
        {
            // Arrange
            CheckBox checkBox = UnoAppManager.App.FindElementByAutomationId("SampleCheckBox");

            // Act
            checkBox.CheckOn();

            // Assert
            checkBox.IsChecked.ShouldBeTrue();
        }

        [Test]
        public void ShouldCheckOff()
        {
            // Arrange
            CheckBox checkBox = UnoAppManager.App.FindElementByAutomationId("SampleCheckBox");

            // Act
            checkBox.CheckOff();

            // Assert
            checkBox.IsChecked.ShouldBeFalse();
        }
    }
}