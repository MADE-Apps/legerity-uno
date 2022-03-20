namespace Legerity.Uno.Elements
{
    using OpenQA.Selenium;

    public partial class CommandBar
    {
        private static By AppBarButtonItemLocatorWindows()
        {
            return By.ClassName("AppBarButton");
        }

        private static By SecondaryOverflowPopupLocatorWindows()
        {
            return Windows.Extensions.ByExtensions.AutomationId("OverflowPopup");
        }

        private static By SecondaryOverflowButtonLocatorWindows()
        {
            return Windows.Extensions.ByExtensions.AutomationId(MoreButtonName);
        }
    }
}