namespace Legerity.Uno.Elements
{
    using System;
    using OpenQA.Selenium;

    public partial class CheckBox
    {
        private bool DetermineIsCheckedIOS()
        {
            try
            {
                return this.FindElement(ByExtras.IOSXamlAutomationId(CheckBoxGlyphName)) != null;
            }
            catch (WebDriverException)
            {
                return false;
            }
        }

        private bool DetermineIsIndeterminateIOS()
        {
            throw new NotImplementedException(
                "An implementation for iOS has not been implemented yet.");
        }
    }
}