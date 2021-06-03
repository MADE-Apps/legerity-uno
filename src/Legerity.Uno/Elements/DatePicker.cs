namespace Legerity.Uno.Elements
{
    using System;
    using System.Text.RegularExpressions;
    using Legerity.Extensions;
    using Legerity.Uno.Extensions;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Appium.Android;
    using OpenQA.Selenium.Appium.iOS;
    using OpenQA.Selenium.Appium.Windows;
    using OpenQA.Selenium.Remote;

    /// <summary>
    /// Defines a <see cref="RemoteWebElement"/> wrapper for the core DatePicker control.
    /// </summary>
    public class DatePicker : UnoElementWrapper
    {
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
        public void SetDate(DateTime date)
        {
            // Taps the picker to show the popup.
            this.Element.Click();

            // Finds the popup and change values.
            RemoteWebElement popup = this.Driver.FindWebElement(this.FlyoutQuery());
            this.FindSelectorValue(popup.FindWebElement(this.DaySelectorQuery()), date.ToString("%d")).Click();
            this.FindSelectorValue(popup.FindWebElement(this.MonthSelectorQuery()), date.ToString("MMMM")).Click();
            this.FindSelectorValue(popup.FindWebElement(this.YearSelectorQuery()), date.ToString("yyyy")).Click();
            popup.FindWebElement(this.AcceptButtonQuery()).Click();
        }

        private DateTime? DetermineSelectedDate()
        {
            string day = string.Empty;
            string month = string.Empty;
            string year = string.Empty;

            switch (this.Element)
            {
                case AndroidElement _:
                    break;
                case IOSElement _:
                    break;
                case WindowsElement _:
                    string dateString = this.Element
                        .FindWebElement(Windows.Extensions.ByExtensions.AutomationId("FlyoutButton"))
                        .GetAttribute("Name")
                        .Replace("Pick a date ", string.Empty)
                        .Replace(" date picker", string.Empty)
                        .Replace(",", string.Empty);

                    day = new Regex("(\\d{2})").Match(dateString).Value.Trim();
                    month = new Regex("([a-zA-Z]+)").Match(dateString).Value;
                    year = new Regex("(\\d{4})").Match(dateString).Value.Trim();
                    break;
                default:
                    day = this.Element.FindElementByXamlName("DayTextBlock").Text;
                    month = this.Element.FindElementByXamlName("MonthTextBlock").Text;
                    year = this.Element.FindElementByXamlName("YearTextBlock").Text;
                    break;
            }

            return string.IsNullOrWhiteSpace(day) ||
                   string.IsNullOrWhiteSpace(month) ||
                   string.IsNullOrWhiteSpace(year) ?
                default :
                DateTime.TryParse($"{day} {month} {year}", out DateTime date) ? date : default(DateTime?);
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
                WindowsElement _ => Windows.Extensions.ByExtensions.AutomationId("DatePickerFlyoutPresenter"),
                _ => ByExtensions.WebXamlType("Windows.UI.Xaml.Controls.DatePickerFlyoutPresenter")
            };
        }

        private By DaySelectorQuery()
        {
            return this.Element switch
            {
                AndroidElement _ =>
                    throw new PlatformNotSupportedException(
                        "An implementation for Android has not been implemented yet."),
                IOSElement _ =>
                    throw new PlatformNotSupportedException(
                        "An implementation for iOS has not been implemented yet."),
                WindowsElement _ => Windows.Extensions.ByExtensions.AutomationId("DayLoopingSelector"),
                _ => ByExtensions.WebXamlName("DayLoopingSelector")
            };
        }

        private By MonthSelectorQuery()
        {
            return this.Element switch
            {
                AndroidElement _ =>
                    throw new PlatformNotSupportedException(
                        "An implementation for Android has not been implemented yet."),
                IOSElement _ =>
                    throw new PlatformNotSupportedException(
                        "An implementation for iOS has not been implemented yet."),
                WindowsElement _ => Windows.Extensions.ByExtensions.AutomationId("MonthLoopingSelector"),
                _ => ByExtensions.WebXamlName("MonthLoopingSelector")
            };
        }

        private By YearSelectorQuery()
        {
            return this.Element switch
            {
                AndroidElement _ =>
                    throw new PlatformNotSupportedException(
                        "An implementation for Android has not been implemented yet."),
                IOSElement _ =>
                    throw new PlatformNotSupportedException(
                        "An implementation for iOS has not been implemented yet."),
                WindowsElement _ => Windows.Extensions.ByExtensions.AutomationId("YearLoopingSelector"),
                _ => ByExtensions.WebXamlName("YearLoopingSelector")
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