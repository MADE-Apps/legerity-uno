namespace Legerity.Uno.Elements
{
    using System;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Remote;

    public partial class ComboBox
    {
        private RemoteWebElement DetermineListElementIOS(string name)
        {
            throw new NotImplementedException(
                "An implementation for iOS has not been implemented yet.");
        }

        private string DetermineSelectedItemIOS()
        {
            throw new NotImplementedException(
                "An implementation for iOS has not been implemented yet.");
        }

        private By ComboBoxItemLocatorIOS()
        {
            throw new PlatformNotSupportedException(
                "An implementation for iOS has not been implemented yet.");
        }
    }
}