// MADE Apps licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Legerity.Uno;

using System;
using System.Collections.Generic;
using Android;
using IOS;
using Legerity.Exceptions;
using Legerity.Windows;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.iOS;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;

/// <summary>
/// Defines a manager for the application under test.
/// </summary>
public static class UnoAppManager
{
    /// <summary>
    /// Gets the instance of the started Windows application.
    /// </summary>
    /// <remarks>
    /// This instance should not be used in parallelized test runs. Instead, use the instance returned by the <see cref="StartApp"/> method.
    /// </remarks>
    public static WindowsDriver<WindowsElement> WindowsApp => AppManager.WindowsApp;

    /// <summary>
    /// Gets the instance of the started Android application.
    /// </summary>
    /// <remarks>
    /// This instance should not be used in parallelized test runs. Instead, use the instance returned by the <see cref="StartApp"/> method.
    /// </remarks>
    public static AndroidDriver<AndroidElement> AndroidApp => AppManager.AndroidApp;

    /// <summary>
    /// Gets the instance of the started iOS application.
    /// </summary>
    /// <remarks>
    /// This instance should not be used in parallelized test runs. Instead, use the instance returned by the <see cref="StartApp"/> method.
    /// </remarks>
    public static IOSDriver<IOSElement> IOSApp => AppManager.IOSApp;

    /// <summary>
    /// Gets the instance of the started web application.
    /// </summary>
    /// <remarks>
    /// This instance should not be used in parallelized test runs. Instead, use the instance returned by the <see cref="StartApp"/> method.
    /// </remarks>
    public static RemoteWebDriver WebApp => AppManager.WebApp;

    /// <summary>
    /// Gets the instance of the started application.
    /// <para>
    /// This could be a <see cref="WindowsDriver{W}"/>, <see cref="AndroidDriver{W}"/>, <see cref="IOSDriver{W}"/>, or web driver.
    /// </para>
    /// </summary>
    /// <remarks>
    /// This instance should not be used in parallelized test runs. Instead, use the instance returned by the <see cref="StartApp"/> method.
    /// </remarks>
    public static RemoteWebDriver App => AppManager.App;

    /// <summary>
    /// Gets the instances of started applications.
    /// </summary>
    public static IReadOnlyCollection<RemoteWebDriver> Apps => AppManager.Apps;

    /// <summary>
    /// Gets or sets the instance of the options that started the application.
    /// </summary>
    public static UnoAppManagerOptions Options { get; set; }

    /// <summary>
    /// Starts the application ready for testing.
    /// </summary>
    /// <param name="opts">
    /// The options to configure the driver with.
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
    /// <exception cref="DriverLoadFailedException">
    /// Thrown when the application is null, the session ID is null once initialized, or the driver fails to configure correctly before returning.
    /// </exception>
    /// <exception cref="WebDriverException">Thrown when the wait until condition is not met in the allocated timeout period if provided.</exception>
    /// <returns>The configured and running application driver.</returns>
    /// <exception cref="LegerityException">
    /// Thrown when:
    /// - The Appium server could not be found when running with <see cref="AndroidAppManagerOptions.LaunchAppiumServer"/> or <see cref="IOSAppManagerOptions.LaunchAppiumServer"/> true.
    /// - The WinAppDriver could not be found when running with <see cref="WindowsAppManagerOptions.LaunchWinAppDriver"/> true.
    /// - The WinAppDriver failed to load when running with <see cref="WindowsAppManagerOptions.LaunchWinAppDriver"/> true.
    /// </exception>
    public static RemoteWebDriver StartApp(
        UnoAppManagerOptions opts,
        Func<IWebDriver, bool> waitUntil = default,
        TimeSpan? waitUntilTimeout = default,
        int waitUntilRetries = 0)
    {
        Options = opts;
        return AppManager.StartApp(opts.AppManagerOptions, waitUntil, waitUntilTimeout, waitUntilRetries);
    }

    /// <summary>
    /// Stops the <see cref="App"/>, with an option to stop the running Appium or WinAppDriver server.
    /// </summary>
    /// <param name="stopServer">
    /// An optional value indicating whether to stop the running Appium or WinAppDriver server. Default, <b>true</b>.
    /// </param>
    public static void StopApp(bool stopServer = true)
    {
        AppManager.StopApp(App, stopServer);
        Options = null;
    }

    /// <summary>
    /// Stops an application driver, with an option to stop the running Appium or WinAppDriver server.
    /// </summary>
    /// <param name="app">
    /// The <see cref="IWebDriver"/> instance to stop running.
    /// </param>
    /// <param name="stopServer">
    /// An optional value indicating whether to stop the running Appium or WinAppDriver server. Default, <b>false</b>.
    /// </param>
    public static void StopApp(RemoteWebDriver app, bool stopServer = false)
    {
        AppManager.StopApp(app, stopServer);
        Options = null;
    }

    /// <summary>
    /// Stops all running application drivers.
    /// </summary>
    public static void StopApps()
    {
        AppManager.StopApps();
    }
}