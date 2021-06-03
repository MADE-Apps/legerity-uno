namespace Legerity.Uno.Elements
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
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
    public class CommandBar : UnoElementWrapper
    {
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
        public IEnumerable<AppBarButton> PrimaryButtons =>
            this.Element.FindWebElements(this.AppBarButtonItemQuery())
                .Select<RemoteWebElement, AppBarButton>(element => element);

        /// <summary>
        /// Gets the collection of secondary buttons.
        /// <para>
        /// Note, this property will only return a result when the secondary buttons are shown in the flyout.
        /// </para>
        /// </summary>
        public IEnumerable<AppBarButton> SecondaryButtons =>
            this.Driver.FindWebElement(this.SecondaryOverflowPopupQuery()).FindWebElements(this.AppBarButtonItemQuery())
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
        public void ClickPrimaryButton(string name)
        {
            AppBarButton item = this.PrimaryButtons.FirstOrDefault(
                element => element.Element.VerifyNameOrAutomationIdEquals(name));

            item.Click();
        }

        /// <summary>
        /// Clicks a secondary button in the command bar with the specified button name.
        /// </summary>
        /// <param name="name">
        /// The name of the button to click.
        /// </param>
        public void ClickSecondaryButton(string name)
        {
            this.VerifyElementShown(this.SecondaryOverflowButtonQuery(), TimeSpan.FromSeconds(2));

            AppBarButton secondaryOverflowButton = this.Element.FindWebElement(this.SecondaryOverflowButtonQuery());
            secondaryOverflowButton.Click();

            this.VerifyDriverElementShown(this.SecondaryOverflowPopupQuery(), TimeSpan.FromSeconds(2));

            AppBarButton secondaryButton = this.SecondaryButtons.FirstOrDefault(
                button => button.Element.VerifyNameOrAutomationIdEquals(name));

            secondaryButton.Click();
        }

        private By AppBarButtonItemQuery()
        {
            return this.Element switch
            {
                AndroidElement _ =>
                    throw new PlatformNotSupportedException(
                        "An implementation for Android has not been implemented yet."),
                IOSElement _ =>
                    throw new PlatformNotSupportedException(
                        "An implementation for iOS has not been implemented yet."),
                WindowsElement _ => By.ClassName("AppBarButton"),
                _ => ByExtensions.WebXamlType(AppBarButton.WindowsType)
            };
        }

        private By SecondaryOverflowButtonQuery()
        {
            return this.Element switch
            {
                AndroidElement _ =>
                    throw new PlatformNotSupportedException(
                        "An implementation for Android has not been implemented yet."),
                IOSElement _ =>
                    throw new PlatformNotSupportedException(
                        "An implementation for iOS has not been implemented yet."),
                WindowsElement _ => Windows.Extensions.ByExtensions.AutomationId("MoreButton"),
                _ => ByExtensions.WebXamlName("MoreButton")
            };
        }

        private By SecondaryOverflowPopupQuery()
        {
            return this.Element switch
            {
                AndroidElement _ =>
                    throw new PlatformNotSupportedException(
                        "An implementation for Android has not been implemented yet."),
                IOSElement _ =>
                    throw new PlatformNotSupportedException(
                        "An implementation for iOS has not been implemented yet."),
                WindowsElement _ => Windows.Extensions.ByExtensions.AutomationId("OverflowPopup"),
                _ => ByExtensions.WebXamlName("OverflowPopup")
            };
        }

    }
}