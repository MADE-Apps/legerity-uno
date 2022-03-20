namespace Legerity.Uno.Elements
{
    using System;
    using System.Linq;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Remote;

    public partial class ComboBox
    {
        private static By ComboBoxItemLocatorWindows()
        {
            return By.ClassName("ComboBoxItem");
        }

        private RemoteWebElement DetermineListElementWindows(string name)
        {
            return this.FindElements(this.ComboBoxItemLocator())
                .FirstOrDefault(e => e.GetAttribute("Name").Equals(name, StringComparison.CurrentCultureIgnoreCase));
        }

        private string DetermineSelectedItemWindows()
        {
            return this.FindElements(this.ComboBoxItemLocator()).FirstOrDefault()?.GetAttribute("Name");
        }
    }
}