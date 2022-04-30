namespace Legerity.Uno.Elements
{
    using System;
    using Legerity.Windows.Extensions;
    using OpenQA.Selenium.Remote;

    public partial class TextBox
    {
        private RemoteWebElement DetermineInputElementWindows()
        {
            return this.Element;
        }

        private string DetermineTextWindows()
        {
            return this.InputElement.GetValue() ?? string.Empty;
        }

        private bool DetermineIsReadonlyWindows()
        {
            return this.InputElement
                .GetAttribute("Value.IsReadonly")
                .Equals("True", StringComparison.CurrentCultureIgnoreCase);
        }
    }
}