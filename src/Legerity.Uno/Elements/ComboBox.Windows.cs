// MADE Apps licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Legerity.Uno.Elements;

using System;
using System.Linq;
using Legerity.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

public partial class ComboBox
{
    private static By ComboBoxItemLocatorWindows()
    {
        return By.ClassName("ComboBoxItem");
    }

    private RemoteWebElement DetermineListElementWindows(string name)
    {
        return this.FindElements(this.ComboBoxItemLocator())
            .FirstOrDefault(e => e.GetName().Equals(name, StringComparison.CurrentCultureIgnoreCase));
    }

    private string DetermineSelectedItemWindows()
    {
        return this.FindElements(this.ComboBoxItemLocator()).FirstOrDefault()?.GetName();
    }
}