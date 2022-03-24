namespace Legerity.Uno.Elements
{
    using System;
    using OpenQA.Selenium;

    public partial class CheckBox
    {
        private bool DetermineIsCheckedAndroid()
        {
            try
            {
                return this.Element.FindElement(ByExtras.AndroidXamlAutomationId("CheckGlyph")) != null;
            }
            catch (WebDriverException)
            {
                return false;
            }
        }

        private bool DetermineIsIndeterminateAndroid()
        {
            throw new NotImplementedException(
                "An implementation for Android has not been implemented yet.");
        }
    }
}