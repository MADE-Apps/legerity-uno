namespace Legerity.Uno.Elements
{
    using OpenQA.Selenium.Remote;

    public partial class TextBox
    {
        private RemoteWebElement DetermineInputElementIOS()
        {
            return this.Element;
        }

        private string DetermineTextIOS()
        {
            return this.InputElement.Text ?? string.Empty;
        }

        private bool DetermineIsReadonlyIOS()
        {
            return !this.InputElement.Enabled;
        }
    }
}