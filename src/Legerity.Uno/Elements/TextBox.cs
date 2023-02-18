// MADE Apps licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Legerity.Uno.Elements;

using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.iOS;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;

/// <summary>
/// Defines a <see cref="RemoteWebElement"/> wrapper for the core TextBox control.
/// </summary>
public partial class TextBox : UnoElementWrapper
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TextBox"/> class.
    /// </summary>
    /// <param name="element">
    /// The <see cref="IWebElement"/> reference.
    /// </param>
    public TextBox(IWebElement element)
        : this(element as RemoteWebElement)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="TextBox"/> class.
    /// </summary>
    /// <param name="element">
    /// The <see cref="RemoteWebElement"/> reference.
    /// </param>
    public TextBox(RemoteWebElement element)
        : base(element)
    {
    }

    /// <summary>
    /// Gets the text value of the text box.
    /// </summary>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual string Text => this.DetermineText();

    /// <summary>
    /// Gets a value indicating whether the text box is in a readonly state.
    /// </summary>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual bool IsReadonly => this.DetermineIsReadonly();

    /// <summary>
    /// Gets the element associated with the text box input.
    /// </summary>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public virtual RemoteWebElement InputElement => this.DetermineInputElement();

    /// <summary>
    /// Allows conversion of a <see cref="RemoteWebElement"/> to the <see cref="TextBox"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="RemoteWebElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="TextBox"/>.
    /// </returns>
    public static implicit operator TextBox(RemoteWebElement element)
    {
        return new TextBox(element);
    }

    /// <summary>
    /// Sets the text of the text box to the specified text.
    /// </summary>
    /// <param name="text">The text to display.</param>
    /// <exception cref="StaleElementReferenceException">Thrown when the target element is no longer valid in the document DOM.</exception>
    /// <exception cref="InvalidElementStateException">Thrown when the target element is not enabled.</exception>
    /// <exception cref="ElementNotVisibleException">Thrown when the target element is not visible.</exception>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public virtual void SetText(string text)
    {
        this.ClearText();
        this.AppendText(text);
    }

    /// <summary>
    /// Appends the specified text to the text box.
    /// </summary>
    /// <param name="text">The text to append.</param>
    /// <exception cref="InvalidElementStateException">Thrown when the target element is not enabled.</exception>
    /// <exception cref="ElementNotVisibleException">Thrown when the target element is not visible.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when the target element is no longer valid in the document DOM.</exception>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public virtual void AppendText(string text)
    {
        this.InputElement.Click();
        this.InputElement.SendKeys(text);
    }

    /// <summary>
    /// Clears the text from the text box.
    /// </summary>
    /// <exception cref="InvalidElementStateException">Thrown when the target element is not enabled.</exception>
    /// <exception cref="ElementNotVisibleException">Thrown when the target element is not visible.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when the target element is no longer valid in the document DOM.</exception>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public virtual void ClearText()
    {
        this.InputElement.Click();
        this.InputElement.Clear();
    }

    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    private RemoteWebElement DetermineInputElement()
    {
        return this.Element switch
        {
            AndroidElement _ => this.DetermineInputElementAndroid(),
            IOSElement _ => this.DetermineInputElementIOS(),
            WindowsElement _ => this.DetermineInputElementWindows(),
            _ => this.DetermineInputElementWasm()
        };
    }

    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    private string DetermineText()
    {
        return this.Element switch
        {
            AndroidElement _ => this.DetermineTextAndroid(),
            IOSElement _ => this.DetermineTextIOS(),
            WindowsElement _ => this.DetermineTextWindows(),
            _ => this.DetermineTextWasm()
        };
    }

    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    private bool DetermineIsReadonly()
    {
        return this.Element switch
        {
            AndroidElement _ => this.DetermineIsReadonlyAndroid(),
            IOSElement _ => this.DetermineIsReadonlyIOS(),
            WindowsElement _ => this.DetermineIsReadonlyWindows(),
            _ => this.DetermineIsReadonlyWasm()
        };
    }
}