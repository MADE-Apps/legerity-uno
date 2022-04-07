---
uid: legerity-page-object-pattern
title: Implementing the Page Object Pattern
---

# Implementing the Page Object Pattern with Legerity

The goal of the page object pattern is to use page objects to extract page interactions from your tests. Ideally, they will store all your locators to find UI elements and their interactions for a page.

## Using the Legerity BasePage

As a part of Legerity's core framework, the [`BasePage`](https://github.com/MADE-Apps/legerity/blob/main/src/Legerity.Core/Pages/BasePage.cs) class is your starting point for replicating your app pages for your UI tests.

Here's an example of a page object that replicates an app page and the interactions that are available on it.

```csharp
namespace UnoAppTests.Pages
{
    using Legerity.Pages;
    using Legerity.Uno;
    using Legerity.Uno.Elements;
    using Legerity.Uno.Extensions;
    using Legerity.Windows;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Appium.Android;
    using OpenQA.Selenium.Appium.Windows;

    public class LoginPage : BasePage
    {
        protected override By Trait => DetermineTrait("PageHeader");

        public TextBox UsernameInput => App.FindElementByAutomationId("UsernameInput");
        public TextBox PasswordInput => App.FindElementByAutomationId("PasswordInput");
        public Button LoginButton => App.FindElementByAutomationId("LoginButton");

        public LoginPage SetUsername(string username)
        {
            UsernameInput.SetText(username);
            return this;
        }

        public LoginPage SetPassword(string password)
        {
            PasswordInput.SetText(password);
            return this;
        }

        public HomePage Login(string username, string password)
        {
            SetUsername(username);
            SetPassword(password);
            LoginButton.Click();
            return new HomePage();
        }

        private By DetermineTrait(string automationId)
        {
            return this.App switch
            {
                AndroidDriver<AndroidElement> _ => ByExtras.AndroidXamlAutomationId(automationId),
                IOSDriver<IOSElement> _ => ByExtras.IOSXamlAutomationId(automationId),
                WindowsDriver<WindowsElement> _ => WindowsByExtras.AutomationId(automationId),
                _ => ByExtras.WebXamlAutomationId(automationId)
            };
        }
    }
}
```

The page object contains the queries for all of the elements that can be interacted with, as well as common actions that can be performed on the page such as setting the username and password text, as well as logging in.

## Configuring a common page trait

Each page has a trait. This is a UI element that is always displayed on this page. This can often be a **title** element for the view or a specific menu item in a selected state.

The `Trait` is used when the page is constructed to ensure that the page is currently in view.

By default, there will be a 2-second wait for the element to appear before the test will fail. This can be configured by providing a call to the base constructor's `traitTimeout` parameter with a `TimeSpan` that works for you.

## Using the page object in your UI tests

Taking the page example above, we can start writing our cross-platform UI tests. The example below shows how to do this with the NUnit test framework.

```csharp
namespace UnoAppTests.Tests
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;
    using Legerity;
    using Legerity.Android;
    using Legerity.Web;
    using Legerity.Windows;
    using NUnit.Framework;
    using UnoAppTests.Pages;

    [TestFixtureSource(nameof(TestPlatformOptions))]
    public class LoginPageTests : BaseTestClass
    {
        public LoginPageTests(AppManagerOptions options) : base(options)
        {
        }

        static IEnumerable<AppManagerOptions> TestPlatformOptions => new List<AppManagerOptions>
        {
            new AndroidAppManagerOptions
            {
                AppId = AndroidApplication,
                AppActivity = AndroidApplicationActivity,
                DriverUri = "http://localhost:4723/wd/hub",
                LaunchAppiumServer = true
            },
            new IOSAppManagerOptions
            {
                AppId = IOSApplication,
                DeviceName = "iPhone SE (3rd generation) Simulator",
                DeviceId = "56755E6F-741B-478F-BB1B-A48E05ACFE8A",
                OSVersion = "15.4",
                DriverUri = "http://localhost:4723/wd/hub",
                LaunchAppiumServer = false
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
        public void ShouldLoginAndShowHomepageContent()
        {
            var homepage = new LoginPage().Login("legerity", "lovesunoplatform");
            homepage.Content.ShouldBe("Welcome to Legerity for Uno Platform!");
        }
    }
}
```

For more information on how to use the page object pattern in your tests, this [page object pattern guide](https://www.jamescroft.co.uk/implementing-the-page-object-pattern-in-ui-tests/) provides a detailed understanding of the pattern and why you should use it.
