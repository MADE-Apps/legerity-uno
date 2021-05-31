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

        public static RemoteWebElement FindElementByAutomationId(this RemoteWebDriver driver, string automationId)
        {
            return driver.FindElement(By.XPath($".//*[@xuid='{automationId}']")) as RemoteWebElement;
        }

        public static RemoteWebElement FindElementByXamlName(this RemoteWebDriver driver, string name)
        {
            return driver.FindElement(By.XPath($".//*[@xamlname='{name}']")) as RemoteWebElement;
        }
    }
}