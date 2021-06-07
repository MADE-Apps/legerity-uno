namespace UnoSampleAppTests.Tests
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Legerity;
    using Legerity.Web;
    using Legerity.Windows;
    using NUnit.Framework;
    using Pages;
    using Shouldly;

    [TestFixtureSource(nameof(TestPlatformOptions))]
    public class TextBlockTests : BaseTestClass
    {
        public TextBlockTests(AppManagerOptions options) : base(options)
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
        public void ShouldGetText()
        {
            new ControlsPage().Invoke(page => page.TextBlock.Text.ShouldBe("I am a TextBlock"));
        }
    }
}