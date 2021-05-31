namespace Legerity.Uno.Extensions
{
    using Legerity.Windows.Extensions;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Appium.Windows;
    using OpenQA.Selenium.Remote;

    public static class RemoteWebDriverExtensions
    {
        public static RemoteWebElement FindWebElementByXamlType(this RemoteWebDriver driver, string xamlType)
        {
            return driver.FindElement(By.XPath($".//*[@xamltype='{xamlType}']")) as RemoteWebElement;
        }

        public static RemoteWebElement FindWebElementByXamlName(this RemoteWebDriver driver, string name)
        {
            return driver.FindElement(By.XPath($".//*[@xamlname='{name}']")) as RemoteWebElement;
        }

        public static RemoteWebElement FindElementByAutomationId(this RemoteWebDriver driver, string automationId)
        {
            return driver switch
            {
                WindowsDriver<WindowsElement> _ =>
                    driver.FindElement(ByExtensions.AutomationId(automationId)) as RemoteWebElement,
                _ =>
                    driver.FindElement(By.XPath($".//*[@xuid='{automationId}']")) as RemoteWebElement
            };
        }
    }
}