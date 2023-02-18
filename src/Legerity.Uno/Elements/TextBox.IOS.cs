// MADE Apps licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Legerity.Uno.Elements;

using Legerity.Extensions;
using Legerity.IOS.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

public partial class TextBox
{
    private RemoteWebElement DetermineInputElementIOS()
    {
        return this.FindWebElement(By.ClassName("XCUIElementTypeTextField"));
    }

    private string DetermineTextIOS()
    {
        return this.InputElement.GetValue() ?? string.Empty;
    }

    private bool DetermineIsReadonlyIOS()
    {
        return !this.InputElement.Enabled;
    }
}