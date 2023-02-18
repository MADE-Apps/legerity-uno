// MADE Apps licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Legerity.Uno.Elements;

using Legerity.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

public partial class TextBox
{
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    private RemoteWebElement DetermineInputElementAndroid()
    {
        return this.FindWebElement(By.ClassName("android.widget.EditText"));
    }

    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    private string DetermineTextAndroid()
    {
        return this.InputElement.Text ?? string.Empty;
    }

    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    private bool DetermineIsReadonlyAndroid()
    {
        return !this.InputElement.Enabled;
    }
}