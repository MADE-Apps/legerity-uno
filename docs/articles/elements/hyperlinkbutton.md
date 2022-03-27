---
uid: legerity-elements-hyperlinkbutton
title: HyperlinkButton
---

# HyperlinkButton

A `HyperlinkButton` is a simple button control that launches a URL and can be used directly within a view.

Legerity provides an element wrapper for the `HyperlinkButton` implementation providing a simple abstraction that allows the button to be clicked.

```csharp
public HyperlinkButton UrlButton => App.FindElementByAutomationId("UrlButton");

UrlButton.Click();
```

## Platform Support

| Platform | Supported |
|-|-|
| Windows | &check; |
| Android | &check; |
| iOS | &check; |
| WebAssembly | &check; |

## Properties

| Name | Type | Description |
|-|-|-|
| `Driver` | `RemoteWebDriver` | The instance of the driver for the app |
| `Element` | `RemoteWebElement` | The original reference object |
| `IsEnabled` | `bool` | Whether the element is enabled |
| `IsVisible` | `bool` | Whether the element is visible |

## Actions

| Name | Description |
|-|-|
| Click() | Clicks the button |

For more information, view the reference documentation: [HyperlinkButton](xref:Legerity.Uno.Elements.HyperlinkButton)
