namespace UnoSampleAppTests
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Legerity;
    using Legerity.Android;
    using Legerity.IOS;
    using Legerity.Uno;
    using Legerity.Web;
    using Legerity.Windows;
    using NUnit.Framework;

    public abstract class BaseTestClass : UnoTestClass
    {
        public const string AndroidApplication = "com.made.unosampleapp";

        public const string AndroidApplicationActivity = $"{AndroidApplication}.MainActivity";

        public const string IOSApplication = "com.madeapps.UnoSampleApp";

        public const string WasmApplication = "http://localhost:5000";

        public const string WindowsApplication = "com.madeapps.unosampleapp_7mzr475ysvhxg!App";

        protected BaseTestClass(AppManagerOptions options) : base(options)
        {
        }

        protected static IEnumerable<AppManagerOptions> TestPlatformOptions => new List<AppManagerOptions>
        {
            //new AndroidAppManagerOptions
            //{
            //    AppId = AndroidApplication,
            //    AppActivity = AndroidApplicationActivity,
            //    DriverUri = "http://localhost:4723/wd/hub",
            //    LaunchAppiumServer = false
            //},
            //new IOSAppManagerOptions
            //{
            //    AppId = IOSApplication,
            //    DeviceName = "iPhone SE (3rd generation) Simulator",
            //    DeviceId = "56755E6F-741B-478F-BB1B-A48E05ACFE8A",
            //    OSVersion = "15.4",
            //    DriverUri = "http://192.168.86.172:4723/wd/hub",
            //    LaunchAppiumServer = false
            //},
            new WebAppManagerOptions(
                WebAppDriverType.EdgeChromium,
                Path.Combine(Environment.CurrentDirectory))
            {
                Maximize = true, Url = WasmApplication, ImplicitWait = TimeSpan.FromSeconds(10)
            },
            //new WebAppManagerOptions(
            //    WebAppDriverType.Chrome,
            //    Path.Combine(Environment.CurrentDirectory))
            //{
            //    Maximize = true, Url = WasmApplication, ImplicitWait = TimeSpan.FromSeconds(10)
            //},
            //new WindowsAppManagerOptions(WindowsApplication)
            //{
            //    DriverUri = "http://127.0.0.1:4723", LaunchWinAppDriver = true, Maximize = true
            //}
        };

        [SetUp]
        public override void StartApp()
        {
            base.StartApp();
        }

        [TearDown]
        public override void StopApp()
        {
            base.StopApp();
        }
    }
}