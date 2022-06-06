<img src="assets/ProjectBanner.png" alt="Legerity for Uno project banner" />

# Legerity for Uno Platform

<div style="margin-bottom:16px;">
    <div>
        <div><span>/<span>ləˈdʒɛr ɪ ti</span>/ (l<i>uh</i>-<b>jer</b>-i-tee)</span></div>
    </div>
    <div>
        <div>
            <div>
                <div><i><span>noun</span></i></div>
            </div>
        </div>
        <ol>
            <li>
                <div style="margin-left:20px">
                    <div class="LTKOO sY7ric">
                        <div style="display:inline" data-dobid="dfn"><span>physical or mental quickness; nimbleness;
                                agility.</span></div>
                    </div>
                </div>
            </li>
        </ol>
    </div>
</div>

[![GitHub release](https://img.shields.io/github/release/MADE-Apps/legerity-uno.svg)](https://github.com/MADE-Apps/legerity-uno/releases)
[![Nuget](https://img.shields.io/nuget/v/Legerity.Uno.svg)](https://www.nuget.org/packages/Legerity.Uno/)
[![Nuget Preview](https://img.shields.io/nuget/vpre/Legerity.Uno.svg?label=nuget%20%28preview%29)](https://www.nuget.org/packages/Legerity.Uno/)
[![NuGet Downloads](https://img.shields.io/nuget/dt/Legerity.Uno.svg)](https://www.nuget.org/packages/Legerity.Uno)
[![Build status](https://github.com/MADE-Apps/legerity-uno/actions/workflows/ci.yml/badge.svg?branch=main)](https://github.com/MADE-Apps/legerity-uno/actions/workflows/ci.yml)
[![Legerity docs](https://img.shields.io/badge/docs-Legerity%20Uno-blue.svg)](https://made-apps.github.io/legerity-uno/)
[![Legerity discussions](https://img.shields.io/badge/discuss-Legerity%20Uno-blue.svg)](https://github.com/MADE-Apps/legerity-uno/discussions)

Legerity for Uno Platform is a cross-platform automated UI testing framework for building maintainable, write once, run everywhere tests quickly for [Uno Platform applications](https://www.platform.uno) with .NET.

It simplifies the development by providing easy-to-use element wrappers for Uno Platform app controls that allow developers to quickly get up and running with UI tests in no time.

Legerity also provides a best practice page object pattern for building UI tests with a maintainable structure. Together with app control wrappers, Legerity for Uno Platform provides the best experience for building maintainable UI automation with speed for Uno Platform apps.

**[Discover what's new in Legerity for Uno Platform](https://github.com/MADE-Apps/legerity-uno/releases)**

## Features ⭐

- **UnoAppManager** - A wrapper around the [Selenium WebDriver](https://github.com/SeleniumHQ/selenium) and [Appium WebDrivers](https://github.com/appium/appium-dotnet-driver) to simplify starting your UI tests. Supports running a single set of UI tests across multiple platforms, or browsers.
- **Page Object Pattern** - Provides a `BasePage` that can be used to create page objects associated with pages in your application that are easy to implement and maintain.
- **[Page Object Generator](tools/Legerity.Uno.PageObjectGenerator)** - A dotnet CLI tool that will automatically create page objects by understanding your Uno Platform page files!
- **Element Wrappers** - Contains a collection of out-of-the-box wrappers for Uno Platform UI elements across all platforms that are easy to use with interactions.
- **Testing Frameworks** - Legerity for Uno Platform is agnostic of .NET testing frameworks (e.g. NUnit, xUnit, MSTest, etc.) so you can work with what you know.
- **CI** - Legerity for Uno Platform is also agnostic of host CI runner platforms (e.g. GitHub Actions, Azure Pipelines, etc.) and can be run anywhere.
- **Extendable** - `UnoElementWrapper` provides everything you need to build out element wrappers for your own Uno Platform controls.

## Documentation 📃

If you want to deep dive into the Legerity for Uno Platform framework with details on how to use the features, you can browse the [documentation](https://made-apps.github.io/legerity-uno/) for help getting up and running!

Our documentation includes usages examples, as well as API documentation for your technical reference.

## Installation 💾

Legerity for Uno Platform is publicly available via NuGet. Each available package is detailed below.

| Package | Downloads |
| ------ | ------ |
| [![Nuget](https://img.shields.io/nuget/v/Legerity.Uno.svg?label=Legerity+Uno)](https://www.nuget.org/packages/Legerity.Uno/) | [![NuGet Downloads](https://img.shields.io/nuget/dt/Legerity.Uno.svg)](https://www.nuget.org/packages/Legerity.Uno) |

## Support Legerity for Uno Platform 💗

As many developers know, projects like Legerity for Uno Platform are built and maintained in spare time. If you find this project useful, please **Star** the repo and if possible, sponsor the project development on GitHub.

## Contributing 🚀

Looking to help build Legerity for Uno Platform? Take a look through our [contribution guidelines](CONTRIBUTING.md). We actively encourage you to jump in and help with any issues!

## Building Legerity for Uno Platform 🛠

Legerity for Uno Platform is built using .NET Standard, taking advantage of the new SDK-style projects.

You can build the solution using Visual Studio with the following workloads installed:

- .NET desktop development
- .NET Core cross-platform development

## Got components? 💭

Do you have a collection of custom components that you'd like to see added to the Legerity for Uno Platform framework? Feel free to drop a feature request into our [work tracker](https://github.com/MADE-Apps/legerity-uno/issues)!

Even better, why not help build out your custom control wrapper elements within the framework and help out the community!

### UI Automation tooling 🧰

When contributing to new element wrappers, we recommended using the [Accessibility Insights tool](https://accessibilityinsights.io/en/). The tool is capable of inspecting and providing property values for Android, Web, and Windows applications.

Alternatively, you can use the [Inspect.exe tool](https://docs.microsoft.com/en-us/windows/win32/winauto/inspect-objects) for Windows applications installed with the Windows SDKs. This is not recommended as the tool is considered legacy and can often cause oddities in UI when using.

For your Uno Platform web application, you can also use F12 developer tools to inspect your application layout tree.

## License

Legerity for Uno Platform is made available under the terms and conditions of the [MIT license](LICENSE).
