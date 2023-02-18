// MADE Apps licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Legerity.Uno.Elements;

using Exceptions;
using Legerity.Uno.Extensions;
using OpenQA.Selenium;

public partial class CheckBox
{
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    private bool DetermineIsCheckedWasm()
    {
        return this.FindElementByXamlName(CheckBoxGlyphName).Displayed;
    }

    /// <exception cref="WebNotImplementedException">Thrown when called on Web.</exception>
    private bool DetermineIsIndeterminateWasm()
    {
        throw new WebNotImplementedException(
            "An implementation for WASM has not been implemented yet.");
    }
}