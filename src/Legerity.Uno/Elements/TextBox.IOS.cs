// MADE Apps licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Legerity.Uno.Elements;

using Legerity.Extensions;
using Legerity.IOS.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

public partial class TextBox
{
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    private RemoteWebElement DetermineInputElementIOS()
    {
        return this.FindWebElement(By.ClassName("XCUIElementTypeTextField"));
    }

    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    private string DetermineTextIOS()
    {
        return this.InputElement.GetValue() ?? string.Empty;
    }

    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    private bool DetermineIsReadonlyIOS()
    {
        return !this.InputElement.Enabled;
    }
}