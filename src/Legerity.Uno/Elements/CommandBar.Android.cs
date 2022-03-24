namespace Legerity.Uno.Elements
{
    using OpenQA.Selenium;

    public partial class CommandBar
    {
        private static By PrimaryAppBarButtonItemLocatorAndroid()
        {
            return By.XPath(".//*[@content-desc='PrimaryItemsControl']/android.view.ViewGroup/android.view.ViewGroup/child::*");
        }

        private static By SecondaryAppBarButtonItemLocatorAndroid()
        {
            return By.XPath(".//*[@content-desc='ItemsPresenter']/android.view.ViewGroup/child::*");
        }

        private static By SecondaryOverflowButtonLocatorAndroid()
        {
            return ByExtras.AndroidXamlAutomationId("EllipsisIcon");
        }

        private static By SecondaryOverflowPopupLocatorAndroid()
        {
            return ByExtras.AndroidXamlAutomationId("OverflowContentRoot");
        }
    }
}