namespace Legerity.Uno.Elements
{
    using Legerity.Extensions;
    using Legerity.IOS.Extensions;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Remote;

    public partial class TextBox
    {
        private RemoteWebElement DetermineInputElementIOS()
        {
            return this.FindWebElement(By.ClassName("XCUIElementTypeTextField"));
        }

        private string DetermineTextIOS()
        {
            return this.InputElement.GetValue() ?? string.Empty;
        }

        private bool DetermineIsReadonlyIOS()
        {
            return !this.InputElement.Enabled;
        }
    }
}