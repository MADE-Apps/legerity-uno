namespace UnoSampleAppTests.Tests
{
    using Legerity;
    using Legerity.Uno.Elements;
    using NUnit.Framework;
    using Pages;
    using Shouldly;

    [TestFixtureSource(nameof(TestPlatformOptions))]
    public class TextBoxTests : BaseTestClass
    {
        public TextBoxTests(AppManagerOptions options) : base(options)
        {
        }

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