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
    public class TextBoxTests : BaseTestClass
    {
        public TextBoxTests(AppManagerOptions options) : base(options)
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
        public void ShouldSetText()
        {
            // Arrange
            string text = "Hello, World!";
            TextBox textBox = UnoAppManager.App.FindElementByAutomationId("SampleTextBox");

            // Act
            textBox.SetText(text);

            // Assert
            textBox.Text.ShouldBe(text);
        }

        [Test]
        public void ShouldAppendText()
        {
            // Arrange
            string expected = "Hello, World!";
            string append = ", World!";

            TextBox textBox = UnoAppManager.App.FindElementByAutomationId("SampleTextBox");
            textBox.SetText("Hello");

            // Act
            textBox.AppendText(append);

            // Assert
            textBox.Text.ShouldBe(expected);
        }

        [Test]
        public void ShouldClearText()
        {
            // Arrange
            string text = "Hello, World!";

            TextBox textBox = UnoAppManager.App.FindElementByAutomationId("SampleTextBox");
            textBox.SetText(text);

            // Act
            textBox.ClearText();

            // Assert
            textBox.Text.ShouldBe(string.Empty);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void ShouldDetermineReadonlyState(bool isReadonly)
        {
            // Arrange
            TextBox textBox = UnoAppManager.App.FindElementByAutomationId(isReadonly ? "SampleReadonlyTextBox" : "SampleTextBox");

            // Assert
            textBox.IsReadonly.ShouldBe(isReadonly);
        }

    }
}