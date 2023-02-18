// MADE Apps licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Legerity.Uno.Elements;

using Exceptions;

public partial class AppBarToggleButton
{
    /// <exception cref="IOSNotImplementedException">Thrown when called on iOS.</exception>
    private bool DetermineIsOnIOS()
    {
        throw new IOSNotImplementedException(
            "An implementation for iOS has not been implemented yet.");
    }
}