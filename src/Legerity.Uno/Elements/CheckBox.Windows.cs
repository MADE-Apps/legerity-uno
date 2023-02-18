// MADE Apps licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Legerity.Uno.Elements;

using Legerity.Windows.Elements.Core;
using Legerity.Windows.Extensions;

public partial class CheckBox
{
    private bool DetermineIsCheckedWindows()
    {
        return this.GetToggleState() == ToggleState.Checked;
    }

    private bool DetermineIsIndeterminateWindows()
    {
        return this.GetToggleState() == ToggleState.Indeterminate;
    }
}