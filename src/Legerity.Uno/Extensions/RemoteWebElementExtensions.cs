// MADE Apps licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Legerity.Uno.Extensions
{
    using System;
    using Legerity.Windows;
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
            return element.FindElement(ByExtras.WebXamlType(xamlType)) as RemoteWebElement;
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
            return element switch
            {
                IOSElement _ =>
                    element.FindElement(By.Name(name)) as RemoteWebElement,
                AndroidElement _ =>
                    element.FindElement(ByExtras.AndroidXamlName(name)) as RemoteWebElement,
                WindowsElement _ =>
                    element.FindElement(By.Name(name)) as RemoteWebElement,
                _ =>
                    element.FindElement(ByExtras.WebXamlName(name)) as RemoteWebElement
            };
        }

        /// <summary>
        /// Finds the first element under the given element that matches the given automation identifier.
        /// <para>
        /// To find element for platforms supported by Uno, set the following in your App.xaml.cs constructor.
        /// <code>
        /// Uno.UI.FrameworkElementHelper.IsUiAutomationMappingEnabled = true;
        /// </code>
        /// </para>
        /// <para>
        /// For improvements to finding elements for web applications, also set the following in your App.xaml.cs constructor.
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
            return element switch
            {
                AndroidElement _ =>
                    element.FindElement(ByExtras.AndroidXamlAutomationId(automationId)) as RemoteWebElement,
                WindowsElement _ =>
                    element.FindElement(WindowsByExtras.AutomationId(automationId)) as RemoteWebElement,
                _ =>
                    element.FindElement(ByExtras.WebXamlAutomationId(automationId)) as RemoteWebElement
            };
        }

        /// <summary>
        /// Verifies the elements name or AutomationId based on the given compare.
        /// </summary>
        /// <param name="element">
        /// The element to verify.
        /// </param>
        /// <param name="compare">
        /// The value to verify is the name or AutomationId.
        /// </param>
        /// <returns>
        /// True if the element's name or AutomationId matches; otherwise, false.
        /// </returns>
        public static bool VerifyNameOrAutomationIdEquals(this RemoteWebElement element, string compare)
        {
            string name = element.GetXamlName();
            string automationId = element.GetAutomationId();

            return string.Equals(compare, name, StringComparison.CurrentCultureIgnoreCase) ||
                   string.Equals(compare, automationId, StringComparison.CurrentCultureIgnoreCase);
        }
    }
}