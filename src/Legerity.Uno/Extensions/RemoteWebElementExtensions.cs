namespace Legerity.Uno.Extensions
{
    using Legerity.Windows.Extensions;
    using OpenQA.Selenium;
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
            return element.FindElement(By.XPath($".//*[@xamltype='{xamlType}']")) as RemoteWebElement;
        }

        /// <summary>
        /// Finds the first Uno Platform web element under the given element that matches the given x:Name value.
        /// <para>
        /// To find elements with this method, set the following in your App.xaml.cs.
        /// <code>
        /// Uno.UI.FeatureConfiguration.UIElement.AssignDOMXamlName = true;
        /// </code>
        /// </para>
        /// </summary>
        /// <param name="element">The web element.</param>
        /// <param name="name">The x:Name of the element to find.</param>
        /// <returns>The <see cref="RemoteWebElement"/> if found.</returns>
        public static RemoteWebElement FindWebElementByXamlName(this RemoteWebElement element, string name)
        {
            return element.FindElement(By.XPath($".//*[@xamlname='{name}']")) as RemoteWebElement;
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
                    element.FindElement(ByExtensions.AutomationId(automationId)) as RemoteWebElement,
                _ =>
                    element.FindElement(By.XPath($".//*[@xuid='{automationId}']")) as RemoteWebElement
            };
        }
    }
}