// MADE Apps licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Legerity.Uno.Elements;

using Legerity.Uno.Extensions;
using OpenQA.Selenium;

public partial class AppBarToggleButton
{
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    private bool DetermineIsOnWasm()
    {
        return this.FindElementByXamlName("OverflowCheckGlyph")
            .GetAttribute("style")
            .Contains("opacity") == false;
    }
}