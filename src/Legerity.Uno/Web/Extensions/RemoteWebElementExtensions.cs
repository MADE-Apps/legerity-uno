namespace Legerity.Uno.Web.Extensions
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Remote;

    public static class RemoteWebElementExtensions
    {
        public static RemoteWebElement FindElementByXamlType(this RemoteWebElement element, string xamlType)
        {
            return element.FindElement(By.XPath($".//*[@xamltype='{xamlType}']")) as RemoteWebElement;
        }
    }
}
