namespace Legerity.Uno.Elements
{
    using Legerity.Extensions;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Remote;

    public partial class TextBox
    {
        private RemoteWebElement DetermineInputElementAndroid()
        {
            return this.FindWebElement(By.ClassName("android.widget.EditText"));
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