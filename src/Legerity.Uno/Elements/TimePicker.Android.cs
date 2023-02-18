// MADE Apps licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Legerity.Uno.Elements;

using System;
using Exceptions;
using OpenQA.Selenium;
using OpenQA.Selenium.Internal;

public partial class TimePicker
{
    /// <exception cref="AndroidNotImplementedException">Thrown when called on Android.</exception>
    public static By FlyoutLocatorAndroid()
    {
        throw new AndroidNotImplementedException(
            "An implementation for Android has not been implemented yet.");
    }

    /// <exception cref="AndroidNotImplementedException">Thrown when called on Android.</exception>
    private static By HourSelectorLocatorAndroid()
    {
        throw new AndroidNotImplementedException(
            "An implementation for Android has not been implemented yet.");
    }

    /// <exception cref="AndroidNotImplementedException">Thrown when called on Android.</exception>
    private static By MinuteSelectorLocatorAndroid()
    {
        throw new AndroidNotImplementedException(
            "An implementation for Android has not been implemented yet.");
    }

    /// <exception cref="AndroidNotImplementedException">Thrown when called on Android.</exception>
    private static By AcceptButtonLocatorAndroid()
    {
        throw new AndroidNotImplementedException(
            "An implementation for Android has not been implemented yet.");
    }

    /// <exception cref="AndroidNotImplementedException">Thrown when called on Android.</exception>
    private static IWebElement FindSelectorChildElementByValueAndroid(IFindsByName element, string value)
    {
        throw new AndroidNotImplementedException(
            "An implementation for Android has not been implemented yet.");
    }

    /// <exception cref="AndroidNotImplementedException">Thrown when called on Android.</exception>
    private (string hour, string minute) DetermineSelectedTimeAndroid()
    {
        throw new AndroidNotImplementedException(
            "An implementation for Android has not been implemented yet.");
    }
}