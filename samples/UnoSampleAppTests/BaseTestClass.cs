namespace UnoSampleAppTests
{
    using Legerity;
    using Legerity.Uno;
    using NUnit.Framework;

    public abstract class BaseTestClass
    {
        public const string WasmApplication = "http://localhost:5000";

        public const string WindowsApplication = "com.madeapps.unosampleapp_7mzr475ysvhxg!App";

        protected BaseTestClass(AppManagerOptions options)
        {
            this.Options = new UnoAppManagerOptions(options);
        }
        
        private UnoAppManagerOptions Options { get; }

        [SetUp]
        public virtual void Initialize()
        {
            UnoAppManager.StartApp(this.Options);
        }

        [TearDown]
        public virtual void Cleanup()
        {
            UnoAppManager.StopApp();
        }
    }
}