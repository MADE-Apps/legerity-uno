---
uid: legerity-elements-button
title: Button
---

# Button

An `Button` is a simple button control that can be used directly within a view.

Legerity provides an element wrapper for the `Button` implementation providing a simple abstraction that allows the button to be clicked.

```csharp
public Button RefreshButton => App.FindElementByAutomationId("RefreshButton");

RefreshButton.Click();
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

For more information, view the reference documentation: [Button](xref:Legerity.Uno.Elements.Button)

