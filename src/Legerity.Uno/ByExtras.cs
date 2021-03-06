namespace Legerity.Uno
{
    using System;
    using Legerity.Android;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Appium;
    using OpenQA.Selenium.Appium.Android.UiAutomator;

    /// <summary>
    /// Defines a collection of extra locator constraints for <see cref="By"/>.
    /// </summary>
    public static class ByExtras
    {
        /// <summary>
        /// Gets a mechanism to find elements by a web XAML name.
        /// </summary>
        /// <param name="name">The XAML element name.</param>
        /// <returns>A <see cref="By"/> object the driver can use to find elements.</returns>
        public static By WebXamlName(string name)
        {
            return By.XPath($".//*[@xamlname='{name}']");
        }

        /// <summary>
        /// Gets a mechanism to find elements by a web XAML type.
        /// </summary>
        /// <param name="xamlType">The XAML element type.</param>
        /// <returns>A <see cref="By"/> object the driver can use to find elements.</returns>
        public static By WebXamlType(string xamlType)
        {
            return By.XPath($".//*[@xamltype='{xamlType}']");
        }

        /// <summary>
        /// Gets a mechanism to find elements by a web XAML ID.
        /// </summary>
        /// <param name="xuid">The XAML element ID.</param>
        /// <returns>A <see cref="By"/> object the driver can use to find elements.</returns>
        public static By WebXamlAutomationId(string xuid)
        {
            return By.XPath($".//*[@xuid='{xuid}']");
        }

        /// <summary>
        /// Gets a mechanism to find elements by an Android XAML name.
        /// </summary>
        /// <param name="name">The XAML element name.</param>
        /// <returns>A <see cref="By"/> object the driver can use to find elements.</returns>
        public static By AndroidXamlName(string name)
        {
            return AndroidByExtras.ContentDescription(name);
        }

        /// <summary>
        /// Gets a mechanism to find elements by an Android XAML ID.
        /// </summary>
        /// <param name="xuid">The XAML element ID.</param>
        /// <returns>A <see cref="By"/> object the driver can use to find elements.</returns>
        public static By AndroidXamlAutomationId(string xuid)
        {
            return AndroidByExtras.ContentDescription(xuid);
        }

        /// <summary>
        /// Gets a mechanism to find elements by an Android content description.
        /// </summary>
        /// <param name="contentDesc">The content description to match exactly on.</param>
        /// <returns>A <see cref="By"/> object the driver can use to find elements.</returns>
        [Obsolete("AndroidContentDescription(string) will be removed in a future major release. Please use the AndroidByExtras.ContentDescription(string) instead.")]
        public static By AndroidContentDescription(string contentDesc)
        {
            return new ByAndroidUIAutomator(new AndroidUiSelector().DescriptionEquals(contentDesc));
        }

        /// <summary>
        /// Gets a mechanism to find elements by an Android partial content description.
        /// </summary>
        /// <param name="contentDesc">The partial content description to match on.</param>
        /// <returns>A <see cref="By"/> object the driver can use to find elements.</returns>
        [Obsolete("AndroidPartialContentDescription(string) will be removed in a future major release. Please use the AndroidByExtras.PartialContentDescription(string) instead.")]
        public static By AndroidPartialContentDescription(string contentDesc)
        {
            return new ByAndroidUIAutomator(new AndroidUiSelector().DescriptionContains(contentDesc));
        }

        /// <summary>
        /// Gets a mechanism to find elements by an iOS XAML ID.
        /// </summary>
        /// <param name="xuid">The XAML element ID.</param>
        /// <returns>A <see cref="By"/> object the driver can use to find elements.</returns>
        public static By IOSXamlAutomationId(string xuid)
        {
            return By.Name(xuid);
        }
    }
}