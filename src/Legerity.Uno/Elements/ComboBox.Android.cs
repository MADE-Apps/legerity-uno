// MADE Apps licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Legerity.Uno.Elements;

using System.Linq;
using Legerity.Android;
using Legerity.Android.Extensions;
using Legerity.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

public partial class ComboBox
{
    private static By ComboBoxItemLocatorAndroid()
    {
        return ByExtras.AndroidXamlAutomationId(ScrollContentPresenterName);
    }

    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    private RemoteWebElement DetermineListElementByNameAndroid(string name)
    {
        return this.Driver.FindElement(this.ComboBoxItemLocator())
            .FindWebElement(AndroidByExtras.PartialContentDescription(name));
    }

    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    private RemoteWebElement DetermineListElementByPartialNameAndroid(string name)
    {
        return this.Driver.FindElement(this.ComboBoxItemLocator())
            .FindWebElement(AndroidByExtras.PartialContentDescription(name));
    }

    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    private string DetermineSelectedItemAndroid()
    {
        return this.FindElement(ByExtras.AndroidXamlAutomationId(ContentPresenterName))
            ?.GetAllChildElements()
            ?.LastOrDefault()
            ?.GetContentDescription();
    }
}