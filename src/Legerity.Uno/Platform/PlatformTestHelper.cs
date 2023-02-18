// MADE Apps licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Legerity.Uno.Platform;

using System;
using System.Linq;

/// <summary>
/// Defines a helper for platform specific test runs.
/// </summary>
public static class PlatformTestHelper
{
    /// <summary>
    /// Skips a specific test for a given platform based on the provided <see cref="AppManagerOptions"/> type.
    /// </summary>
    /// <param name="ignoreAction">The action called to handle the ignore for the test. If not handled, a <see cref="PlatformIgnoredException"/> will be thrown.</param>
    /// <param name="message">The optional message to include in the ignored result.</param>
    /// <param name="appManagerOptionsSkipTypes">The <see cref="AppManagerOptions"/> type to skip for.</param>
    /// <exception cref="PlatformIgnoredException">Thrown when the test specific <paramref name="ignoreAction"/> is not provided.</exception>
    /// <exception cref="Exception">Thrown when the <paramref name="ignoreAction"/> callback throws an exception.</exception>
    public static void SkipForPlatform(
        Action<string> ignoreAction = default,
        string message = default,
        params Type[] appManagerOptionsSkipTypes)
    {
        if (UnoAppManager.Options == null ||
            !appManagerOptionsSkipTypes.Contains(UnoAppManager.Options.AppManagerOptions.GetType()))
        {
            return;
        }

        string ignoreMessage = $"Cannot currently run test for this platform. {message}";

        if (ignoreAction != null)
        {
            ignoreAction(ignoreMessage);
        }
        else
        {
            throw new PlatformIgnoredException(ignoreMessage);
        }
    }
}