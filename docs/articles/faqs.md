---
uid: legerity-faqs
title: FAQs
---

# FAQs

## Why should I use Legerity?

Do you find yourself writing multiple tests to cover the functionality of your cross-platform apps? Do you find it difficult to maintain them when you've written them?

That's where Legerity started from, a toolkit on top of Selenium that would make UI testing simple and quick to get started. This allows us to spend more time building applications with confidence that our consumers get the best, thoroughly tested experiences.

## How does Legerity for Uno Platform differ from the core Legerity framework?

Legerity for Uno Platform is built on top of the core [Legerity framework](https://made-apps.github.io/legerity/) to provide a number of additional features bespoke to the cross-platform nature of Uno Platform apps.

This includes the ability to write single tests that can run across all platforms. Using purpose built Uno Platform element wrappers, you can easily map rendered Uno Platform controls from each platform to a single element wrapper meaning you only have to write one test.

## What tools can I use to inspect my app's UI automation tree?

There are many tools that are available to help you understand the layout of your app's UI.

**For Windows apps**, you can refer to your Uno Platform XAML pages and controls for the most part. You'll find the `x:Uid` and `x:Name` attributes you can use to reference your elements in your UI tests. To find more detail about the underlying controls, you can use the Inspect tool installed as part of the Windows SDKs, usually found at `C:\Program Files (x86)\Windows Kits\10\bin\10.0.22000.0\x64`, to inspect your app's UI.

**For Android and iOS apps**, you can use the [Appium Inspector](https://github.com/appium/appium-inspector) to inspect the UI for details about specific UI elements. Using the Inspector, you'll need to install the [Appium Server](https://appium.io/) to allow you to connect the Inspector to your app.

**For WebAssembly apps**, you can simply use the `F12` developer tools in your browser of choice to inspect the UI.

## How do you keep Legerity for Uno Platform going?

Use of Legerity is free of charge to any one under an MIT license. The development of the project is supported by [community contributions](https://github.com/MADE-Apps/legerity-uno) and [sponsorships](https://github.com/sponsors/jamesmcroft) where possible.

## I have a specific question, where can I ask?

If you have a query about UI testing with Legerity for Uno Platform, please [open a discussion in our GitHub project](https://github.com/MADE-Apps/legerity-uno/discussions).
