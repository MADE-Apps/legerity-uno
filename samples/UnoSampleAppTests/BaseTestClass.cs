namespace UnoSampleAppTests
{
    using System;
    using Legerity;
    using Legerity.Uno;
    using NUnit.Framework;

    public abstract class BaseTestClass : UnoTestClass
    {
        public const string AndroidApplication = "com.made.unosampleapp";

        public const string AndroidApplicationActivity = $"{AndroidApplication}.MainActivity";

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
    }
}