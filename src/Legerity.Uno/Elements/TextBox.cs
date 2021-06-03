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
    /// Defines a <see cref="RemoteWebElement"/> wrapper for the core TextBox control.
    /// </summary>
    public class TextBox : UnoElementWrapper
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TextBox"/> class.
        /// </summary>
        /// <param name="element">
        /// The <see cref="IWebElement"/> reference.
        /// </param>
        public TextBox(IWebElement element)
            : this(element as RemoteWebElement)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TextBox"/> class.
        /// </summary>
        /// <param name="element">
        /// The <see cref="RemoteWebElement"/> reference.
        /// </param>
        public TextBox(RemoteWebElement element)
            : base(element)
        {
        }

        /// <summary>
        /// Gets the text value of the text box.
        /// </summary>
        public string Text => this.DetermineText();

        /// <summary>
        /// Gets a value indicating whether the text box is in a readonly state.
        /// </summary>
        public bool IsReadonly => this.DetermineIsReadonly();

        private RemoteWebElement InputElement => this.DetermineInputElement();

        /// <summary>
        /// Allows conversion of a <see cref="RemoteWebElement"/> to the <see cref="TextBox"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="RemoteWebElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="TextBox"/>.
        /// </returns>
        public static implicit operator TextBox(RemoteWebElement element)
        {
            return new TextBox(element);
        }

        /// <summary>
        /// Sets the text of the text box to the specified text.
        /// </summary>
        /// <param name="text">The text to display.</param>
        public void SetText(string text)
        {
            this.ClearText();
            this.AppendText(text);
        }

        /// <summary>
        /// Appends the specified text to the text box.
        /// </summary>
        /// <param name="text">The text to append.</param>
        public void AppendText(string text)
        {
            this.InputElement.Click();
            this.InputElement.SendKeys(text);
        }

        /// <summary>
        /// Clears the text from the text box.
        /// </summary>
        public void ClearText()
        {
            this.InputElement.Click();
            this.InputElement.Clear();
        }

        private RemoteWebElement DetermineInputElement()
        {
            return this.Element switch
            {
                AndroidElement _ => this.Element,
                IOSElement _ => this.Element,
                WindowsElement _ => this.Element,
                _ => this.Element.FindWebElementByXamlType("Windows.UI.Xaml.Controls.TextBoxView")
            };
        }

        private string DetermineText()
        {
            return this.Element switch
            {
                AndroidElement _ => this.InputElement.Text ?? string.Empty,
                IOSElement _ => this.InputElement.Text ?? string.Empty,
                WindowsElement _ => this.InputElement.GetAttribute("Value.Value") ?? string.Empty,
                _ => this.InputElement.GetAttribute("value") ?? string.Empty
            };
        }

        private bool DetermineIsReadonly()
        {
            return this.Element switch
            {
                AndroidElement _ => !this.InputElement.Enabled,
                IOSElement _ => !this.InputElement.Enabled,
                WindowsElement _ =>
                    this.InputElement.GetAttribute("Value.IsReadonly").Equals("True", StringComparison.CurrentCultureIgnoreCase),
                _ => !string.IsNullOrWhiteSpace(this.InputElement.GetAttribute("readonly"))
            };
        }
    }
}