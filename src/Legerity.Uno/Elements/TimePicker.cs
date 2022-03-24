namespace Legerity.Uno.Elements
{
    using System;
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
            RemoteWebElement popup = this.Driver.FindWebElement(this.FlyoutLocator());
            this.FindSelectorChildElementByValue(popup.FindWebElement(this.HourSelectorLocator()), time.ToString("%h")).Click();
            this.FindSelectorChildElementByValue(popup.FindWebElement(this.MinuteSelectorLocator()), time.ToString("mm")).Click();
            popup.FindWebElement(this.AcceptButtonLocator()).Click();
        }

        private TimeSpan? DetermineSelectedTime()
        {
            string hour;
            string minute;

            (hour, minute) = this.Element switch
            {
                AndroidElement _ => this.DetermineSelectedTimeAndroid(),
                IOSElement _ => this.DetermineSelectedTimeIOS(),
                WindowsElement _ => this.DetermineSelectedTimeWindows(),
                _ => this.DetermineSelectedTimeWasm()
            };

            return string.IsNullOrWhiteSpace(hour) ||
                   string.IsNullOrWhiteSpace(minute) ?
                default :
                TimeSpan.TryParse($"{hour}:{minute}", out TimeSpan time) ? time : default(TimeSpan?);
        }

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
}