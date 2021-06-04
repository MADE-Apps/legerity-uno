namespace Legerity.Uno.Elements
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;
    using Legerity.Extensions;
    using Legerity.Uno.Extensions;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Appium.Android;
    using OpenQA.Selenium.Appium.iOS;
    using OpenQA.Selenium.Appium.Windows;
    using OpenQA.Selenium.Remote;

    /// <summary>
    /// Defines a <see cref="RemoteWebElement"/> wrapper for the core TimePicker control.
    /// </summary>
    public class TimePicker : UnoElementWrapper
    {
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
        public TimeSpan? SelectedTime => this.DetermineSelectedTime();

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
        public void SetTime(TimeSpan time)
        {
            // Taps the picker to show the popup.
            this.Element.Click();

            // Finds the popup and change values.
            RemoteWebElement popup = this.Driver.FindWebElement(this.FlyoutQuery());
            this.FindSelectorValue(popup.FindWebElement(this.HourSelectorQuery()), time.ToString("%h")).Click();
            this.FindSelectorValue(popup.FindWebElement(this.MinuteSelectorQuery()), time.ToString("mm")).Click();
            popup.FindWebElement(this.AcceptButtonQuery()).Click();
        }

        private TimeSpan? DetermineSelectedTime()
        {
            string hour = string.Empty;
            string minute = string.Empty;

            switch (this.Element)
            {
                case AndroidElement _:
                    break;
                case IOSElement _:
                    break;
                case WindowsElement _:
                    string timeElementText = this.Element
                        .FindWebElement(Windows.Extensions.ByExtensions.AutomationId("FlyoutButton"))
                        .GetAttribute("Name")
                        .Replace(" time picker", string.Empty)
                        .Trim();

                    var regex = new Regex(@"\d+");

                    string[] timeString = timeElementText.Split(':');
                    hour = regex.Match(timeString.FirstOrDefault() ?? string.Empty).Value;
                    minute = regex.Match(timeString.LastOrDefault() ?? string.Empty).Value;
                    break;
                default:
                    hour = this.Element.FindElementByXamlName("HourTextBlock").Text;
                    minute = this.Element.FindElementByXamlName("MinuteTextBlock").Text;
                    break;
            }

            return string.IsNullOrWhiteSpace(hour) ||
                   string.IsNullOrWhiteSpace(minute) ?
                default :
                TimeSpan.TryParse($"{hour}:{minute}", out TimeSpan time) ? time : default(TimeSpan?);
        }

        private IWebElement FindSelectorValue(RemoteWebElement selector, string value)
        {
            return this.Element switch
            {
                AndroidElement _ =>
                    throw new PlatformNotSupportedException(
                        "An implementation for Android has not been implemented yet."),
                IOSElement _ =>
                    throw new PlatformNotSupportedException(
                        "An implementation for iOS has not been implemented yet."),
                WindowsElement _ => selector.FindElementByName(value),
                _ => selector.FindElementByText(value)
            };
        }

        private By FlyoutQuery()
        {
            return this.Element switch
            {
                AndroidElement _ =>
                    throw new PlatformNotSupportedException(
                        "An implementation for Android has not been implemented yet."),
                IOSElement _ =>
                    throw new PlatformNotSupportedException(
                        "An implementation for iOS has not been implemented yet."),
                WindowsElement _ => Windows.Extensions.ByExtensions.AutomationId("TimePickerFlyoutPresenter"),
                _ => ByExtensions.WebXamlType("Windows.UI.Xaml.Controls.TimePickerFlyoutPresenter")
            };
        }

        private By HourSelectorQuery()
        {
            return this.Element switch
            {
                AndroidElement _ =>
                    throw new PlatformNotSupportedException(
                        "An implementation for Android has not been implemented yet."),
                IOSElement _ =>
                    throw new PlatformNotSupportedException(
                        "An implementation for iOS has not been implemented yet."),
                WindowsElement _ => Windows.Extensions.ByExtensions.AutomationId("HourLoopingSelector"),
                _ => ByExtensions.WebXamlName("HourLoopingSelector")
            };
        }

        private By MinuteSelectorQuery()
        {
            return this.Element switch
            {
                AndroidElement _ =>
                    throw new PlatformNotSupportedException(
                        "An implementation for Android has not been implemented yet."),
                IOSElement _ =>
                    throw new PlatformNotSupportedException(
                        "An implementation for iOS has not been implemented yet."),
                WindowsElement _ => Windows.Extensions.ByExtensions.AutomationId("MinuteLoopingSelector"),
                _ => ByExtensions.WebXamlName("MinuteLoopingSelector")
            };
        }

        private By AcceptButtonQuery()
        {
            return this.Element switch
            {
                AndroidElement _ =>
                    throw new PlatformNotSupportedException(
                        "An implementation for Android has not been implemented yet."),
                IOSElement _ =>
                    throw new PlatformNotSupportedException(
                        "An implementation for iOS has not been implemented yet."),
                WindowsElement _ => Windows.Extensions.ByExtensions.AutomationId("AcceptButton"),
                _ => ByExtensions.WebXamlName("AcceptButton")
            };
        }
    }
}