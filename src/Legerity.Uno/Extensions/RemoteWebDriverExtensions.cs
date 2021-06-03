// MADE Apps licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Legerity.Uno.Extensions
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Appium.Android;
    using OpenQA.Selenium.Appium.iOS;
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
            return driver.FindElement(ByExtensions.WebXamlType(xamlType)) as RemoteWebElement;
        }

        /// <summary>
        /// Finds the first Uno Platform web element in the page that matches the given x:Name value.
        /// <para>
        /// To find elements with this method for web applications, set the following in your App.xaml.cs.
        /// <code>
        /// Uno.UI.FeatureConfiguration.UIElement.AssignDOMXamlName = true;
        /// </code>
        /// </para>
        /// </summary>
        /// <param name="driver">The web application driver.</param>
        /// <param name="name">The x:Name of the element to find.</param>
        /// <returns>The <see cref="RemoteWebElement"/> if found.</returns>
        public static RemoteWebElement FindElementByXamlName(this RemoteWebDriver driver, string name)
        {
            return driver switch
            {
                IOSDriver<IOSElement> _ =>
                    driver.FindElement(By.Name(name)) as RemoteWebElement,
                AndroidDriver<AndroidElement> _ =>
                    driver.FindElement(By.Name(name)) as RemoteWebElement,
                WindowsDriver<WindowsElement> _ =>
                    driver.FindElement(By.Name(name)) as RemoteWebElement,
                _ =>
                    driver.FindElement(ByExtensions.WebXamlName(name)) as RemoteWebElement
            };
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
                    driver.FindElement(Windows.Extensions.ByExtensions.AutomationId(automationId)) as RemoteWebElement,
                _ =>
                    driver.FindElement(ByExtensions.WebAutomationId(automationId)) as RemoteWebElement
            };
        }
    }
}