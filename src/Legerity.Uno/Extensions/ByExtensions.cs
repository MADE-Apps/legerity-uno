namespace Legerity.Uno.Extensions
{
    using OpenQA.Selenium;

    /// <summary>
    /// Defines a collection of extensions for <see cref="By"/>.
    /// </summary>
    public static class ByExtensions
    {
        /// <summary>
        /// Gets a mechanism to find elements by a web XAML name.
        /// </summary>
        /// <param name="name">The XAML element name.</param>
        /// <returns>The element query.</returns>
        public static By WebXamlName(string name)
        {
            return By.XPath($".//*[@xamlname='{name}']");
        }

        /// <summary>
        /// Gets a mechanism to find elements by a web XAML type.
        /// </summary>
        /// <param name="xamlType">The XAML element type.</param>
        /// <returns>The element query.</returns>
        public static By WebXamlType(string xamlType)
        {
            return By.XPath($".//*[@xamltype='{xamlType}']");
        }

        /// <summary>
        /// Gets a mechanism to find elements by a web XAML ID.
        /// </summary>
        /// <param name="xuid">The XAML element ID.</param>
        /// <returns>The element query.</returns>
        public static By WebXamlId(string xuid)
        {
            return By.XPath($".//*[@xuid='{xuid}']");
        }
    }
}