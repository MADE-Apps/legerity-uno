namespace Legerity.Uno.Elements
{
    public partial class AppBarToggleButton
    {
        private bool DetermineIsOnWindows()
        {
            return this.Element.GetAttribute("Toggle.ToggleState") == ToggleOnValue;
        }
    }
}