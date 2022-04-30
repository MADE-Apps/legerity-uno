namespace Legerity.Uno.Elements
{
    using Legerity.Windows.Elements.Core;
    using Legerity.Windows.Extensions;

    public partial class CheckBox
    {
        private bool DetermineIsCheckedWindows()
        {
            return this.GetToggleState() == ToggleState.Checked;
        }

        private bool DetermineIsIndeterminateWindows()
        {
            return this.GetToggleState() == ToggleState.Indeterminate;
        }
    }
}