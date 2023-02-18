// MADE Apps licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Legerity.Uno.Elements;

using Exceptions;
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

    /// <exception cref="IOSNotImplementedException">Thrown when called on iOS.</exception>
    private bool DetermineIsIndeterminateIOS()
    {
        throw new IOSNotImplementedException(
            "An implementation for iOS has not been implemented yet.");
    }
}