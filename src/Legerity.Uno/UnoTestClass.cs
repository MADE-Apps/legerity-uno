// MADE Apps licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Legerity.Uno;

using System;
using System.Collections.Generic;
using System.Linq;
using Android;
using Exceptions;
using IOS;
using Legerity.Uno.Platform;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.iOS;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;
using Windows;

/// <summary>
/// Defines a base class for running tests with the Legerity framework for the Uno Platform.
/// </summary>
public abstract class UnoTestClass
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UnoTestClass"/> class.
    /// <para>
    /// The <see cref="Options"/> will need to be set before calling <see cref="StartApp(Func{IWebDriver,bool},TimeSpan?,int)"/>.
    /// </para>
    /// </summary>
    protected UnoTestClass()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="UnoTestClass"/> class with application launch option.
    /// </summary>
    /// <param name="options">The application launch options.</param>
    protected UnoTestClass(AppManagerOptions options)
    {
        this.Options = new UnoAppManagerOptions(options);
    }

    /// <summary>
    /// Gets the instance of the started application.
    /// <para>
    /// This could be a <see cref="WindowsDriver{W}"/>, <see cref="AndroidDriver{W}"/>, <see cref="IOSDriver{W}"/>, or web driver.
    /// </para>
    /// </summary>
    /// <remarks>
    /// This instance should not be used in parallelized test runs. Instead, use the instance returned by the <see cref="StartApp(Func{IWebDriver,bool},TimeSpan?,int)"/> or <see cref="StartApp(AppManagerOptions,Func{IWebDriver,bool},TimeSpan?,int)"/> method.
    /// </remarks>
    protected RemoteWebDriver App => UnoAppManager.App;

    /// <summary>
    /// Gets the instances of started applications.
    /// </summary>
    /// <remarks>
    /// This is useful for accessing drivers in parallelized tests.
    /// </remarks>
    protected IReadOnlyCollection<RemoteWebDriver> Apps => UnoAppManager.Apps;

    /// <summary>
    /// Gets or sets the model that represents the configuration options for the <see cref="UnoAppManager"/>.
    /// </summary>
    protected UnoAppManagerOptions Options { get; set; }

    /// <summary>
    /// Starts the application ready for testing.
    /// </summary>
    /// <param name="waitUntil">
    /// An optional condition of the driver to wait on until it is met.
    /// </param>
    /// <param name="waitUntilTimeout">
    /// An optional timeout wait on the conditional wait until being true. If not set, the wait will run immediately, and if not valid, will throw an exception.
    /// </param>
    /// <param name="waitUntilRetries">
    /// An optional count of retries after a timeout on the wait until condition before accepting the failure.
    /// </param>
    /// <returns>The configured and running application driver.</returns>
    /// <exception cref="WebDriverException">Thrown when the wait until condition is not met in the allocated timeout period if provided.</exception>
    /// <exception cref="DriverLoadFailedException">Thrown when the application is null, the session ID is null once initialized, or the driver fails to configure correctly before returning.</exception>
    /// <exception cref="LegerityException">Thrown when:
    /// - The Appium server could not be found when running with <see cref="AndroidAppManagerOptions.LaunchAppiumServer"/> or <see cref="IOSAppManagerOptions.LaunchAppiumServer"/> true.
    /// - The WinAppDriver could not be found when running with <see cref="WindowsAppManagerOptions.LaunchWinAppDriver"/> true.
    /// - The WinAppDriver failed to load when running with <see cref="WindowsAppManagerOptions.LaunchWinAppDriver"/> true.
    /// </exception>
    public virtual RemoteWebDriver StartApp(
        Func<IWebDriver, bool> waitUntil = default,
        TimeSpan? waitUntilTimeout = default,
        int waitUntilRetries = 0)
    {
        return this.StartApp(this.Options, waitUntil, waitUntilTimeout, waitUntilRetries);
    }

    /// <summary>
    /// Starts the application ready for testing.
    /// </summary>
    /// <param name="options">
    /// The optional options to configure the driver with.
    /// <para>
    /// Settings this will override the <see cref="Options"/> if previously set.
    /// </para>
    /// </param>
    /// <param name="waitUntil">
    /// An optional condition of the driver to wait on until it is met.
    /// </param>
    /// <param name="waitUntilTimeout">
    /// An optional timeout wait on the conditional wait until being true. If not set, the wait will run immediately, and if not valid, will throw an exception.
    /// </param>
    /// <param name="waitUntilRetries">
    /// An optional count of retries after a timeout on the wait until condition before accepting the failure.
    /// </param>
    /// <returns>The configured and running application driver.</returns>
    /// <exception cref="DriverLoadFailedException">Thrown when the application is null, the session ID is null once initialized, or the driver fails to configure correctly before returning.</exception>
    /// <exception cref="LegerityException">Thrown when:
    /// - The Appium server could not be found when running with <see cref="AndroidAppManagerOptions.LaunchAppiumServer"/> or <see cref="IOSAppManagerOptions.LaunchAppiumServer"/> true.
    /// - The WinAppDriver could not be found when running with <see cref="WindowsAppManagerOptions.LaunchWinAppDriver"/> true.
    /// - The WinAppDriver failed to load when running with <see cref="WindowsAppManagerOptions.LaunchWinAppDriver"/> true.
    /// </exception>
    /// <exception cref="WebDriverException">Thrown when the wait until condition is not met in the allocated timeout period if provided.</exception>
    public virtual RemoteWebDriver StartApp(
        UnoAppManagerOptions options,
        Func<IWebDriver, bool> waitUntil = default,
        TimeSpan? waitUntilTimeout = default,
        int waitUntilRetries = 0)
    {
        if (options != default && this.Options != options)
        {
            this.Options = options;
        }

        return UnoAppManager.StartApp(this.Options, waitUntil, waitUntilTimeout, waitUntilRetries);
    }

    /// <summary>
    /// Stops the <see cref="App"/> and any running Appium or WinAppDriver server.
    /// </summary>
    public virtual void StopApp()
    {
        this.StopApp(true);
    }

    /// <summary>
    /// Stops the <see cref="App"/>, with an option to stop the running Appium or WinAppDriver server.
    /// </summary>
    /// <param name="stopServer">
    /// An optional value indicating whether to stop the running Appium or WinAppDriver server.
    /// </param>
    public virtual void StopApp(bool stopServer)
    {
        this.StopApp(this.App, stopServer);
    }

    /// <summary>
    /// Stops an application, with an option to stop the running Appium or WinAppDriver server.
    /// </summary>
    /// <param name="app">
    /// The <see cref="IWebDriver"/> instance to stop running.
    /// </param>
    /// <param name="stopServer">
    /// An optional value indicating whether to stop the running Appium or WinAppDriver server. Default, <b>false</b>.
    /// </param>
    public virtual void StopApp(RemoteWebDriver app, bool stopServer = false)
    {
        UnoAppManager.StopApp(app, stopServer);
    }

    /// <summary>
    /// Skips a specific test for a given platform based on the provided <see cref="AppManagerOptions"/> type.
    /// </summary>
    /// <param name="ignoreAction">The action called to handle the ignore for the test. If not handled, a <see cref="PlatformIgnoredException"/> will be thrown.</param>
    /// <param name="message">The optional message to include in the ignored result.</param>
    /// <param name="appManagerOptionsSkipTypes">The <see cref="AppManagerOptions"/> type to skip for.</param>
    /// <exception cref="PlatformIgnoredException">Thrown when the test specific <paramref name="ignoreAction"/> is not provided.</exception>
    /// <exception cref="Exception">Thrown when the <paramref name="ignoreAction"/> callback throws an exception.</exception>
    public void SkipForPlatform(
        Action<string> ignoreAction = default,
        string message = default,
        params Type[] appManagerOptionsSkipTypes)
    {
        if (this.Options == null || !appManagerOptionsSkipTypes.Contains(this.Options.AppManagerOptions.GetType()))
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