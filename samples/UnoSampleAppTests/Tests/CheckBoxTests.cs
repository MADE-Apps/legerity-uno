namespace UnoSampleAppTests.Tests
{
    using Legerity;
    using NUnit.Framework;
    using Pages;

    [TestFixtureSource(nameof(TestPlatformOptions))]
    public class CheckBoxTests : BaseTestClass
    {
        public CheckBoxTests(AppManagerOptions options) : base(options)
        {
        }

        [Test]
        public void ShouldCheckOn()
        {
            new ControlsPage().TickCheckBox(true).VerifyCheckBoxTicked(true);
        }

        [Test]
        public void ShouldCheckOff()
        {
            new ControlsPage().TickCheckBox(false).VerifyCheckBoxTicked(false);
        }
    }
}