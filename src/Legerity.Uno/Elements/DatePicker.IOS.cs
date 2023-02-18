// MADE Apps licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Legerity.Uno.Elements;

using System;
using Exceptions;
using OpenQA.Selenium;
using OpenQA.Selenium.Internal;

public partial class DatePicker
{
    /// <exception cref="IOSNotImplementedException">Thrown when called on iOS.</exception>
    private static By FlyoutLocatorIOS()
    {
        throw new IOSNotImplementedException(
            "An implementation for iOS has not been implemented yet.");
    }

    /// <exception cref="IOSNotImplementedException">Thrown when called on iOS.</exception>
    private static By DaySelectorLocatorIOS()
    {
        throw new IOSNotImplementedException(
            "An implementation for iOS has not been implemented yet.");
    }

    /// <exception cref="IOSNotImplementedException">Thrown when called on iOS.</exception>
    private static By MonthSelectorLocatorIOS()
    {
        throw new IOSNotImplementedException(
            "An implementation for iOS has not been implemented yet.");
    }

    /// <exception cref="IOSNotImplementedException">Thrown when called on iOS.</exception>
    private static By YearSelectorLocatorIOS()
    {
        throw new IOSNotImplementedException(
            "An implementation for iOS has not been implemented yet.");
    }

    /// <exception cref="IOSNotImplementedException">Thrown when called on iOS.</exception>
    private static By AcceptButtonLocatorIOS()
    {
        throw new IOSNotImplementedException(
            "An implementation for iOS has not been implemented yet.");
    }

    /// <exception cref="IOSNotImplementedException">Thrown when called on iOS.</exception>
    private static IWebElement FindSelectorChildElementByValueIOS(IFindsByName element, string value)
    {
        throw new IOSNotImplementedException(
            "An implementation for iOS has not been implemented yet.");
    }

    /// <exception cref="IOSNotImplementedException">Thrown when called on iOS.</exception>
    private (string day, string month, string year) DetermineSelectedDateIOS()
    {
        throw new IOSNotImplementedException(
            "An implementation for iOS has not been implemented yet.");
    }
}