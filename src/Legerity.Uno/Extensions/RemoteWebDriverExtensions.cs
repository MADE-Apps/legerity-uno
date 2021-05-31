namespace Legerity.Uno.Extensions
{
    using Legerity.Windows.Extensions;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Appium.Windows;
    using OpenQA.Selenium.Remote;

    /// <summary>
    /// Defines a collection of extensions for <see cref="RemoteWebDriver"/> objects.
    /// </summary>
    public static class RemoteWebDriverExtensions
    {
        /// <summary>
        /// Finds the first Uno Platform web element in the page that matches the given XAML type.
        /// </summary>
        /// <param name="driver">The web application driver.</param>
        /// <param name="xamlType">
        /// The XAML type.
        /// <para>
        /// Windows control types can be referenced by the element wrapper's WindowsType value.
        /// </para>
        /// </param>
        /// <returns>The <see cref="RemoteWebElement"/> if found.</returns>
        public static RemoteWebElement FindWebElementByXamlType(this RemoteWebDriver driver, string xamlType)
        {
            return driver.FindElement(By.XPath($".//*[@xamltype='{xamlType}']")) as RemoteWebElement;
        }

        /// <summary>
        /// Finds the first Uno Platform web element in the page that matches the given x:Name value.
        /// <para>
        /// To find elements with this method, set the following in your App.xaml.cs.
        /// <code>
        /// Uno.UI.FeatureConfiguration.UIElement.AssignDOMXamlName = true;
        /// </code>
        /// </para>
        /// </summary>
        /// <param name="driver">The web application driver.</param>
        /// <param name="name">The x:Name of the element to find.</param>
        /// <returns>The <see cref="RemoteWebElement"/> if found.</returns>
        public static RemoteWebElement FindWebElementByXamlName(this RemoteWebDriver driver, string name)
        {
            return driver.FindElement(By.XPath($".//*[@xamlname='{name}']")) as RemoteWebElement;
        }

        /// <summary>
        /// Finds the first element in the page that matches the given automation identifier.
        /// <para>
        /// To find elements with this method for web applications, set the following in your App.xaml.cs.
        /// <code>
        /// Uno.UI.FeatureConfiguration.UIElement.AssignDOMXamlName = true;
        /// </code>
        /// </para>
        /// </summary>
        /// <param name="driver">The application driver.</param>
        /// <param name="automationId">The automation identifier.</param>
        /// <returns>The <see cref="RemoteWebElement"/> if found.</returns>
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