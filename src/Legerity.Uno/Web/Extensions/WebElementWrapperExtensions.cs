namespace Legerity.Uno.Web.Extensions
{
    using Legerity.Web.Elements;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Remote;

    public static class WebElementWrapperExtensions
    {
        public static RemoteWebElement FindElementByXamlType(this WebElementWrapper element, string xamlType)
        {
            return element.FindElement(By.XPath($".//*[@xamltype='{xamlType}']"));
        }

        public static RemoteWebElement FindElementByAutomationId(this WebElementWrapper element, string automationId)
        {
            return element.FindElement(By.XPath($".//*[@xuid='{automationId}']"));
        }

        public static RemoteWebElement FindElementByXamlName(this WebElementWrapper element, string name)
        {
            return element.FindElement(By.XPath($".//*[@xamlname='{name}']"));
        }
    }
}