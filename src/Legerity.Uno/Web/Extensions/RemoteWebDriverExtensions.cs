namespace Legerity.Uno.Web.Extensions
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Remote;

    public static class RemoteWebDriverExtensions
    {
        public static RemoteWebElement FindElementByXamlType(this RemoteWebDriver driver, string xamlType)
        {
            return driver.FindElement(By.XPath($".//*[@xamltype='{xamlType}']")) as RemoteWebElement;
        }
    }
}