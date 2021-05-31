---
uid: building-with-legerity
title: Writing UI tests | Legerity for Uno
---

# Writing UI tests with Legerity for Uno

## Finding web elements by XAML ID or Name

When viewing the visual tree of your Uno Platform application for web with `F12` developer tooling, you will need to enable UI element feature configurations in your application to display `x:Uid` and `x:Name` attributes in the DOM.

This is achieved by adding the following lines to the constructor of your `App.xaml.cs` file.

```csharp
#if DEBUG && __WASM__
        Uno.UI.FeatureConfiguration.UIElement.AssignDOMXamlName = true;
#endif

```

More information on this can be found in the [Uno Platform docs](https://platform.uno/docs/articles/uno-development/debugging-inspect-visual-tree.html#web).