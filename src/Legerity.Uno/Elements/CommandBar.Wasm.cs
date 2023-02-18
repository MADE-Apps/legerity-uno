// MADE Apps licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Legerity.Uno.Elements;

using OpenQA.Selenium;

public partial class CommandBar
{
    private static By AppBarButtonItemLocatorWasm()
    {
        return ByExtras.WebXamlType(AppBarButton.WindowsType);
    }

    private static By SecondaryOverflowPopupLocatorWasm()
    {
        return ByExtras.WebXamlName(OverflowContentRootName);
    }

    private static By SecondaryOverflowButtonLocatorWasm()
    {
        return ByExtras.WebXamlName(MoreButtonName);
    }
}