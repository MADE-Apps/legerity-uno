namespace Legerity.Uno.Elements
{
    using Legerity.Windows.Elements.Core;
    using Legerity.Windows.Extensions;

    public partial class AppBarToggleButton
    {
        private bool DetermineIsOnWindows()
        {
            return this.GetToggleState() == ToggleState.Checked;
        }
    }
}