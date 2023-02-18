// MADE Apps licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Legerity.Uno.Elements;

using System;
using Exceptions;
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

    /// <exception cref="AndroidNotImplementedException">Thrown when called on Android.</exception>
    private bool DetermineIsIndeterminateAndroid()
    {
        throw new AndroidNotImplementedException(
            "An implementation for Android has not been implemented yet.");
    }
}