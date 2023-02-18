// MADE Apps licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Legerity.Uno.Elements;

using Exceptions;
using Legerity.Uno.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Internal;

public partial class DatePicker
{
    private static By FlyoutLocatorWasm()
    {
        return ByExtras.WebXamlType("Windows.UI.Xaml.Controls.DatePickerFlyoutPresenter");
    }

    private static By DaySelectorLocatorWasm()
    {
        return ByExtras.WebXamlName(DayLoopingSelectorName);
    }

    private static By MonthSelectorLocatorWasm()
    {
        return ByExtras.WebXamlName(MonthLoopingSelectorName);
    }

    private static By YearSelectorLocatorWasm()
    {
        return ByExtras.WebXamlName(YearLoopingSelectorName);
    }

    private static By AcceptButtonLocatorWasm()
    {
        return ByExtras.WebXamlName(AcceptButtonName);
    }

    /// <exception cref="WebNotImplementedException">Thrown when called on Web.</exception>
    private static IWebElement FindSelectorChildElementByValueWasm(IFindsByName element, string value)
    {
        throw new WebNotImplementedException(
            "An implementation for WASM has not been implemented yet.");
    }

    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    private (string day, string month, string year) DetermineSelectedDateWasm()
    {
        string day = this.FindElementByXamlName("DayTextBlock").Text;
        string month = this.FindElementByXamlName("MonthTextBlock").Text;
        string year = this.FindElementByXamlName("YearTextBlock").Text;
        return (day, month, year);
    }
}