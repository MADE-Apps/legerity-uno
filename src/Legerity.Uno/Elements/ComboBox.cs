// MADE Apps licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Legerity.Uno.Elements;

using System;
using Legerity.Exceptions;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.iOS;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;

/// <summary>
/// Defines a <see cref="RemoteWebElement"/> wrapper for the core ComboBox control.
/// </summary>
public partial class ComboBox : UnoElementWrapper
{
    private const string ScrollContentPresenterName = "ScrollContentPresenter";

    private const string ContentPresenterName = "ContentPresenter";

    /// <summary>
    /// Initializes a new instance of the <see cref="ComboBox"/> class.
    /// </summary>
    /// <param name="element">
    /// The <see cref="IWebElement"/> reference.
    /// </param>
    public ComboBox(IWebElement element)
        : this(element as RemoteWebElement)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ComboBox"/> class.
    /// </summary>
    /// <param name="element">
    /// The <see cref="RemoteWebElement"/> reference.
    /// </param>
    public ComboBox(RemoteWebElement element)
        : base(element)
    {
    }

    /// <summary>
    /// Gets the currently selected item.
    /// </summary>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public virtual string SelectedItem => this.DetermineSelectedItem();

    /// <summary>
    /// Allows conversion of a <see cref="RemoteWebElement"/> to the <see cref="ComboBox"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="RemoteWebElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="ComboBox"/>.
    /// </returns>
    public static implicit operator ComboBox(RemoteWebElement element)
    {
        return new ComboBox(element);
    }

    /// <summary>
    /// Selects an item in the combo-box with the specified item name.
    /// </summary>
    /// <param name="name">
    /// The name of the item to select.
    /// </param>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="ElementNotVisibleException">Thrown when an element is not visible.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    /// <exception cref="ElementsNotShownException">Thrown when no elements are shown for the expected locator.</exception>
    public virtual void SelectItem(string name)
    {
        this.Click();
        this.VerifyElementsShown(this.ComboBoxItemLocator(), TimeSpan.FromSeconds(2));
        RemoteWebElement item = this.DetermineListElementByName(name);

        if (item == null)
        {
            throw new NoSuchElementException($"Unable to find {name} in the combo box.");
        }

        item.Click();
    }

    /// <summary>
    /// Selects an item in the combo-box with the specified partial item name.
    /// </summary>
    /// <param name="name">
    /// The partial name of the item to select.
    /// </param>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="ElementNotVisibleException">Thrown when an element is not visible.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    /// <exception cref="ElementsNotShownException">Thrown when no elements are shown for the expected locator.</exception>
    public virtual void SelectItemByPartialName(string name)
    {
        this.Click();
        this.VerifyElementsShown(this.ComboBoxItemLocator(), TimeSpan.FromSeconds(2));
        RemoteWebElement item = this.DetermineListElementByPartialName(name);

        if (item == null)
        {
            throw new NoSuchElementException($"Unable to find {name} in the combo box.");
        }

        item.Click();

    }

    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    private RemoteWebElement DetermineListElementByName(string name)
    {
        return this.Element switch
        {
            AndroidElement _ => this.DetermineListElementByNameAndroid(name),
            IOSElement _ => this.DetermineListElementByNameIOS(name),
            WindowsElement _ => this.DetermineListElementByNameWindows(name),
            _ => this.DetermineListElementByNameWasm(name)
        };
    }

    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    private RemoteWebElement DetermineListElementByPartialName(string name)
    {
        return this.Element switch
        {
            AndroidElement _ => this.DetermineListElementByPartialNameAndroid(name),
            IOSElement _ => this.DetermineListElementByPartialNameIOS(name),
            WindowsElement _ => this.DetermineListElementByPartialNameWindows(name),
            _ => this.DetermineListElementByPartialNameWasm(name)
        };
    }

    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    private string DetermineSelectedItem()
    {
        return this.Element switch
        {
            AndroidElement _ => this.DetermineSelectedItemAndroid(),
            IOSElement _ => this.DetermineSelectedItemIOS(),
            WindowsElement _ => this.DetermineSelectedItemWindows(),
            _ => this.DetermineSelectedItemWasm()
        };
    }

    private By ComboBoxItemLocator()
    {
        return this.Element switch
        {
            AndroidElement _ => ComboBoxItemLocatorAndroid(),
            IOSElement _ => ComboBoxItemLocatorIOS(),
            WindowsElement _ => ComboBoxItemLocatorWindows(),
            _ => ComboBoxItemLocatorWasm()
        };
    }
}