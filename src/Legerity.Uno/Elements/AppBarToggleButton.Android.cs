// MADE Apps licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Legerity.Uno.Elements;

using Exceptions;

public partial class AppBarToggleButton
{
    /// <exception cref="AndroidNotImplementedException">Thrown when called on Android.</exception>
    private bool DetermineIsOnAndroid()
    {
        throw new AndroidNotImplementedException(
            "An implementation for Android has not been implemented yet.");
    }
}