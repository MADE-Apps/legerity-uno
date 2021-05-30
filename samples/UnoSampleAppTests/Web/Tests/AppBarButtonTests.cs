namespace UnoSampleAppTests.Web.Tests
{
    using Legerity;
    using Legerity.Uno.Web.Elements;
    using Legerity.Uno.Web.Extensions;
    using NUnit.Framework;
    using OpenQA.Selenium.Remote;

    [TestFixture]
    public class AppBarButtonTests : WebTestClass
    {
        public override string LaunchUrl => "http://localhost:49247";

        [Test]
        public void ShouldClickAppBarButton()
        {
            AppBarButton button = AppManager.WebApp.FindElementByXamlType(AppBarButton.WindowsType);
            button.Click();
        }
    }
}