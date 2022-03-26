---
uid: legerity-custom-element-wrappers
title: Building custom Uno Platform element wrappers
---

# Uno Platform element wrappers

The goal of the Uno Platform element wrappers is to provide an easy set of components that surface up properties and actions of the actual controls within the UI to make it easier for you to write tests that interact with them.

## Using the Uno Platform element wrappers

Using an element wrapper in your UI tests is super simple.

Where you want to find an element in the Selenium driver that would usually return a `RemoteWebElement`, `AppiumWebElement` or platform-specific alternative, simply replace the `var` or Type declaration with the intended element wrapper type.

```csharp
CommandBar pageCommandBar = this.App.FindElement(ByExtras.AutomationId("PageCommandBar"));
```

From there, you can access all of the additional actions and properties that are exposed by the element wrapper.

## Creating your own platform element wrappers

While out-of-the-box, Legerity for Uno Platform provides a collection of element wrappers for the core platform controls, we expose the parts of the framework that allow you to create element wrappers for your own custom controls!

### Sample

In this sample, the application under test has a custom combo box.

It's recommended that when creating your own element wrappers, you provide the [implicit operators](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/user-defined-conversion-operators) that will allow you to use your wrapper when finding an element without direct casting.

```csharp
namespace UnoAppTests.Elements
{
    using System;
    using Legerity.Uno.Elements;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Appium.Android;
    using OpenQA.Selenium.Appium.iOS;
    using OpenQA.Selenium.Appium.Windows;
    using OpenQA.Selenium.Remote;

    public class CustomComboBox : UnoElementWrapper
    {
        public ComboBox(IWebElement element) : this(element as RemoteWebElement) { }

        public ComboBox(RemoteWebElement element) : base(element) { }

        public string SelectedItem => DetermineSelectedItem();

        public static implicit operator ComboBox(RemoteWebElement element)
        {
            return new ComboBox(element);
        }

        public void SelectItem(string name)
        {
            Element.Click();
            VerifyElementsShown(this.ComboBoxItemLocator(), TimeSpan.FromSeconds(2));
            DetermineListElement(name).Click();
        }

        private RemoteWebElement DetermineListElement(string name)
        {
            return Element switch
            {
                AndroidElement _ => DetermineListElementAndroid(name),
                IOSElement _ => DetermineListElementIOS(name),
                WindowsElement _ => DetermineListElementWindows(name),
                _ => DetermineListElementWasm(name)
            };
        }

        private string DetermineSelectedItem()
        {
            return this.Element switch
            {
                AndroidElement _ => DetermineSelectedItemAndroid(),
                IOSElement _ => DetermineSelectedItemIOS(),
                WindowsElement _ => DetermineSelectedItemWindows(),
                _ => this.DetermineSelectedItemWasm()
            };
        }

        private By ComboBoxItemLocator()
        {
            return this.Element switch
            {
                AndroidElement _ => ComboBoxItemLocatorAndroid(),
                IOSElement _ => ComboBoxItemLocatorIOS(),
                WindowsElement _ => ComboBoxItemLocatorWindows(),
                _ => ComboBoxItemLocatorWasm()
            };
        }
    }
}
```

To support Uno Platform's various implementations across their supported platforms, you can determine child elements, properties, locators, and actions by performing a `switch` statement on the `Element` property. This will allow you to tailor your element wrapper to the platform you're targeting.
