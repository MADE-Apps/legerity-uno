// MADE Apps licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Legerity.Uno.Elements;

using System;
using OpenQA.Selenium;

public partial class CheckBox
{
    private bool DetermineIsCheckedAndroid()
    {
        try
        {
            return this.FindElement(ByExtras.AndroidXamlAutomationId(CheckBoxGlyphName)) != null;
        }
        catch (WebDriverException)
        {
            return false;
        }
    }

    private bool DetermineIsIndeterminateAndroid()
    {
        throw new NotImplementedException(
            "An implementation for Android has not been implemented yet.");
    }
}