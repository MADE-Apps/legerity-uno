namespace Legerity.Uno.Elements
{
    using Legerity.Uno.Extensions;
    using OpenQA.Selenium;

    public partial class CommandBar
    {
        private static By AppBarButtonItemLocatorWasm()
        {
            return ByExtras.WebXamlType(AppBarButton.WindowsType);
        }

        private static By SecondaryOverflowPopupLocatorWasm()
        {
            return ByExtras.WebXamlName(OverflowContentRootName);
        }

        private static By SecondaryOverflowButtonLocatorWasm()
        {
            return ByExtras.WebXamlName(MoreButtonName);
        }
    }
}