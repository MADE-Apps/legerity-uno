namespace Legerity.Uno.Elements
{
    using Extensions;

    public partial class AppBarToggleButton
    {
        private bool DetermineIsOnWasm()
        {
            return this.Element
                .FindElementByXamlName("OverflowCheckGlyph")
                .GetAttribute("style")
                .Contains("opacity") == false;
        }
    }
}