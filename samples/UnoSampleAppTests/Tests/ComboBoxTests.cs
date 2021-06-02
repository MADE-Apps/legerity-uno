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
    public class ComboBoxTests : BaseTestClass
    {
        public ComboBoxTests(AppManagerOptions options) : base(options)
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
        public void ShouldSetComboBoxItem()
        {
            // Arrange
            string expectedItem = "Green";
            ComboBox comboBox = App.FindElementByAutomationId("SampleComboBox");

            // Act
            comboBox.SelectItem(expectedItem);

            // Assert
            comboBox.SelectedItem.ShouldBe(expectedItem);
        }
    }
}