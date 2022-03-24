namespace Legerity.Uno
{
    using System;
    using System.Linq;
    using Legerity.Uno.Platform;
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

        /// <summary>
        /// Skips a specific test for a given platform based on the provided <see cref="AppManagerOptions"/> type.
        /// </summary>
        /// <param name="ignoreAction">The action called to handle the ignore for the test. If not handled, a <see cref="PlatformIgnoredException"/> will be thrown.</param>
        /// <param name="message">The optional message to include in the ignored result.</param>
        /// <param name="appManagerOptionsSkipTypes">The <see cref="AppManagerOptions"/> type to skip for.</param>
        /// <exception cref="PlatformIgnoredException">Thrown if the test specific <paramref name="ignoreAction"/> is not provided.</exception>
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
}