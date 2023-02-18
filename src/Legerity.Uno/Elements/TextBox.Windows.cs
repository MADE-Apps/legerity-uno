// MADE Apps licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Legerity.Uno.Elements;

using System;
using Legerity.Windows.Extensions;
using OpenQA.Selenium.Remote;

public partial class TextBox
{
    private RemoteWebElement DetermineInputElementWindows()
    {
        return this.Element;
    }

    private string DetermineTextWindows()
    {
        return this.InputElement.GetValue() ?? string.Empty;
    }

    private bool DetermineIsReadonlyWindows()
    {
        return this.InputElement
            .GetAttribute("Value.IsReadonly")
            .Equals("True", StringComparison.CurrentCultureIgnoreCase);
    }
}