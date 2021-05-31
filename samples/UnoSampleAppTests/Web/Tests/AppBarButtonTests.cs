namespace UnoSampleAppTests.Web.Tests
{
    using Legerity;
    using Legerity.Uno.Web.Elements;
    using Legerity.Uno.Web.Extensions;
    using NUnit.Framework;

    [TestFixture]
    public class AppBarButtonTests : WebTestClass
    {
        public override string LaunchUrl => "http://localhost:49247";

        [Test]
        public void ShouldClickAppBarButtonByXamlType()
        {
            AppBarButton button = AppManager.WebApp.FindElementByXamlType(AppBarButton.WindowsType);
            button.Click();
        }

        [Test]
        public void ShouldClickAppBarButtonByAutomationId()
        {
            AppBarButton button = AppManager.WebApp.FindElementByAutomationId("SampleAppBarButton");
            button.Click();
        }

    }
}