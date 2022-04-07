namespace UnoSampleAppTests.Tests
{
    using Legerity;
    using NUnit.Framework;
    using Pages;
    using Shouldly;

    [TestFixtureSource(nameof(TestPlatformOptions))]
    public class TextBlockTests : BaseTestClass
    {
        public TextBlockTests(AppManagerOptions options) : base(options)
        {
        }

        [Test]
        public void ShouldGetText()
        {
            new ControlsPage().Invoke(page => page.TextBlock.Text.ShouldBe("I am a TextBlock"));
        }
    }
}