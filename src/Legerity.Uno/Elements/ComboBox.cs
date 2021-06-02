namespace Legerity.Uno.Elements
{
    using System;
    using System.Linq;
    using Legerity.Extensions;
    using Legerity.Uno.Extensions;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Appium.Android;
    using OpenQA.Selenium.Appium.iOS;
    using OpenQA.Selenium.Appium.Windows;
    using OpenQA.Selenium.Remote;

    /// <summary>
    /// Defines a <see cref="RemoteWebElement"/> wrapper for the core ComboBox control.
    /// </summary>
    public class ComboBox : UnoElementWrapper
    {
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
        public string SelectedItem => this.DetermineSelectedItem();

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
        public void SelectItem(string name)
        {
            this.Element.Click();

            this.VerifyElementsShown(this.ComboBoxItemQuery(), TimeSpan.FromSeconds(2));

            RemoteWebElement item = this.DetermineListElement(name);

            item.Click();
        }

        private RemoteWebElement DetermineListElement(string name)
        {
            return this.Element switch
            {
                AndroidElement _ => throw new NotImplementedException(),
                IOSElement _ => throw new NotImplementedException(),
                WindowsElement _ => this.Element
                    .FindWebElements(this.ComboBoxItemQuery())
                    .FirstOrDefault(element => element.GetAttribute("Name").Equals(name, StringComparison.CurrentCultureIgnoreCase)),
                _ => this.Driver
                    .FindWebElements(this.ComboBoxItemQuery())
                    .SelectMany(element => element.FindWebElements(By.TagName("p")))
                    .FirstOrDefault(element => element.Text.Equals(name, StringComparison.CurrentCultureIgnoreCase))
            };
        }

        private string DetermineSelectedItem()
        {
            return this.Element switch
            {
                AndroidElement _ => throw new NotImplementedException(),
                IOSElement _ => throw new NotImplementedException(),
                WindowsElement _ => this.Element.FindWebElements(this.ComboBoxItemQuery()).FirstOrDefault()?.GetAttribute("Name"),
                _ => this.Element.FindWebElements(ByExtensions.WebXamlType("Windows.UI.Xaml.Controls.ContentPresenter"))
                    .LastOrDefault()?
                    .FindWebElement(By.TagName("p"))?
                    .Text
            };
        }

        private By ComboBoxItemQuery()
        {
            return this.Element switch
            {
                AndroidElement _ =>
                    throw new PlatformNotSupportedException(
                        "An implementation for Android has not been implemented yet."),
                IOSElement _ =>
                    throw new PlatformNotSupportedException(
                        "An implementation for iOS has not been implemented yet."),
                WindowsElement _ => By.ClassName("ComboBoxItem"),
                _ => ByExtensions.WebXamlType("Windows.UI.Xaml.Controls.ComboBoxItem")
            };
        }
    }
}