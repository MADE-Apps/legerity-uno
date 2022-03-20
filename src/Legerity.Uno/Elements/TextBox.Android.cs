namespace Legerity.Uno.Elements
{
    using OpenQA.Selenium.Remote;

    public partial class TextBox
    {
        private RemoteWebElement DetermineInputElementAndroid()
        {
            return this.Element;
        }

        private string DetermineTextAndroid()
        {
            return this.InputElement.Text ?? string.Empty;
        }

        private bool DetermineIsReadonlyAndroid()
        {
            return !this.InputElement.Enabled;
        }
    }
}