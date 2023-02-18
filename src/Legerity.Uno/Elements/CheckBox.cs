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
/// Defines a <see cref="RemoteWebElement"/> wrapper for the core CheckBox control.
/// </summary>
public partial class CheckBox : UnoElementWrapper
{
    private const string CheckBoxGlyphName = "CheckGlyph";

    /// <summary>
    /// Initializes a new instance of the <see cref="CheckBox"/> class.
    /// </summary>
    /// <param name="element">
    /// The <see cref="IWebElement"/> reference.
    /// </param>
    public CheckBox(IWebElement element)
        : this(element as RemoteWebElement)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="CheckBox"/> class.
    /// </summary>
    /// <param name="element">
    /// The <see cref="RemoteWebElement"/> reference.
    /// </param>
    public CheckBox(RemoteWebElement element)
        : base(element)
    {
    }

    /// <summary>
    /// Gets a value indicating whether the check box is in the checked state.
    /// </summary>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public virtual bool IsChecked => this.DetermineIsChecked();

    /// <summary>
    /// Gets a value indicating whether the check box is in the indeterminate state.
    /// </summary>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    /// <exception cref="AndroidNotImplementedException">Thrown when called on Android.</exception>
    /// <exception cref="IOSNotImplementedException">Thrown when called on iOS.</exception>
    /// <exception cref="WebNotImplementedException">Thrown when called on Web.</exception>
    public virtual bool IsIndeterminate => this.DetermineIsIndeterminate();

    /// <summary>
    /// Allows conversion of a <see cref="RemoteWebElement"/> to the <see cref="CheckBox"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="RemoteWebElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="CheckBox"/>.
    /// </returns>
    public static implicit operator CheckBox(RemoteWebElement element)
    {
        return new CheckBox(element);
    }

    /// <summary>
    /// Checks the check box on.
    /// </summary>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="ElementNotVisibleException">Thrown when an element is not visible.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual void CheckOn()
    {
        if (this.IsChecked)
        {
            return;
        }

        this.Click();
    }

    /// <summary>
    /// Checks the check box off.
    /// </summary>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="ElementNotVisibleException">Thrown when an element is not visible.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual void CheckOff()
    {
        if (!this.IsChecked)
        {
            return;
        }

        this.Click();
    }

    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    private bool DetermineIsChecked()
    {
        return this.Element switch
        {
            AndroidElement _ => this.DetermineIsCheckedAndroid(),
            IOSElement _ => this.DetermineIsCheckedIOS(),
            WindowsElement _ => this.DetermineIsCheckedWindows(),
            _ => this.DetermineIsCheckedWasm()
        };
    }

    /// <exception cref="AndroidNotImplementedException">Thrown when called on Android.</exception>
    /// <exception cref="IOSNotImplementedException">Thrown when called on iOS.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    /// <exception cref="WebNotImplementedException">Thrown when called on Web.</exception>
    private bool DetermineIsIndeterminate()
    {
        return this.Element switch
        {
            AndroidElement _ => this.DetermineIsIndeterminateAndroid(),
            IOSElement _ => this.DetermineIsIndeterminateIOS(),
            WindowsElement _ => this.DetermineIsIndeterminateWindows(),
            _ => this.DetermineIsIndeterminateWasm()
        };
    }
}