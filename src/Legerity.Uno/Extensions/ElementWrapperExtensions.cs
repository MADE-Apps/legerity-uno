// MADE Apps licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Legerity.Uno.Extensions;

using System;
using Legerity.Uno.Elements;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;

/// <summary>
/// Defines a collection of extensions for <see cref="IElementWrapper{TElement}"/> objects.
/// </summary>
public static class ElementWrapperExtensions
{
    /// <summary>
    /// Attempts to wait until a specified element condition is met, with an optional timeout.
    /// </summary>
    /// <param name="element">The element to wait on.</param>
    /// <param name="condition">The condition of the element to wait on.</param>
    /// <param name="timeout">The optional timeout wait on the condition being true.</param>
    /// <param name="retries">An optional count of retries after a timeout before accepting the failure.</param>
    /// <param name="exceptionHandler">The optional exception handler thrown if an error occurs as a result of timeout.</param>
    /// <typeparam name="TElementWrapper">The type of <see cref="UnoElementWrapper"/>.</typeparam>
    /// <typeparam name="TResult">The type of expected result from the wait condition.</typeparam>
    /// <returns>Whether the wait was a success.</returns>
    /// <exception cref="Exception">Thrown when the <paramref name="exceptionHandler"/> callback throws an exception.</exception>
    public static bool TryWaitUntil<TElementWrapper, TResult>(
        this TElementWrapper element,
        Func<TElementWrapper, TResult> condition,
        TimeSpan? timeout = default,
        int retries = 0,
        Action<Exception> exceptionHandler = null)
        where TElementWrapper : UnoElementWrapper
    {
        try
        {
            WaitUntil(element, condition, timeout, retries);
        }
        catch (Exception ex)
        {
            exceptionHandler?.Invoke(ex);
            return false;
        }

        return true;
    }

    /// <summary>
    /// Waits until a specified element condition is met, with an optional timeout.
    /// </summary>
    /// <param name="element">The element to wait on.</param>
    /// <param name="condition">The condition of the element to wait on.</param>
    /// <param name="timeout">The optional timeout wait on the condition being true.</param>
    /// <param name="retries">An optional count of retries after a timeout before accepting the failure.</param>
    /// <typeparam name="TElementWrapper">The type of <see cref="UnoElementWrapper"/>.</typeparam>
    /// <typeparam name="TResult">The type of expected result from the wait condition.</typeparam>
    /// <returns>The <typeparamref name="TResult"/> of the wait until operation.</returns>
    /// <exception cref="WebDriverException">Thrown when the condition is not met in the allocated timeout period.</exception>
    /// <exception cref="Exception">Thrown when the <paramref name="condition"/> callback throws an exception.</exception>
    public static TResult WaitUntil<TElementWrapper, TResult>(
        this TElementWrapper element,
        Func<TElementWrapper, TResult> condition,
        TimeSpan? timeout = default,
        int retries = 0)
        where TElementWrapper : UnoElementWrapper
    {
        try
        {
            return new WebDriverWait(element.ElementDriver, timeout ?? TimeSpan.Zero).Until(_ =>
            {
                try
                {
                    return condition(element);
                }
                catch (StaleElementReferenceException)
                {
                    return default;
                }
            });
        }
        catch (WebDriverException)
        {
            if (retries <= 0)
            {
                throw;
            }

            return WaitUntil(element, condition, timeout, retries - 1);
        }
    }

    /// <summary>
    /// Finds the first Uno Platform web element under the given element that matches the given XAML type.
    /// </summary>
    /// <param name="element">The web element.</param>
    /// <param name="xamlType">
    /// The XAML type.
    /// <para>
    /// Windows control types can be referenced by the element wrapper's WindowsType value.
    /// </para>
    /// </param>
    /// <returns>The <see cref="RemoteWebElement"/> if found.</returns>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public static RemoteWebElement FindWebElementByXamlType(this UnoElementWrapper element, string xamlType)
    {
        return element.Element.FindWebElementByXamlType(xamlType);
    }

    /// <summary>
    /// Finds the first Uno Platform web element under the given element that matches the given x:Name value.
    /// <para>
    /// To find elements with this method for web applications, set the following in your App.xaml.cs.
    /// <code>
    /// Uno.UI.FeatureConfiguration.UIElement.AssignDOMXamlName = true;
    /// </code>
    /// </para>
    /// </summary>
    /// <param name="element">The web element.</param>
    /// <param name="name">The x:Name of the element to find.</param>
    /// <returns>The <see cref="RemoteWebElement"/> if found.</returns>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public static RemoteWebElement FindElementByXamlName(this UnoElementWrapper element, string name)
    {
        return element.Element.FindElementByXamlName(name);
    }

    /// <summary>
    /// Finds the first element under the given element that matches the given automation identifier.
    /// <para>
    /// To find element for platforms supported by Uno, set the following in your App.xaml.cs constructor.
    /// <code>
    /// Uno.UI.FrameworkElementHelper.IsUiAutomationMappingEnabled = true;
    /// </code>
    /// </para>
    /// <para>
    /// For improvements to finding elements for web applications, also set the following in your App.xaml.cs constructor.
    /// <code>
    /// Uno.UI.FeatureConfiguration.UIElement.AssignDOMXamlName = true;
    /// </code>
    /// </para>
    /// </summary>
    /// <param name="element">The element.</param>
    /// <param name="automationId">The automation identifier.</param>
    /// <returns>The <see cref="RemoteWebElement"/> if found.</returns>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public static RemoteWebElement FindElementByAutomationId(this UnoElementWrapper element, string automationId)
    {
        return element.Element.FindElementByAutomationId(automationId);
    }

    /// <summary>
    /// Verifies the elements name or AutomationId based on the given compare.
    /// </summary>
    /// <param name="element">
    /// The element to verify.
    /// </param>
    /// <param name="compare">
    /// The value to verify is the name or AutomationId.
    /// </param>
    /// <returns>
    /// True if the element's name or AutomationId matches; otherwise, false.
    /// </returns>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public static bool VerifyNameOrAutomationIdEquals(this UnoElementWrapper element, string compare)
    {
        return element.Element.VerifyNameOrAutomationIdEquals(compare);
    }

    /// <summary>
    /// Verifies the elements name or Automation ID based on the given partial compare value.
    /// </summary>
    /// <param name="element">
    /// The element to verify.
    /// </param>
    /// <param name="compare">
    /// The partial value to verify is the name or Automation ID.
    /// </param>
    /// <returns>
    /// True if the element's name or Automation ID matches partially; otherwise, false.
    /// </returns>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    public static bool VerifyNameOrAutomationIdContains(this UnoElementWrapper element, string compare)
    {
        return element.Element.VerifyNameOrAutomationIdContains(compare);
    }
}