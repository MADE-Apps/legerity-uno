// MADE Apps licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Legerity.Uno.Elements;

using System.Linq;
using System.Text.RegularExpressions;
using Legerity.Extensions;
using Legerity.Windows;
using OpenQA.Selenium;
using OpenQA.Selenium.Internal;

public partial class TimePicker
{
    private static By FlyoutLocatorWindows()
    {
        return WindowsByExtras.AutomationId("TimePickerFlyoutPresenter");
    }

    private static By HourSelectorLocatorWindows()
    {
        return WindowsByExtras.AutomationId(HourLoopingSelectorName);
    }

    private static By MinuteSelectorLocatorWindows()
    {
        return WindowsByExtras.AutomationId(MinuteLoopingSelectorName);
    }

    private static By AcceptButtonLocatorWindows()
    {
        return WindowsByExtras.AutomationId(AcceptButtonName);
    }

    private static IWebElement FindSelectorChildElementByValueWindows(IFindsByName element, string value)
    {
        return element.FindElementByName(value);
    }

    private (string hour, string minute) DetermineSelectedTimeWindows()
    {
        string timeElementText = this.FindWebElement(WindowsByExtras.AutomationId("FlyoutButton"))
            .GetName()
            .Replace(" time picker", string.Empty)
            .Trim();

        var regex = new Regex(@"\d+");

        string[] timeString = timeElementText.Split(':');
        string hour = regex.Match(timeString.FirstOrDefault() ?? string.Empty).Value;
        string minute = regex.Match(timeString.LastOrDefault() ?? string.Empty).Value;
        return (hour, minute);
    }
}