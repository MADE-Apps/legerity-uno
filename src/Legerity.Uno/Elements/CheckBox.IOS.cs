// MADE Apps licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Legerity.Uno.Elements;

using System;
using OpenQA.Selenium;

public partial class CheckBox
{
    private bool DetermineIsCheckedIOS()
    {
        try
        {
            return this.FindElement(ByExtras.IOSXamlAutomationId(CheckBoxGlyphName)) != null;
        }
        catch (WebDriverException)
        {
            return false;
        }
    }

    private bool DetermineIsIndeterminateIOS()
    {
        throw new NotImplementedException(
            "An implementation for iOS has not been implemented yet.");
    }
}