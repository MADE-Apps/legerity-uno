// MADE Apps licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Legerity.Uno.Elements;

using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

/// <summary>
/// Defines a <see cref="RemoteWebElement"/> wrapper for the core AppBarButton control.
/// </summary>
public class AppBarButton : Button
{
    /// <summary>
    /// Defines the Windows type for the <see cref="AppBarButton"/>.
    /// </summary>
    public new const string WindowsType = "Windows.UI.Xaml.Controls.AppBarButton";

    /// <summary>
    /// Initializes a new instance of the <see cref="AppBarButton"/> class.
    /// </summary>
    /// <param name="element">
    /// The <see cref="IWebElement"/> reference.
    /// </param>
    public AppBarButton(IWebElement element)
        : this(element as RemoteWebElement)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="AppBarButton"/> class.
    /// </summary>
    /// <param name="element">
    /// The <see cref="RemoteWebElement"/> reference.
    /// </param>
    public AppBarButton(RemoteWebElement element)
        : base(element)
    {
    }

    /// <summary>
    /// Allows conversion of a <see cref="RemoteWebElement"/> to the <see cref="AppBarButton"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="RemoteWebElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="AppBarButton"/>.
    /// </returns>
    public static implicit operator AppBarButton(RemoteWebElement element)
    {
        return new AppBarButton(element);
    }
}