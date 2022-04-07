namespace UnoSampleAppTests.Tests
{
    using Legerity;
    using NUnit.Framework;
    using Pages;

    [TestFixtureSource(nameof(TestPlatformOptions))]
    public class ComboBoxTests : BaseTestClass
    {
        public ComboBoxTests(AppManagerOptions options) : base(options)
        {
        }
        
        [Test]
        public void ShouldSetComboBoxItem()
        {
            const string expectedItem = "Green";
            new ControlsPage().SelectComboBoxItem(expectedItem).VerifyComboBoxItem(expectedItem);
        }
    }
}