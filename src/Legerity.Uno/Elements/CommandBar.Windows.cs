namespace Legerity.Uno.Elements
{
    using Legerity.Windows;
    using OpenQA.Selenium;

    public partial class CommandBar
    {
        private static By AppBarButtonItemLocatorWindows()
        {
            return By.ClassName("AppBarButton");
        }

        private static By SecondaryOverflowPopupLocatorWindows()
        {
            return WindowsByExtras.AutomationId("OverflowPopup");
        }

        private static By SecondaryOverflowButtonLocatorWindows()
        {
            return WindowsByExtras.AutomationId(MoreButtonName);
        }
    }
}