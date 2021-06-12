namespace Legerity.Uno
{
    using OpenQA.Selenium.Appium.Android;
    using OpenQA.Selenium.Appium.iOS;
    using OpenQA.Selenium.Appium.Windows;
    using OpenQA.Selenium.Remote;

    /// <summary>
    /// Defines a base class for running tests with the Legerity framework for the Uno Platform.
    /// </summary>
    public abstract class UnoTestClass
    {
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
        protected static RemoteWebDriver App => UnoAppManager.App;

        /// <summary>
        /// Gets the model that represents the configuration options for the <see cref="UnoAppManager"/>.
        /// </summary>
        protected UnoAppManagerOptions Options { get; }

        /// <summary>
        /// Starts the application ready for testing.
        /// </summary>
        public virtual void StartApp()
        {
            UnoAppManager.StartApp(this.Options);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public virtual void StopApp()
        {
            UnoAppManager.StopApp();
        }
    }
}
