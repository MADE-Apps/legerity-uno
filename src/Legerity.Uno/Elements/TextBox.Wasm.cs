namespace Legerity.Uno.Elements
{
    using Legerity.Uno.Extensions;
    using OpenQA.Selenium.Remote;

    public partial class TextBox
    {
        private RemoteWebElement DetermineInputElementWasm()
        {
            return this.Element.FindWebElementByXamlType("Windows.UI.Xaml.Controls.TextBoxView");
        }

        private string DetermineTextWasm()
        {
            return this.InputElement.GetAttribute("value") ?? string.Empty;
        }

        private bool DetermineIsReadonlyWasm()
        {
            return !string.IsNullOrWhiteSpace(this.InputElement.GetAttribute("readonly"));
        }
    }
}