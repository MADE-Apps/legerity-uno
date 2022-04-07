namespace UnoSampleAppTests.Tests
{
    using Legerity;
    using Legerity.Android;
    using NUnit.Framework;
    using Pages;

    [TestFixtureSource(nameof(TestPlatformOptions))]
    public class AppBarToggleButtonTests : BaseTestClass
    {
        public AppBarToggleButtonTests(AppManagerOptions options) : base(options)
        {
        }
        
        [Test]
        public void SetToggleSymbolIconButtonOn()
        {
            this.SkipForPlatform(
                Assert.Ignore,
                "AppBarToggleButton states are not currently supported through automation properties in Uno Platform.",
                typeof(AndroidAppManagerOptions));

            new ControlsPage().ToggleAppBarButton(true).VerifyAppBarButtonToggled(true);
        }

        [Test]
        public void SetToggleSymbolIconButtonOff()
        {
            this.SkipForPlatform(
                Assert.Ignore,
                "AppBarToggleButton states are not currently supported through automation properties in Uno Platform.",
                typeof(AndroidAppManagerOptions));

            new ControlsPage().ToggleAppBarButton(false).VerifyAppBarButtonToggled(false);
        }
    }
}