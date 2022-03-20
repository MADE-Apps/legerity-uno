namespace Legerity.Uno.Elements
{
    using System;
    using Legerity.Uno.Extensions;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Internal;

    public partial class DatePicker
    {
        private static By FlyoutLocatorWasm()
        {
            return ByExtensions.WebXamlType("Windows.UI.Xaml.Controls.DatePickerFlyoutPresenter");
        }

        private static By DaySelectorLocatorWasm()
        {
            return ByExtensions.WebXamlName(DayLoopingSelectorName);
        }

        private static By MonthSelectorLocatorWasm()
        {
            return ByExtensions.WebXamlName(MonthLoopingSelectorName);
        }

        private static By YearSelectorLocatorWasm()
        {
            return ByExtensions.WebXamlName(YearLoopingSelectorName);
        }

        private static By AcceptButtonLocatorWasm()
        {
            return ByExtensions.WebXamlName(AcceptButtonName);
        }

        private static IWebElement FindSelectorChildElementByValueWasm(IFindsByName element, string value)
        {
            throw new NotImplementedException(
                "An implementation for WASM has not been implemented yet.");
        }

        private (string day, string month, string year) DetermineSelectedDateWasm()
        {
            string day = this.Element.FindElementByXamlName("DayTextBlock").Text;
            string month = this.Element.FindElementByXamlName("MonthTextBlock").Text;
            string year = this.Element.FindElementByXamlName("YearTextBlock").Text;
            return (day, month, year);
        }
    }
}
