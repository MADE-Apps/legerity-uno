namespace Legerity.Uno.Elements
{
    using System.Text.RegularExpressions;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Internal;

    public partial class DatePicker
    {
        private static By FlyoutLocatorWindows()
        {
            return Windows.Extensions.ByExtensions.AutomationId("DatePickerFlyoutPresenter");
        }

        private static By DaySelectorLocatorWindows()
        {
            return Windows.Extensions.ByExtensions.AutomationId(DayLoopingSelectorName);
        }

        private static By MonthSelectorLocatorWindows()
        {
            return Windows.Extensions.ByExtensions.AutomationId(MonthLoopingSelectorName);
        }

        private static By YearSelectorLocatorWindows()
        {
            return Windows.Extensions.ByExtensions.AutomationId(YearLoopingSelectorName);
        }

        private static By AcceptButtonLocatorWindows()
        {
            return Windows.Extensions.ByExtensions.AutomationId(AcceptButtonName);
        }

        private static IWebElement FindSelectorChildElementByValueWindows(IFindsByName element, string value)
        {
            return element.FindElementByName(value);
        }

        private (string day, string month, string year) DetermineSelectedDateWindows()
        {
            string dateString = this.FindElement(Windows.Extensions.ByExtensions.AutomationId("FlyoutButton"))
                .GetAttribute("Name")
                .Replace("Pick a date ", string.Empty)
                .Replace(" date picker", string.Empty)
                .Replace(",", string.Empty);

            string day = new Regex("(\\d{2})").Match(dateString).Value.Trim();
            string month = new Regex("([a-zA-Z]+)").Match(dateString).Value;
            string year = new Regex("(\\d{4})").Match(dateString).Value.Trim();

            return (day, month, year);
        }
    }
}
