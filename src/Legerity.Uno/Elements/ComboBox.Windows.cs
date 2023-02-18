// MADE Apps licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Legerity.Uno.Elements;

using System;
using System.Globalization;
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

    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    private RemoteWebElement DetermineListElementByNameWindows(string name)
    {
        return this.FindElements(this.ComboBoxItemLocator())
            .FirstOrDefault(e => e.GetName().Equals(name, StringComparison.CurrentCultureIgnoreCase));
    }

    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    private RemoteWebElement DetermineListElementByPartialNameWindows(string name)
    {
        return this.FindElements(this.ComboBoxItemLocator())
            .FirstOrDefault(e => e.GetName().Contains(name, CultureInfo.CurrentCulture, CompareOptions.IgnoreCase));
    }

    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    private string DetermineSelectedItemWindows()
    {
        return this.FindElements(this.ComboBoxItemLocator()).FirstOrDefault()?.GetName();
    }
}