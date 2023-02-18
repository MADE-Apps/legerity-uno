// MADE Apps licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Legerity.Uno.Elements;

using System;
using Legerity.Uno.Extensions;

public partial class CheckBox
{
    private bool DetermineIsCheckedWasm()
    {
        return this.FindElementByXamlName(CheckBoxGlyphName).Displayed;
    }

    private bool DetermineIsIndeterminateWasm()
    {
        throw new NotImplementedException(
            "An implementation for WASM has not been implemented yet.");
    }
}