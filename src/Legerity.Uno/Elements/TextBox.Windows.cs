namespace Legerity.Uno.Elements
{
    using System;
    using OpenQA.Selenium.Remote;

    public partial class TextBox
    {
        private RemoteWebElement DetermineInputElementWindows()
        {
            return this.Element;
        }

        private string DetermineTextWindows()
        {
            return this.InputElement.GetAttribute("Value.Value") ?? string.Empty;
        }

        private bool DetermineIsReadonlyWindows()
        {
            return this.InputElement
                .GetAttribute("Value.IsReadonly")
                .Equals("True", StringComparison.CurrentCultureIgnoreCase);
        }
    }
}