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

        public static RemoteWebElement FindElementByAutomationId(this RemoteWebElement element, string automationId)
        {
            return element.FindElement(By.XPath($".//*[@xuid='{automationId}']")) as RemoteWebElement;
        }

        public static RemoteWebElement FindElementByXamlName(this RemoteWebElement element, string name)
        {
            return element.FindElement(By.XPath($".//*[@xamlname='{name}']")) as RemoteWebElement;
        }
    }
}
