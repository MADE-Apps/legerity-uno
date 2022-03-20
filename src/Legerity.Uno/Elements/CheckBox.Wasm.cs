namespace Legerity.Uno.Elements
{
    using System;
    using Legerity.Uno.Extensions;

    public partial class CheckBox
    {
        private bool DetermineIsCheckedWasm()
        {
            return this.Element.FindElementByXamlName("CheckGlyph").Displayed;
        }

        private bool DetermineIsIndeterminateWasm()
        {
            throw new NotImplementedException(
                "An implementation for WASM has not been implemented yet.");
        }
    }
}