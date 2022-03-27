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
    public partial class CommandBar : UnoElementWrapper
    {
        private const string MoreButtonName = "MoreButton";

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
            this.FindElements(this.PrimaryAppBarButtonItemLocator())
                .Select<RemoteWebElement, AppBarButton>(element => element);

        /// <summary>
        /// Gets the collection of secondary buttons.
        /// <para>
        /// Note, this property will only return a result when the secondary buttons are shown in the flyout.
        /// </para>
        /// </summary>
        public IEnumerable<AppBarButton> SecondaryButtons =>
            this.Driver.FindWebElement(this.SecondaryOverflowPopupLocator())
                .FindWebElements(this.SecondaryAppBarButtonItemLocator())
                .Select<RemoteWebElement, AppBarButton>(element => element);

        /// <summary>
        /// Gets the secondary (more) options button.
        /// </summary>
        public AppBarButton MoreButton => this.Driver.FindWebElement(this.SecondaryOverflowButtonLocator());

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
            this.VerifyElementShown(this.SecondaryOverflowButtonLocator(), TimeSpan.FromSeconds(2));

            this.MoreButton.Click();

            this.VerifyDriverElementShown(this.SecondaryOverflowPopupLocator(), TimeSpan.FromSeconds(2));

            AppBarButton secondaryButton = this.SecondaryButtons.FirstOrDefault(
                button => button.Element.VerifyNameOrAutomationIdEquals(name));

            secondaryButton.Click();
        }

        private By PrimaryAppBarButtonItemLocator()
        {
            return this.Element switch
            {
                AndroidElement _ => PrimaryAppBarButtonItemLocatorAndroid(),
                IOSElement _ => AppBarButtonItemLocatorIOS(),
                WindowsElement _ => AppBarButtonItemLocatorWindows(),
                _ => AppBarButtonItemLocatorWasm()
            };
        }

        private By SecondaryAppBarButtonItemLocator()
        {
            return this.Element switch
            {
                AndroidElement _ => SecondaryAppBarButtonItemLocatorAndroid(),
                IOSElement _ => AppBarButtonItemLocatorIOS(),
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
}