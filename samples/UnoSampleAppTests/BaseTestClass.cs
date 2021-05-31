namespace UnoSampleAppTests
{
    using System.Collections.Generic;
    using Legerity;
    using Legerity.Uno;
    using NUnit.Framework;

    public abstract class BaseTestClass
    {
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