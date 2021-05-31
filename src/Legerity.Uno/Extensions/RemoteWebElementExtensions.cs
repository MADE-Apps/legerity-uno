namespace Legerity.Uno.Extensions
{
    using Legerity.Windows.Extensions;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Appium.Windows;
    using OpenQA.Selenium.Remote;

    public static class RemoteWebElementExtensions
    {
        public static RemoteWebElement FindWebElementByXamlType(this RemoteWebElement element, string xamlType)
        {
            return element.FindElement(By.XPath($".//*[@xamltype='{xamlType}']")) as RemoteWebElement;
        }

        public static RemoteWebElement FindWebElementByXamlName(this RemoteWebElement element, string name)
        {
            return element.FindElement(By.XPath($".//*[@xamlname='{name}']")) as RemoteWebElement;
        }

        public static RemoteWebElement FindElementByAutomationId(this RemoteWebElement element, string automationId)
        {
            return UnoAppManager.App switch
            {
                WindowsDriver<WindowsElement> _ =>
                    element.FindElement(ByExtensions.AutomationId(automationId)) as RemoteWebElement,
                _ =>
                    element.FindElement(By.XPath($".//*[@xuid='{automationId}']")) as RemoteWebElement
            };
        }
    }
}