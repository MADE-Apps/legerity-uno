namespace Legerity.Uno.Elements
{
    public partial class CheckBox
    {
        private bool DetermineIsCheckedWindows()
        {
            return this.Element.GetAttribute("Toggle.ToggleState") == CheckedValue;
        }

        private bool DetermineIsIndeterminateWindows()
        {
            return this.Element.GetAttribute("Toggle.ToggleState") == IndeterminateValue;
        }
    }
}
