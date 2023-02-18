// MADE Apps licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Legerity.Uno.Elements;

using Legerity.Windows;
using OpenQA.Selenium;

public partial class CommandBar
{
    private static By AppBarButtonItemLocatorWindows()
    {
        return By.ClassName("AppBarButton");
    }

    private static By SecondaryOverflowPopupLocatorWindows()
    {
        return WindowsByExtras.AutomationId("OverflowPopup");
    }

    private static By SecondaryOverflowButtonLocatorWindows()
    {
        return WindowsByExtras.AutomationId(MoreButtonName);
    }
}