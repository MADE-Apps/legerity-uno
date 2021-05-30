namespace UnoSampleAppTests.Web
{
    using System;
    using System.IO;
    using Legerity;
    using Legerity.Web;
    using NUnit.Framework;

    public abstract class WebTestClass
    {
        public abstract string LaunchUrl { get; }

        [SetUp]
        public virtual void Initialize()
        {
            AppManager.StartApp(
                new WebAppManagerOptions(WebAppDriverType.Edge,
                    Path.Combine(Environment.CurrentDirectory, "Tools\\Edge"))
                {
                    Maximize = true,
                    Url = this.LaunchUrl,
                    ImplicitWait = TimeSpan.FromSeconds(10)
                });
        }

        [TearDown]
        public virtual void Cleanup()
        {
            AppManager.StopApp();
        }
    }
}
