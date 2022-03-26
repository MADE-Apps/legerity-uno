---
uid: legerity-get-started
title: Get Started
---

# Setup

Legerity for Uno Platform is an extension framework to the core [Legerity framework](https://made-apps.github.io/legerity/). It is designed to be used for writing automated UI tests once for your Uno Platform applications with C#.

## Getting Legerity for Uno Platform

To get started, you will need to install the Legerity for Uno Platform NuGet package into your .NET test project. Don't worry about testing frameworks, Legerity is agnostic so you can use it with what you're comfortable with.

```powershell
# Add the NuGet package to your test project
dotnet add package Legerity.Uno
```

## Setting up a base test class

The next step is setting up your base test class to provide the platform for writing tests against your Uno Platform app.

The example below shows how to do this with the NUnit test framework.

```csharp
namespace UnoAppTests
{
    using Legerity;
    using Legerity.Uno;
    using NUnit.Framework;

    public abstract class BaseTestClass : UnoTestClass
    {
        public const string AndroidApplication = "com.made.myunoapp";
        public const string AndroidApplicationActivity = $"{AndroidApplication}.MainActivity";
        public const string WasmApplication = "http://localhost:5000";
        public const string WindowsApplication = "com.madeapps.myunoapp_7mzr475ysvhxg!App";

        protected BaseTestClass(AppManagerOptions options) : base(options) { }

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
```

The base `UnoTestClass` is part of the Legerity for Uno Platform package. It is a simple wrapper around the `UnoAppManager` for starting and stopping your Uno Platform app based on the provided `AppManagerOptions` configuration.

## Using your test class in action

Finally, you'll be able to start writing your cross-platform UI tests.

```csharp
namespace UnoAppTests
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Legerity;
    using Legerity.Android;
    using Legerity.Web;
    using Legerity.Windows;
    using NUnit.Framework;
    using Shouldly;

    [TestFixtureSource(nameof(TestPlatformOptions))]
    public class HomePageTests : BaseTestClass
    {
        public HomePageTests(AppManagerOptions options) : base(options) { }

        static IEnumerable<AppManagerOptions> TestPlatformOptions => new List<AppManagerOptions>
        {
            new AndroidAppManagerOptions
            {
                AppId = AndroidApplication,
                AppActivity = AndroidApplicationActivity,
                DriverUri = "http://localhost:4723/wd/hub",
                LaunchAppiumServer = true
            },
            new WebAppManagerOptions(
                WebAppDriverType.EdgeChromium,
                Path.Combine(Environment.CurrentDirectory))
            {
                Url = WasmApplication, ImplicitWait = TimeSpan.FromSeconds(5)
            },
            new WebAppManagerOptions(
                WebAppDriverType.Chrome,
                Path.Combine(Environment.CurrentDirectory))
            {
                Url = WasmApplication, ImplicitWait = TimeSpan.FromSeconds(5)
            },
            new WindowsAppManagerOptions(WindowsApplication)
            {
                DriverUri = "http://127.0.0.1:4723", LaunchWinAppDriver = true
            }
        };

        [Test]
        public void ShouldLoadHomePageContent()
        {
            TextBlock content = App.FindElementByAutomationId("HomePageContent");
            content.Text.ShouldBe("Hello, Uno Platform!");
        }
    }
}
```

Here you're seeing the most efficient way to write tests for your Uno Platform app. You're defining the platforms under test and the tests that will run on them.

## Samples

### Legerity for Uno Platform Test App

An [example Uno Platform app](https://github.com/MADE-Apps/legerity-uno/tree/main/samples) showcasing the core controls with UI tests running on Windows, Android, and WebAssembly.
