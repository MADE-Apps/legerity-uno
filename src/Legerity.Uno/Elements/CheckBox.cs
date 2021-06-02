namespace Legerity.Uno.Elements
{
    using System;
    using Legerity.Uno.Extensions;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Appium.Android;
    using OpenQA.Selenium.Appium.iOS;
    using OpenQA.Selenium.Appium.Windows;
    using OpenQA.Selenium.Remote;

    /// <summary>
    /// Defines a <see cref="RemoteWebElement"/> wrapper for the core CheckBox control.
    /// </summary>
    public class CheckBox : UnoElementWrapper
    {
        private const string CheckedValue = "1";

        private const string IndeterminateValue = "2";

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
        public bool IsChecked => this.DetermineIsChecked();

        /// <summary>
        /// Gets a value indicating whether the check box is in the indeterminate state.
        /// </summary>
        public bool IsIndeterminate => this.Element.GetAttribute("Toggle.ToggleState") == IndeterminateValue;

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
        public void CheckOn()
        {
            if (this.IsChecked)
            {
                return;
            }

            this.Element.Click();
        }

        /// <summary>
        /// Checks the check box off.
        /// </summary>
        public void CheckOff()
        {
            if (!this.IsChecked)
            {
                return;
            }

            this.Element.Click();
        }

        private bool DetermineIsChecked()
        {
            return this.Element switch
            {
                AndroidElement _ =>
                    throw new PlatformNotSupportedException(
                        "An implementation for Android has not been implemented yet."),
                IOSElement _ =>
                    throw new PlatformNotSupportedException(
                        "An implementation for iOS has not been implemented yet."),
                WindowsElement _ => this.Element.GetAttribute("Toggle.ToggleState") == CheckedValue,
                _ => this.Element.FindElementByXamlName("CheckGlyph").Displayed
            };
        }
    }
}