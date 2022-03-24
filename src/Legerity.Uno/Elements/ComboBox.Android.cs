namespace Legerity.Uno.Elements
{
    using System.Linq;
    using Legerity.Extensions;
    using Legerity.Uno.Extensions;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Remote;

    public partial class ComboBox
    {
        private static By ComboBoxItemLocatorAndroid()
        {
            return ByExtras.AndroidXamlAutomationId("ScrollContentPresenter");
        }

        private RemoteWebElement DetermineListElementAndroid(string name)
        {
            return this.Driver.FindElement(this.ComboBoxItemLocator())
                .FindWebElement(ByExtras.AndroidPartialContentDescription(name));
        }

        private string DetermineSelectedItemAndroid()
        {
            return this.FindElement(ByExtras.AndroidXamlAutomationId("ContentPresenter"))
                ?.GetAllChildElements()
                ?.LastOrDefault()
                ?.GetContentDescription();
        }
    }
}