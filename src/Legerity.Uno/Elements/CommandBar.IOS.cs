// MADE Apps licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Legerity.Uno.Elements;

using OpenQA.Selenium;

public partial class CommandBar
{
    private static By PrimaryAppBarButtonItemLocatorIOS()
    {
        return By.XPath(
            ".//*[@name='PrimaryItemsControl']/XCUIElementTypeOther/XCUIElementTypeOther/child::*");
    }

    private static By SecondaryAppBarButtonItemLocatorIOS()
    {
        return By.XPath(".//*[@name='ItemsPresenter']/XCUIElementTypeOther/child::*");
    }

    private static By SecondaryOverflowButtonLocatorIOS()
    {
        return ByExtras.IOSXamlAutomationId(MoreButtonName);
    }

    private static By SecondaryOverflowPopupLocatorIOS()
    {
        return ByExtras.IOSXamlAutomationId(OverflowContentRootName);
    }
}