namespace Legerity.Uno.Elements
{
    using System;
    using System.Linq;
    using Legerity.Extensions;
    using Legerity.Uno.Extensions;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Remote;

    public partial class ComboBox
    {
        private static By ComboBoxItemLocatorWasm()
        {
            return ByExtras.WebXamlType("Windows.UI.Xaml.Controls.ComboBoxItem");
        }

        private RemoteWebElement DetermineListElementWasm(string name)
        {
            return this.Driver
                .FindWebElements(this.ComboBoxItemLocator())
                .SelectMany(element => element.FindWebElements(By.TagName("p")))
                .FirstOrDefault(element => element.Text.Equals(name, StringComparison.CurrentCultureIgnoreCase));
        }

        private string DetermineSelectedItemWasm()
        {
            return this.FindElements(ByExtras.WebXamlType("Windows.UI.Xaml.Controls.ContentPresenter"))
                .LastOrDefault()?
                .FindWebElement(By.TagName("p"))?
                .Text;
        }
    }
}