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

    private RemoteWebElement DetermineListElementIOS(string name)
    {
        return this.Driver.FindElement(this.ComboBoxItemLocator())
            .FindWebElement(IOSByExtras.Label(name));
    }

    private string DetermineSelectedItemIOS()
    {
        return this.FindElement(ByExtras.IOSXamlAutomationId(ContentPresenterName))
            ?.GetAllChildElements()
            ?.LastOrDefault()
            ?.GetLabel();
    }
}