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
    }
}