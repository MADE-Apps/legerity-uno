// MADE Apps licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Legerity.Uno.Elements;

using Legerity.Uno.Extensions;
using Legerity.Web.Extensions;
using OpenQA.Selenium.Remote;

public partial class TextBox
{
    private RemoteWebElement DetermineInputElementWasm()
    {
        return this.FindWebElementByXamlType("Windows.UI.Xaml.Controls.TextBoxView");
    }

    private string DetermineTextWasm()
    {
        return this.InputElement.GetValue() ?? string.Empty;
    }

    private bool DetermineIsReadonlyWasm()
    {
        return !string.IsNullOrWhiteSpace(this.InputElement.GetAttribute("readonly"));
    }
}