namespace Legerity.Uno.Extensions
{
    using Legerity.Android.Extensions;
    using Legerity.Extensions;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Appium.Android;
    using OpenQA.Selenium.Appium.Windows;

    /// <summary>
    /// Defines a collection of extensions for retrieving element attributes.
    /// </summary>
    public static class AttributeExtensions
    {
        /// <summary>
        /// Gets the value of the specified XAML name for this element.
        /// </summary>
        /// <param name="element">The element to retrieve a XAML name for.</param>
        /// <returns>The element's XAML name.</returns>
        public static string GetXamlName(this IWebElement element)
        {
            return element switch
            {
                WindowsElement _ => element.GetName(),
                _ => element.GetAttribute("xamlname")
            };
        }

        /// <summary>
        /// Gets the value of the specified automation ID for this element.
        /// </summary>
        /// <param name="element">The element to retrieve an automation ID for.</param>
        /// <returns>The element's automation ID.</returns>
        public static string GetAutomationId(this IWebElement element)
        {
            return element switch
            {
                AndroidElement _ => element.GetContentDescription(),
                WindowsElement _ => Legerity.Windows.Extensions.AttributeExtensions.GetAutomationId(element),
                _ => element.GetAttribute("xuid")
            };
        }
    }
}
