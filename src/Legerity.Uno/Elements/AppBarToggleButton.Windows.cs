// MADE Apps licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Legerity.Uno.Elements;

using Legerity.Windows.Elements.Core;
using Legerity.Windows.Extensions;
using OpenQA.Selenium;

public partial class AppBarToggleButton
{
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    private bool DetermineIsOnWindows()
    {
        return this.GetToggleState() == ToggleState.Checked;
    }
}