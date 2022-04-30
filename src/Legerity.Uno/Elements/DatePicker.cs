namespace Legerity.Uno.Elements
{
    using System;
    using Legerity.Extensions;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Appium.Android;
    using OpenQA.Selenium.Appium.iOS;
    using OpenQA.Selenium.Appium.Windows;
    using OpenQA.Selenium.Internal;
    using OpenQA.Selenium.Remote;

    /// <summary>
    /// Defines a <see cref="RemoteWebElement"/> wrapper for the core DatePicker control.
    /// </summary>
    public partial class DatePicker : UnoElementWrapper
    {
        private const string DayLoopingSelectorName = "DayLoopingSelector";
        private const string MonthLoopingSelectorName = "MonthLoopingSelectorName";
        private const string YearLoopingSelectorName = "YearLoopingSelectorName";
        private const string AcceptButtonName = "AcceptButton";

        /// <summary>
        /// Initializes a new instance of the <see cref="DatePicker"/> class.
        /// </summary>
        /// <param name="element">
        /// The <see cref="IWebElement"/> reference.
        /// </param>
        public DatePicker(IWebElement element)
            : this(element as RemoteWebElement)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DatePicker"/> class.
        /// </summary>
        /// <param name="element">
        /// The <see cref="RemoteWebElement"/> reference.
        /// </param>
        public DatePicker(RemoteWebElement element)
            : base(element)
        {
        }

        /// <summary>
        /// Gets the date value of the date picker.
        /// </summary>
        public DateTime? SelectedDate => this.DetermineSelectedDate();

        /// <summary>
        /// Allows conversion of a <see cref="RemoteWebElement"/> to the <see cref="DatePicker"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="RemoteWebElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="DatePicker"/>.
        /// </returns>
        public static implicit operator DatePicker(RemoteWebElement element)
        {
            return new DatePicker(element);
        }

        /// <summary>
        /// Sets the date to the specified date.
        /// </summary>
        /// <param name="date">The date to set.</param>
        public virtual void SetDate(DateTime date)
        {
            // Taps the picker to show the popup.
            this.Click();

            // Finds the popup and change values.
            RemoteWebElement popup = this.Driver.FindWebElement(this.FlyoutLocator());
            this.FindSelectorChildElementByValue(popup.FindWebElement(this.DaySelectorLocator()), date.ToString("%d")).Click();
            this.FindSelectorChildElementByValue(popup.FindWebElement(this.MonthSelectorLocator()), date.ToString("MMMM")).Click();
            this.FindSelectorChildElementByValue(popup.FindWebElement(this.YearSelectorLocator()), date.ToString("yyyy")).Click();
            popup.FindWebElement(this.AcceptButtonLocator()).Click();
        }

        private DateTime? DetermineSelectedDate()
        {
            string day;
            string month;
            string year;

            (day, month, year) = this.Element switch
            {
                AndroidElement _ => this.DetermineSelectedDateAndroid(),
                IOSElement _ => this.DetermineSelectedDateIOS(),
                WindowsElement _ => this.DetermineSelectedDateWindows(),
                _ => this.DetermineSelectedDateWasm()
            };

            return string.IsNullOrWhiteSpace(day) ||
                   string.IsNullOrWhiteSpace(month) ||
                   string.IsNullOrWhiteSpace(year) ? default :
                DateTime.TryParse($"{day} {month} {year}", out DateTime date) ? date : default(DateTime?);
        }

        private IWebElement FindSelectorChildElementByValue(IFindsByName element, string value)
        {
            return this.Element switch
            {
                AndroidElement _ => FindSelectorChildElementByValueAndroid(element, value),
                IOSElement _ => FindSelectorChildElementByValueIOS(element, value),
                WindowsElement _ => FindSelectorChildElementByValueWindows(element, value),
                _ => FindSelectorChildElementByValueWasm(element, value),
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

        private By DaySelectorLocator()
        {
            return this.Element switch
            {
                AndroidElement _ => DaySelectorLocatorAndroid(),
                IOSElement _ => DaySelectorLocatorIOS(),
                WindowsElement _ => DaySelectorLocatorWindows(),
                _ => DaySelectorLocatorWasm()
            };
        }

        private By MonthSelectorLocator()
        {
            return this.Element switch
            {
                AndroidElement _ => MonthSelectorLocatorAndroid(),
                IOSElement _ => MonthSelectorLocatorIOS(),
                WindowsElement _ => MonthSelectorLocatorWindows(),
                _ => MonthSelectorLocatorWasm()
            };
        }

        private By YearSelectorLocator()
        {
            return this.Element switch
            {
                AndroidElement _ => YearSelectorLocatorAndroid(),
                IOSElement _ => YearSelectorLocatorIOS(),
                WindowsElement _ => YearSelectorLocatorWindows(),
                _ => YearSelectorLocatorWasm()
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