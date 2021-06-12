namespace UnoSampleAppTests
{
    using System;
    using Legerity;
    using Legerity.Uno;
    using NUnit.Framework;

    public abstract class BaseTestClass : UnoTestClass
    {
        public const string AndroidApplication = "Tools\\Android\\com.made.unosampleapp.apk";

        public const string WasmApplication = "http://localhost:5000";

        public const string WindowsApplication = "com.madeapps.unosampleapp_7mzr475ysvhxg!App";

        protected BaseTestClass(AppManagerOptions options) : base(options)
        {
        }

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

        protected void SkipForPlatform(Type skipType, string message = default)
        {
            if (this.Options == null || this.Options.AppManagerOptions.GetType() != skipType)
            {
                return;
            }

            Assert.Ignore($"Cannot currently run tests for {skipType.Name}. {message}");
        }
    }
}