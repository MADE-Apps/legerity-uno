// MADE Apps licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Legerity.Uno.Elements;

using System;
using System.Collections.Generic;
using System.Linq;
using Legerity.Exceptions;
using Legerity.Extensions;
using Legerity.Uno.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.iOS;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;

/// <summary>
/// Defines a <see cref="RemoteWebElement"/> wrapper for the core CommandBar control.
/// </summary>
public partial class CommandBar : UnoElementWrapper
{
    private const string MoreButtonName = "MoreButton";

    private const string OverflowContentRootName = "OverflowContentRoot";

    /// <summary>
    /// Initializes a new instance of the <see cref="CommandBar"/> class.
    /// </summary>
    /// <param name="element">
    /// The <see cref="IWebElement"/> reference.
    /// </param>
    public CommandBar(IWebElement element)
        : this(element as RemoteWebElement)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="CommandBar"/> class.
    /// </summary>
    /// <param name="element">
    /// The <see cref="RemoteWebElement"/> reference.
    /// </param>
    public CommandBar(RemoteWebElement element)
        : base(element)
    {
    }

    /// <summary>
    /// Gets the collection of primary buttons.
    /// </summary>
    public virtual IEnumerable<AppBarButton> PrimaryButtons =>
        this.FindElements(this.PrimaryAppBarButtonItemLocator())
            .Select<RemoteWebElement, AppBarButton>(element => element);

    /// <summary>
    /// Gets the <see cref="AppBarButton"/> for opening the secondary button menu.
    /// </summary>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public virtual AppBarButton SecondaryMenuButton => this.Driver.FindWebElement(this.SecondaryOverflowButtonLocator());

    /// <summary>
    /// Gets the collection of secondary buttons.
    /// <para>
    /// Note, this property will only return a result when the secondary buttons are shown in the flyout.
    /// </para>
    /// </summary>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public virtual IEnumerable<AppBarButton> SecondaryButtons =>
        this.Driver.FindWebElement(this.SecondaryOverflowPopupLocator())
            .FindWebElements(this.SecondaryAppBarButtonItemLocator())
            .Select<RemoteWebElement, AppBarButton>(element => element);

    /// <summary>
    /// Allows conversion of a <see cref="RemoteWebElement"/> to the <see cref="CommandBar"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="RemoteWebElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="CommandBar"/>.
    /// </returns>
    public static implicit operator CommandBar(RemoteWebElement element)
    {
        return new CommandBar(element);
    }

    /// <summary>
    /// Clicks a primary button in the command bar with the specified button name.
    /// </summary>
    /// <param name="name">
    /// The name of the button to click.
    /// </param>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="ElementNotVisibleException">Thrown when an element is not visible.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public virtual void ClickPrimaryButton(string name)
    {
        AppBarButton item = this.PrimaryButtons.FirstOrDefault(
            element => element.Element.VerifyNameOrAutomationIdEquals(name));

        if (item == null)
        {
            throw new NoSuchElementException($"Unable to find primary button {name}.");
        }

        item.Click();
    }

    /// <summary>
    /// Clicks a primary button in the command bar with the specified partial button name.
    /// </summary>
    /// <param name="name">
    /// The partial name of the button to click.
    /// </param>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="ElementNotVisibleException">Thrown when an element is not visible.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual void ClickPrimaryButtonByPartialName(string name)
    {
        AppBarButton item = this.PrimaryButtons.FirstOrDefault(
            element => element.Element.VerifyNameOrAutomationIdContains(name));

        if (item == null)
        {
            throw new NoSuchElementException($"Unable to find primary button {name}.");
        }

        item.Click();
    }

    /// <summary>
    /// Clicks a secondary button in the command bar with the specified button name.
    /// </summary>
    /// <param name="name">
    /// The name of the button to click.
    /// </param>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="ElementNotVisibleException">Thrown when an element is not visible.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    /// <exception cref="ElementNotShownException">Thrown when an element is not shown for the expected locator.</exception>
    public virtual void ClickSecondaryButton(string name)
    {
        this.OpenSecondaryButtonMenu();

        AppBarButton secondaryButton = this.SecondaryButtons.FirstOrDefault(
            button => button.Element.VerifyNameOrAutomationIdEquals(name));

        if (secondaryButton == null)
        {
            throw new NoSuchElementException($"Unable to find secondary button {name}.");
        }

        secondaryButton.Click();
    }

    /// <summary>
    /// Clicks a secondary button in the command bar with the specified partial button name.
    /// </summary>
    /// <param name="name">
    /// The partial name of the button to click.
    /// </param>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="ElementNotVisibleException">Thrown when an element is not visible.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    /// <exception cref="ElementNotShownException">Thrown when an element is not shown for the expected locator.</exception>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public virtual void ClickSecondaryButtonByPartialName(string name)
    {
        this.OpenSecondaryButtonMenu();

        AppBarButton secondaryButton = this.SecondaryButtons.FirstOrDefault(
            button => button.Element.VerifyNameOrAutomationIdContains(name));

        if (secondaryButton == null)
        {
            throw new NoSuchElementException($"Unable to find secondary button {name}.");
        }

        secondaryButton.Click();
    }

    /// <summary>
    /// Opens the menu associated with the secondary button options.
    /// </summary>
    /// <exception cref="ElementNotShownException">Thrown when an element is not shown for the expected locator.</exception>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="ElementNotVisibleException">Thrown when an element is not visible.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public virtual void OpenSecondaryButtonMenu()
    {
        this.VerifyElementShown(this.SecondaryOverflowButtonLocator(), TimeSpan.FromSeconds(2));
        this.SecondaryMenuButton.Click();
        this.VerifyDriverElementShown(this.SecondaryOverflowPopupLocator(), TimeSpan.FromSeconds(2));
    }

    private By PrimaryAppBarButtonItemLocator()
    {
        return this.Element switch
        {
            AndroidElement _ => PrimaryAppBarButtonItemLocatorAndroid(),
            IOSElement _ => PrimaryAppBarButtonItemLocatorIOS(),
            WindowsElement _ => AppBarButtonItemLocatorWindows(),
            _ => AppBarButtonItemLocatorWasm()
        };
    }

    private By SecondaryAppBarButtonItemLocator()
    {
        return this.Element switch
        {
            AndroidElement _ => SecondaryAppBarButtonItemLocatorAndroid(),
            IOSElement _ => SecondaryAppBarButtonItemLocatorIOS(),
            WindowsElement _ => AppBarButtonItemLocatorWindows(),
            _ => AppBarButtonItemLocatorWasm()
        };
    }

    private By SecondaryOverflowButtonLocator()
    {
        return this.Element switch
        {
            AndroidElement _ => SecondaryOverflowButtonLocatorAndroid(),
            IOSElement _ => SecondaryOverflowButtonLocatorIOS(),
            WindowsElement _ => SecondaryOverflowButtonLocatorWindows(),
            _ => SecondaryOverflowButtonLocatorWasm()
        };
    }

    private By SecondaryOverflowPopupLocator()
    {
        return this.Element switch
        {
            AndroidElement _ => SecondaryOverflowPopupLocatorAndroid(),
            IOSElement _ => SecondaryOverflowPopupLocatorIOS(),
            WindowsElement _ => SecondaryOverflowPopupLocatorWindows(),
            _ => SecondaryOverflowPopupLocatorWasm()
        };
    }
}