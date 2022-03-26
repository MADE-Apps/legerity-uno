---
uid: legerity-prepare-uno-platform-apps
title: Preparing your Uno Platform apps
---

# Preparing your Uno Platform apps

By default, Uno Platform apps don't expose the XAML IDs that you may have configured in your app's UI in order to reference them in your UI tests. However, Uno Platform provides a mechanism to do this with alterations to each app's `.csproj` file and a change in your `App.xaml.cs` file.

## Project file changes

To allow mapping of your automation properties to controls in your Uno Platform apps, you must add the following line to the default `PropertyGroup` of each project's `.csproj` file.

```xml
<IsUiAutomationMappingEnabled>true</IsUiAutomationMappingEnabled>
```

Setting this will replace certain properties in each platform's app with the `x:Uid` or `AutomationProperties.AutomationId` XAML attribute value.

**For Android**, this sets the `View.ContentDescription` property

**For iOS**, it sets the `UIView.AccessibilityIdentifier` property

**For WebAssembly**, it sets `aria-label` and the `xamlautomationid` property

For more information on this, see the [Uno Platform docs](https://platform.uno/docs/articles/features/working-with-accessibility.html#automationid).

## Additional changes for WebAssembly

When viewing the visual tree of your Uno Platform app for WebAssembly with `F12` developer tools, you will need to enable UI element feature configurations in your application to display `x:Uid` and `x:Name` attributes in the DOM.

This is achieved by adding the following lines to the constructor of your `App.xaml.cs` file.

```csharp
#if DEBUG && __WASM__
Uno.UI.FeatureConfiguration.UIElement.AssignDOMXamlName = true;
Uno.UI.FeatureConfiguration.UIElement.AssignDOMXamlProperties = true;
#endif
```

More information on this can be found in the [Uno Platform docs](https://platform.uno/docs/articles/uno-development/debugging-inspect-visual-tree.html#web).
