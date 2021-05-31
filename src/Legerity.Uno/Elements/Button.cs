namespace Legerity.Uno.Elements
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Remote;

    /// <summary>
    /// Defines a <see cref="RemoteWebElement"/> wrapper for the core Button control.
    /// </summary>
    public class Button : UnoElementWrapper
    {
        /// <summary>
        /// Defines the Windows type for the <see cref="Button"/>.
        /// </summary>
        public const string WindowsType = "Windows.UI.Xaml.Controls.Button";

        /// <summary>
        /// Initializes a new instance of the <see cref="Button"/> class.
        /// </summary>
        /// <param name="element">
        /// The <see cref="IWebElement"/> reference.
        /// </param>
        public Button(IWebElement element)
            : this(element as RemoteWebElement)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Button"/> class.
        /// </summary>
        /// <param name="element">
        /// The <see cref="RemoteWebElement"/> reference.
        /// </param>
        public Button(RemoteWebElement element)
            : base(element)
        {
        }

        /// <summary>
        /// Allows conversion of a <see cref="RemoteWebElement"/> to the <see cref="Button"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="RemoteWebElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="Button"/>.
        /// </returns>
        public static implicit operator Button(RemoteWebElement element)
        {
            return new Button(element);
        }

        /// <summary>
        /// Clicks the button.
        /// </summary>
        public void Click()
        {
            this.Element.Click();
        }
    }
}