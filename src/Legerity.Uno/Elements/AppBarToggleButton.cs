// MADE Apps licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Legerity.Uno.Elements;

using Exceptions;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.iOS;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;

/// <summary>
/// Defines a <see cref="RemoteWebElement"/> wrapper for the core AppBarToggleButton control.
/// </summary>
public partial class AppBarToggleButton : AppBarButton
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AppBarToggleButton"/> class.
    /// </summary>
    /// <param name="element">
    /// The <see cref="RemoteWebElement"/> reference.
    /// </param>
    public AppBarToggleButton(RemoteWebElement element)
        : base(element)
    {
    }

    /// <summary>
    /// Gets a value indicating whether the toggle button is in the on position.
    /// </summary>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    /// <exception cref="AndroidNotImplementedException">Thrown when called on Android.</exception>
    /// <exception cref="IOSNotImplementedException">Thrown when called on iOS.</exception>
    public virtual bool IsOn => this.DetermineIsOn();

    /// <summary>
    /// Allows conversion of a <see cref="RemoteWebElement"/> to the <see cref="AppBarToggleButton"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="RemoteWebElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="AppBarToggleButton"/>.
    /// </returns>
    public static implicit operator AppBarToggleButton(RemoteWebElement element)
    {
        return new AppBarToggleButton(element);
    }

    /// <summary>
    /// Toggles the button on.
    /// </summary>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="ElementNotVisibleException">Thrown when an element is not visible.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual void ToggleOn()
    {
        if (this.IsOn)
        {
            return;
        }

        this.Click();
    }

    /// <summary>
    /// Toggles the button off.
    /// </summary>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="ElementNotVisibleException">Thrown when an element is not visible.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual void ToggleOff()
    {
        if (!this.IsOn)
        {
            return;
        }

        this.Click();
    }

    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    /// <exception cref="AndroidNotImplementedException">Thrown when called on Android.</exception>
    /// <exception cref="IOSNotImplementedException">Thrown when called on iOS.</exception>
    private bool DetermineIsOn()
    {
        return this.Element switch
        {
            AndroidElement _ => this.DetermineIsOnAndroid(),
            IOSElement _ => this.DetermineIsOnIOS(),
            WindowsElement _ => this.DetermineIsOnWindows(),
            _ => this.DetermineIsOnWasm()
        };
    }
}