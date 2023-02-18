// MADE Apps licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Legerity.Uno.Elements;

using Legerity.Windows.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

public partial class TextBox
{
    private RemoteWebElement DetermineInputElementWindows()
    {
        return this.Element;
    }

    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    private string DetermineTextWindows()
    {
        return this.InputElement.GetValue() ?? string.Empty;
    }

    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when the target element is no longer valid in the document DOM.</exception>
    private bool DetermineIsReadonlyWindows()
    {
        return this.InputElement.IsReadonly();
    }
}