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
    private static By ComboBoxItemLocatorWasm()
    {
        return ByExtras.WebXamlType("Windows.UI.Xaml.Controls.ComboBoxItem");
    }

    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    private RemoteWebElement DetermineListElementByNameWasm(string name)
    {
        return this.Driver
            .FindWebElements(this.ComboBoxItemLocator())
            .SelectMany(element => element.FindWebElements(By.TagName("p")))
            .FirstOrDefault(element => element.Text.Equals(name, StringComparison.CurrentCultureIgnoreCase));
    }

    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    private RemoteWebElement DetermineListElementByPartialNameWasm(string name)
    {
        return this.Driver
            .FindWebElements(this.ComboBoxItemLocator())
            .SelectMany(element => element.FindWebElements(By.TagName("p")))
            .FirstOrDefault(element =>
                element.Text.Contains(name, CultureInfo.CurrentCulture, CompareOptions.IgnoreCase));
    }

    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    private string DetermineSelectedItemWasm()
    {
        return this.FindElements(ByExtras.WebXamlType("Windows.UI.Xaml.Controls.ContentPresenter"))
            .LastOrDefault()?
            .FindWebElement(By.TagName("p"))?
            .Text;
    }
}