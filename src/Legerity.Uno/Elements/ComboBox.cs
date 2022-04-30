namespace Legerity.Uno.Elements
{
    using System;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Appium.Android;
    using OpenQA.Selenium.Appium.iOS;
    using OpenQA.Selenium.Appium.Windows;
    using OpenQA.Selenium.Remote;

    /// <summary>
    /// Defines a <see cref="RemoteWebElement"/> wrapper for the core ComboBox control.
    /// </summary>
    public partial class ComboBox : UnoElementWrapper
    {
        private const string ScrollContentPresenterName = "ScrollContentPresenter";

        private const string ContentPresenterName = "ContentPresenter";

        /// <summary>
        /// Initializes a new instance of the <see cref="ComboBox"/> class.
        /// </summary>
        /// <param name="element">
        /// The <see cref="IWebElement"/> reference.
        /// </param>
        public ComboBox(IWebElement element)
            : this(element as RemoteWebElement)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ComboBox"/> class.
        /// </summary>
        /// <param name="element">
        /// The <see cref="RemoteWebElement"/> reference.
        /// </param>
        public ComboBox(RemoteWebElement element)
            : base(element)
        {
        }

        /// <summary>
        /// Gets the currently selected item.
        /// </summary>
        public virtual string SelectedItem => this.DetermineSelectedItem();

        /// <summary>
        /// Allows conversion of a <see cref="RemoteWebElement"/> to the <see cref="ComboBox"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="RemoteWebElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="ComboBox"/>.
        /// </returns>
        public static implicit operator ComboBox(RemoteWebElement element)
        {
            return new ComboBox(element);
        }

        /// <summary>
        /// Selects an item in the combo-box with the specified item name.
        /// </summary>
        /// <param name="name">
        /// The name of the item to select.
        /// </param>
        public virtual void SelectItem(string name)
        {
            this.Click();

            this.VerifyElementsShown(this.ComboBoxItemLocator(), TimeSpan.FromSeconds(2));

            RemoteWebElement item = this.DetermineListElement(name);

            item.Click();
        }

        private RemoteWebElement DetermineListElement(string name)
        {
            return this.Element switch
            {
                AndroidElement _ => this.DetermineListElementAndroid(name),
                IOSElement _ => this.DetermineListElementIOS(name),
                WindowsElement _ => this.DetermineListElementWindows(name),
                _ => this.DetermineListElementWasm(name)
            };
        }

        private string DetermineSelectedItem()
        {
            return this.Element switch
            {
                AndroidElement _ => this.DetermineSelectedItemAndroid(),
                IOSElement _ => this.DetermineSelectedItemIOS(),
                WindowsElement _ => this.DetermineSelectedItemWindows(),
                _ => this.DetermineSelectedItemWasm()
            };
        }

        private By ComboBoxItemLocator()
        {
            return this.Element switch
            {
                AndroidElement _ => ComboBoxItemLocatorAndroid(),
                IOSElement _ => ComboBoxItemLocatorIOS(),
                WindowsElement _ => ComboBoxItemLocatorWindows(),
                _ => ComboBoxItemLocatorWasm()
            };
        }
    }
}