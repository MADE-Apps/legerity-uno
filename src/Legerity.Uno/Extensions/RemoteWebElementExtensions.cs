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
    /// Defines a collection of extensions for <see cref="RemoteWebElement"/> objects.
    /// </summary>
    public static class RemoteWebElementExtensions
    {
        /// <summary>
        /// Finds the first Uno Platform web element under the given element that matches the given XAML type.
        /// </summary>
        /// <param name="element">The web element.</param>
        /// <param name="xamlType">
        /// The XAML type.
        /// <para>
        /// Windows control types can be referenced by the element wrapper's WindowsType value.
        /// </para>
        /// </param>
        /// <returns>The <see cref="RemoteWebElement"/> if found.</returns>
        public static RemoteWebElement FindWebElementByXamlType(this RemoteWebElement element, string xamlType)
        {
            return element.FindElement(ByExtensions.WebXamlType(xamlType)) as RemoteWebElement;
        }

        /// <summary>
        /// Finds the first Uno Platform web element under the given element that matches the given x:Name value.
        /// <para>
        /// To find elements with this method for web applications, set the following in your App.xaml.cs.
        /// <code>
        /// Uno.UI.FeatureConfiguration.UIElement.AssignDOMXamlName = true;
        /// </code>
        /// </para>
        /// </summary>
        /// <param name="element">The web element.</param>
        /// <param name="name">The x:Name of the element to find.</param>
        /// <returns>The <see cref="RemoteWebElement"/> if found.</returns>
        public static RemoteWebElement FindElementByXamlName(this RemoteWebElement element, string name)
        {
            return UnoAppManager.App switch
            {
                IOSDriver<IOSElement> _ =>
                    element.FindElement(By.Name(name)) as RemoteWebElement,
                AndroidDriver<AndroidElement> _ =>
                    element.FindElement(By.Name(name)) as RemoteWebElement,
                WindowsDriver<WindowsElement> _ =>
                    element.FindElement(By.Name(name)) as RemoteWebElement,
                _ =>
                    element.FindElement(ByExtensions.WebXamlName(name)) as RemoteWebElement
            };
        }

        /// <summary>
        /// Finds the first element under the given element that matches the given automation identifier.
        /// <para>
        /// To find elements with this method for web applications, set the following in your App.xaml.cs.
        /// <code>
        /// Uno.UI.FeatureConfiguration.UIElement.AssignDOMXamlName = true;
        /// </code>
        /// </para>
        /// </summary>
        /// <param name="element">The element.</param>
        /// <param name="automationId">The automation identifier.</param>
        /// <returns>The <see cref="RemoteWebElement"/> if found.</returns>
        public static RemoteWebElement FindElementByAutomationId(this RemoteWebElement element, string automationId)
        {
            return UnoAppManager.App switch
            {
                WindowsDriver<WindowsElement> _ =>
                    element.FindElement(Windows.Extensions.ByExtensions.AutomationId(automationId)) as RemoteWebElement,
                _ =>
                    element.FindElement(ByExtensions.WebXamlId(automationId)) as RemoteWebElement
            };
        }
    }
}