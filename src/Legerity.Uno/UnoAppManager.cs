namespace Legerity.Uno
{
    using Legerity.Exceptions;
    using Legerity.Windows;
    using OpenQA.Selenium.Appium.Android;
    using OpenQA.Selenium.Appium.iOS;
    using OpenQA.Selenium.Appium.Windows;
    using OpenQA.Selenium.Remote;

    public static class UnoAppManager
    {
        /// <summary>
        /// Gets the instance of the started application.
        /// <para>
        /// This could be a <see cref="WindowsDriver{W}"/>, <see cref="AndroidDriver{W}"/>, <see cref="IOSDriver{W}"/>, or web driver.
        /// </para>
        /// </summary>
        public static RemoteWebDriver App => AppManager.App;

        /// <summary>
        /// Gets the instance of the options that started the application.
        /// </summary>
        internal static UnoAppManagerOptions Options { get; private set; }

        /// <summary>
        /// Starts the application ready for testing.
        /// </summary>
        /// <param name="opts">
        /// The options to configure the driver with.
        /// </param>
        /// <exception cref="DriverLoadFailedException">
        /// Thrown if the application is null or the session ID is null once initialized.
        /// </exception>
        /// <exception cref="T:Legerity.Windows.Exceptions.WinAppDriverNotFoundException">Thrown if the WinAppDriver could not be found when running with <see cref="WindowsAppManagerOptions.LaunchWinAppDriver"/> true.</exception>
        /// <exception cref="T:Legerity.Windows.Exceptions.WinAppDriverLoadFailedException">Thrown if the WinAppDriver failed to load when running with <see cref="WindowsAppManagerOptions.LaunchWinAppDriver"/> true.</exception>
        public static void StartApp(UnoAppManagerOptions opts)
        {
            AppManager.StartApp(opts.AppManagerOptions);
            Options = opts;
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void StopApp()
        {
            AppManager.StopApp();
            Options = null;
        }
    }
}