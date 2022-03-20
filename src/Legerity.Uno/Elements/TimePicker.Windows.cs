namespace Legerity.Uno.Elements
{
    using System.Linq;
    using System.Text.RegularExpressions;
    using Legerity.Extensions;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Internal;

    public partial class TimePicker
    {
        private static By FlyoutLocatorWindows()
        {
            return Windows.Extensions.ByExtensions.AutomationId("TimePickerFlyoutPresenter");
        }

        private static By HourSelectorLocatorWindows()
        {
            return Windows.Extensions.ByExtensions.AutomationId(HourLoopingSelectorName);
        }

        private static By MinuteSelectorLocatorWindows()
        {
            return Windows.Extensions.ByExtensions.AutomationId(MinuteLoopingSelectorName);
        }

        private static By AcceptButtonLocatorWindows()
        {
            return Windows.Extensions.ByExtensions.AutomationId(AcceptButtonName);
        }

        private static IWebElement FindSelectorChildElementByValueWindows(IFindsByName element, string value)
        {
            return element.FindElementByName(value);
        }

        private (string hour, string minute) DetermineSelectedTimeWindows()
        {
            string timeElementText = this.FindWebElement(Windows.Extensions.ByExtensions.AutomationId("FlyoutButton"))
                .GetAttribute("Name")
                .Replace(" time picker", string.Empty)
                .Trim();

            var regex = new Regex(@"\d+");

            string[] timeString = timeElementText.Split(':');
            string hour = regex.Match(timeString.FirstOrDefault() ?? string.Empty).Value;
            string minute = regex.Match(timeString.LastOrDefault() ?? string.Empty).Value;
            return (hour, minute);
        }
    }
}