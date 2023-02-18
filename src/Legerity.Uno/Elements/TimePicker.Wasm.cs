// MADE Apps licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Legerity.Uno.Elements;

using Legerity.Extensions;
using Legerity.Uno.Extensions;
using OpenQA.Selenium;

public partial class TimePicker
{
    private static By FlyoutLocatorWasm()
    {
        return ByExtras.WebXamlType("Windows.UI.Xaml.Controls.TimePickerFlyoutPresenter");
    }

    private static By HourSelectorLocatorWasm()
    {
        return ByExtras.WebXamlName(HourLoopingSelectorName);
    }

    private static By MinuteSelectorLocatorWasm()
    {
        return ByExtras.WebXamlName(MinuteLoopingSelectorName);
    }

    private static By AcceptButtonLocatorWasm()
    {
        return ByExtras.WebXamlName(AcceptButtonName);
    }

    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    private static IWebElement FindSelectorChildElementByValueWasm(IWebElement element, string value)
    {
        return element.FindElementByText(value);
    }

    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when the target element is no longer valid in the document DOM.</exception>
    private (string hour, string minute) DetermineSelectedTimeWasm()
    {
        string hour = this.FindElementByXamlName("HourTextBlock").Text;
        string minute = this.FindElementByXamlName("MinuteTextBlock").Text;

        return (hour, minute);
    }
}