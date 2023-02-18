// MADE Apps licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Legerity.Uno.Elements;

using System.Linq;
using Legerity.Extensions;
using Legerity.IOS;
using Legerity.IOS.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

public partial class ComboBox
{
    private static By ComboBoxItemLocatorIOS()
    {
        return ByExtras.IOSXamlAutomationId(ScrollContentPresenterName);
    }

    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    private RemoteWebElement DetermineListElementByNameIOS(string name)
    {
        return this.Driver.FindElement(this.ComboBoxItemLocator())
            .FindWebElement(IOSByExtras.Label(name));
    }

    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    private RemoteWebElement DetermineListElementByPartialNameIOS(string name)
    {
        return this.Driver.FindElement(this.ComboBoxItemLocator())
            .FindWebElement(IOSByExtras.PartialLabel(name));
    }

    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    private string DetermineSelectedItemIOS()
    {
        return this.FindElement(ByExtras.IOSXamlAutomationId(ContentPresenterName))
            ?.GetAllChildElements()
            ?.LastOrDefault()
            ?.GetLabel();
    }
}