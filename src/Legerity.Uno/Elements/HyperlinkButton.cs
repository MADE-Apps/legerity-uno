// MADE Apps licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Legerity.Uno.Elements;

using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

/// <summary>
/// Defines a <see cref="RemoteWebElement"/> wrapper for the core HyperlinkButton control.
/// </summary>
public class HyperlinkButton : Button
{
    /// <summary>
    /// Defines the Windows type for the <see cref="HyperlinkButton"/>.
    /// </summary>
    public new const string WindowsType = "Windows.UI.Xaml.Controls.HyperlinkButton";

    /// <summary>
    /// Initializes a new instance of the <see cref="HyperlinkButton"/> class.
    /// </summary>
    /// <param name="element">
    /// The <see cref="IWebElement"/> reference.
    /// </param>
    public HyperlinkButton(IWebElement element)
        : this(element as RemoteWebElement)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="HyperlinkButton"/> class.
    /// </summary>
    /// <param name="element">
    /// The <see cref="RemoteWebElement"/> reference.
    /// </param>
    public HyperlinkButton(RemoteWebElement element)
        : base(element)
    {
    }

    /// <summary>
    /// Allows conversion of a <see cref="RemoteWebElement"/> to the <see cref="HyperlinkButton"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="RemoteWebElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="HyperlinkButton"/>.
    /// </returns>
    public static implicit operator HyperlinkButton(RemoteWebElement element)
    {
        return new HyperlinkButton(element);
    }
}