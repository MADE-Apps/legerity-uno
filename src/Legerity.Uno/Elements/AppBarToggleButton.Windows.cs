// MADE Apps licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Legerity.Uno.Elements;

using Legerity.Windows.Elements.Core;
using Legerity.Windows.Extensions;

public partial class AppBarToggleButton
{
    private bool DetermineIsOnWindows()
    {
        return this.GetToggleState() == ToggleState.Checked;
    }
}