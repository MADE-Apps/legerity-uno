namespace Legerity.Uno.Elements
{
    using System;
    using Legerity.Uno.Extensions;
    using OpenQA.Selenium.Appium.Android;
    using OpenQA.Selenium.Appium.iOS;
    using OpenQA.Selenium.Appium.Windows;
    using OpenQA.Selenium.Remote;

    /// <summary>
    /// Defines a <see cref="RemoteWebElement"/> wrapper for the core AppBarToggleButton control.
    /// </summary>
    public class AppBarToggleButton : AppBarButton
    {
        private const string ToggleOffValue = "0";

        private const string ToggleOnValue = "1";

        /// <summary>
        /// Initializes a new instance of the <see cref="AppBarToggleButton"/> class.
        /// </summary>
        /// <param name="element">
        /// The <see cref="RemoteWebElement"/> reference.
        /// </param>
        public AppBarToggleButton(RemoteWebElement element)
            : base(element)
        {
        }

        /// <summary>
        /// Gets a value indicating whether the toggle button is in the on position.
        /// </summary>
        public bool IsOn => this.DetermineIsOn();

        /// <summary>
        /// Allows conversion of a <see cref="RemoteWebElement"/> to the <see cref="AppBarToggleButton"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="RemoteWebElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="AppBarToggleButton"/>.
        /// </returns>
        public static implicit operator AppBarToggleButton(RemoteWebElement element)
        {
            return new AppBarToggleButton(element);
        }

        /// <summary>
        /// Toggles the button on.
        /// </summary>
        public void ToggleOn()
        {
            if (this.IsOn)
            {
                return;
            }

            this.Click();
        }

        /// <summary>
        /// Toggles the button off.
        /// </summary>
        public void ToggleOff()
        {
            if (!this.IsOn)
            {
                return;
            }

            this.Click();
        }

        private bool DetermineIsOn()
        {
            return this.Element switch
            {
                AndroidElement _ =>
                    throw new PlatformNotSupportedException(
                        "An implementation for Android has not been implemented yet."),
                IOSElement _ =>
                    throw new PlatformNotSupportedException(
                        "An implementation for iOS has not been implemented yet."),
                WindowsElement _ =>
                    this.Element.GetAttribute("Toggle.ToggleState") == ToggleOnValue,
                _ =>
                    this.Element.FindElementByXamlName("CheckedHighlightBackground")
                        .GetCssValue("opacity") != ToggleOffValue
            };
        }
    }
}