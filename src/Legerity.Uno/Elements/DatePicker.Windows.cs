// MADE Apps licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Legerity.Uno.Elements;

using System.Text.RegularExpressions;
using Legerity.Extensions;
using Legerity.Windows;
using OpenQA.Selenium;
using OpenQA.Selenium.Internal;

public partial class DatePicker
{
    private static By FlyoutLocatorWindows()
    {
        return WindowsByExtras.AutomationId("DatePickerFlyoutPresenter");
    }

    private static By DaySelectorLocatorWindows()
    {
        return WindowsByExtras.AutomationId(DayLoopingSelectorName);
    }

    private static By MonthSelectorLocatorWindows()
    {
        return WindowsByExtras.AutomationId(MonthLoopingSelectorName);
    }

    private static By YearSelectorLocatorWindows()
    {
        return WindowsByExtras.AutomationId(YearLoopingSelectorName);
    }

    private static By AcceptButtonLocatorWindows()
    {
        return WindowsByExtras.AutomationId(AcceptButtonName);
    }

    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    private static IWebElement FindSelectorChildElementByValueWindows(IFindsByName element, string value)
    {
        return element.FindElementByName(value);
    }

    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    private (string day, string month, string year) DetermineSelectedDateWindows()
    {
        string dateString = this.FindElement(WindowsByExtras.AutomationId("FlyoutButton"))
            .GetName()
            .Replace("Pick a date ", string.Empty)
            .Replace(" date picker", string.Empty)
            .Replace(",", string.Empty);

        string day = new Regex("(\\d{2})").Match(dateString).Value.Trim();
        string month = new Regex("([a-zA-Z]+)").Match(dateString).Value;
        string year = new Regex("(\\d{4})").Match(dateString).Value.Trim();

        return (day, month, year);
    }
}