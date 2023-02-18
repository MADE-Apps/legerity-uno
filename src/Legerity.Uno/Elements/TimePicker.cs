// MADE Apps licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Legerity.Uno.Elements;

using System;
using Exceptions;
using Legerity.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.iOS;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;

/// <summary>
/// Defines a <see cref="RemoteWebElement"/> wrapper for the core TimePicker control.
/// </summary>
public partial class TimePicker : UnoElementWrapper
{
    private const string HourLoopingSelectorName = "HourLoopingSelector";
    private const string MinuteLoopingSelectorName = "MinuteLoopingSelector";
    private const string AcceptButtonName = "AcceptButton";

    /// <summary>
    /// Initializes a new instance of the <see cref="TimePicker"/> class.
    /// </summary>
    /// <param name="element">
    /// The <see cref="IWebElement"/> reference.
    /// </param>
    public TimePicker(IWebElement element)
        : this(element as RemoteWebElement)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="TimePicker"/> class.
    /// </summary>
    /// <param name="element">
    /// The <see cref="RemoteWebElement"/> reference.
    /// </param>
    public TimePicker(RemoteWebElement element)
        : base(element)
    {
    }

    /// <summary>
    /// Gets the time value of the time picker.
    /// </summary>
    /// <exception cref="AndroidNotImplementedException">Thrown when called on Android.</exception>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when the target element is no longer valid in the document DOM.</exception>
    /// <exception cref="IOSNotImplementedException">Thrown when called on iOS.</exception>
    public virtual TimeSpan? SelectedTime => this.DetermineSelectedTime();

    /// <summary>
    /// Allows conversion of a <see cref="RemoteWebElement"/> to the <see cref="TimePicker"/> without direct casting.
    /// </summary>
    /// <param name="element">
    /// The <see cref="RemoteWebElement"/>.
    /// </param>
    /// <returns>
    /// The <see cref="TimePicker"/>.
    /// </returns>
    public static implicit operator TimePicker(RemoteWebElement element)
    {
        return new TimePicker(element);
    }

    /// <summary>
    /// Sets the time to the specified time.
    /// </summary>
    /// <param name="time">The time to set.</param>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="ElementNotVisibleException">Thrown when an element is not visible.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    /// <exception cref="AndroidNotImplementedException">Thrown when called on Android.</exception>
    /// <exception cref="IOSNotImplementedException">Thrown when called on iOS.</exception>
    public virtual void SetTime(TimeSpan time)
    {
        // Taps the picker to show the popup.
        this.Click();

        // Finds the popup and change values.
        RemoteWebElement popup = this.Driver.FindWebElement(this.FlyoutLocator());
        this.FindSelectorChildElementByValue(popup.FindWebElement(this.HourSelectorLocator()), time.ToString("%h"))
            .Click();
        this.FindSelectorChildElementByValue(popup.FindWebElement(this.MinuteSelectorLocator()), time.ToString("mm"))
            .Click();
        popup.FindWebElement(this.AcceptButtonLocator()).Click();
    }

    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when the target element is no longer valid in the document DOM.</exception>
    /// <exception cref="IOSNotImplementedException">Thrown when called on iOS.</exception>
    /// <exception cref="AndroidNotImplementedException">Thrown when called on Android.</exception>
    private TimeSpan? DetermineSelectedTime()
    {
        (string hour, string minute) = this.Element switch
        {
            AndroidElement _ => this.DetermineSelectedTimeAndroid(),
            IOSElement _ => this.DetermineSelectedTimeIOS(),
            WindowsElement _ => this.DetermineSelectedTimeWindows(),
            _ => this.DetermineSelectedTimeWasm()
        };

        return string.IsNullOrWhiteSpace(hour) ||
               string.IsNullOrWhiteSpace(minute) ? default :
            TimeSpan.TryParse($"{hour}:{minute}", out TimeSpan time) ? time : default(TimeSpan?);
    }

    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    /// <exception cref="IOSNotImplementedException">Thrown when called on iOS.</exception>
    /// <exception cref="AndroidNotImplementedException">Thrown when called on Android.</exception>
    private IWebElement FindSelectorChildElementByValue(RemoteWebElement element, string value)
    {
        return this.Element switch
        {
            AndroidElement _ => FindSelectorChildElementByValueAndroid(element, value),
            IOSElement _ => FindSelectorChildElementByValueIOS(element, value),
            WindowsElement _ => FindSelectorChildElementByValueWindows(element, value),
            _ => FindSelectorChildElementByValueWasm(element, value)
        };
    }

    /// <exception cref="AndroidNotImplementedException">Thrown when called on Android.</exception>
    /// <exception cref="IOSNotImplementedException">Thrown when called on iOS.</exception>
    private By FlyoutLocator()
    {
        return this.Element switch
        {
            AndroidElement _ => FlyoutLocatorAndroid(),
            IOSElement _ => FlyoutLocatorIOS(),
            WindowsElement _ => FlyoutLocatorWindows(),
            _ => FlyoutLocatorWasm()
        };
    }

    /// <exception cref="AndroidNotImplementedException">Thrown when called on Android.</exception>
    /// <exception cref="IOSNotImplementedException">Thrown when called on iOS.</exception>
    private By HourSelectorLocator()
    {
        return this.Element switch
        {
            AndroidElement _ => HourSelectorLocatorAndroid(),
            IOSElement _ => HourSelectorLocatorIOS(),
            WindowsElement _ => HourSelectorLocatorWindows(),
            _ => HourSelectorLocatorWasm()
        };
    }

    /// <exception cref="AndroidNotImplementedException">Thrown when called on Android.</exception>
    /// <exception cref="IOSNotImplementedException">Thrown when called on iOS.</exception>
    private By MinuteSelectorLocator()
    {
        return this.Element switch
        {
            AndroidElement _ => MinuteSelectorLocatorAndroid(),
            IOSElement _ => MinuteSelectorLocatorIOS(),
            WindowsElement _ => MinuteSelectorLocatorWindows(),
            _ => MinuteSelectorLocatorWasm()
        };
    }

    /// <exception cref="AndroidNotImplementedException">Thrown when called on Android.</exception>
    /// <exception cref="IOSNotImplementedException">Thrown when called on iOS.</exception>
    private By AcceptButtonLocator()
    {
        return this.Element switch
        {
            AndroidElement _ => AcceptButtonLocatorAndroid(),
            IOSElement _ => AcceptButtonLocatorIOS(),
            WindowsElement _ => AcceptButtonLocatorWindows(),
            _ => AcceptButtonLocatorWasm()
        };
    }
}