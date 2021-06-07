namespace UnoSampleAppTests.Tests
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Legerity;
    using Legerity.Uno.Elements;
    using Legerity.Web;
    using Legerity.Windows;
    using NUnit.Framework;
    using Pages;
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
            const string text = "Hello, World!";
            new ControlsPage().Invoke(page => page.TextBox.SetText(text)).VerifyTextBoxText(text);
        }

        [Test]
        public void ShouldAppendText()
        {
            const string expected = "Hello, World!";
            const string append = ", World!";

            new ControlsPage()
                .Invoke(page => page.TextBox.SetText("Hello"))
                .Invoke(page => page.TextBox.AppendText(append))
                .VerifyTextBoxText(expected);
        }

        [Test]
        public void ShouldClearText()
        {
            string text = "Hello, World!";

            new ControlsPage()
                .Invoke(page => page.TextBox.SetText(text))
                .Invoke(page => page.TextBox.ClearText())
                .VerifyTextBoxText(string.Empty);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void ShouldDetermineReadonlyState(bool isReadonly)
        {
            var page = new ControlsPage();

            TextBox textBox = isReadonly ? page.ReadonlyTextBox : page.TextBox;
            textBox.IsReadonly.ShouldBe(isReadonly);
        }
    }
}