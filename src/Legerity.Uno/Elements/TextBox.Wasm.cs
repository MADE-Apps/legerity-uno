// MADE Apps licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Legerity.Uno.Elements;

using Legerity.Uno.Extensions;
using Legerity.Web.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

public partial class TextBox
{
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    private RemoteWebElement DetermineInputElementWasm()
    {
        return this.FindWebElementByXamlType("Windows.UI.Xaml.Controls.TextBoxView");
    }

    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    private string DetermineTextWasm()
    {
        return this.InputElement.GetValue() ?? string.Empty;
    }

    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when the target element is no longer valid in the document DOM.</exception>
    private bool DetermineIsReadonlyWasm()
    {
        return !string.IsNullOrWhiteSpace(this.InputElement.GetAttribute("readonly"));
    }
}