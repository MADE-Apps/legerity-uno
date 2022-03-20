namespace Legerity.Uno.Elements
{
    using Legerity.Uno.Extensions;
    using OpenQA.Selenium;

    public partial class CommandBar
    {
        private static By AppBarButtonItemLocatorWasm()
        {
            return ByExtensions.WebXamlType(AppBarButton.WindowsType);
        }

        private static By SecondaryOverflowPopupLocatorWasm()
        {
            return ByExtensions.WebXamlName("OverflowContentRoot");
        }

        private static By SecondaryOverflowButtonLocatorWasm()
        {
            return ByExtensions.WebXamlName(MoreButtonName);
        }
    }
}