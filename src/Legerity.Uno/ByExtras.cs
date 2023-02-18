// MADE Apps licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Legerity.Uno;

using Legerity.Android;
using OpenQA.Selenium;

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
    /// Gets a mechanism to find elements by an iOS XAML ID.
    /// </summary>
    /// <param name="xuid">The XAML element ID.</param>
    /// <returns>A <see cref="By"/> object the driver can use to find elements.</returns>
    public static By IOSXamlAutomationId(string xuid)
    {
        return By.Name(xuid);
    }
}