namespace Legerity.Uno.Elements
{
    using Legerity.Uno.Extensions;
    using Legerity.Web.Extensions;
    using OpenQA.Selenium.Remote;

    public partial class TextBox
    {
        private RemoteWebElement DetermineInputElementWasm()
        {
            return this.FindWebElementByXamlType("Windows.UI.Xaml.Controls.TextBoxView");
        }

        private string DetermineTextWasm()
        {
            return this.InputElement.GetValue() ?? string.Empty;
        }

        private bool DetermineIsReadonlyWasm()
        {
            return !string.IsNullOrWhiteSpace(this.InputElement.GetAttribute("readonly"));
        }
    }
}