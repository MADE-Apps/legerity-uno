// MADE Apps licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Legerity.Uno.Elements;

using Legerity.Uno.Extensions;

public partial class AppBarToggleButton
{
    private bool DetermineIsOnWasm()
    {
        return this.FindElementByXamlName("OverflowCheckGlyph")
            .GetAttribute("style")
            .Contains("opacity") == false;
    }
}