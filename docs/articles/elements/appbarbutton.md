---
uid: legerity-elements-appbarbutton
title: AppBarButton
---

# AppBarButton

An `AppBarButton` is a simple button control that can be used within an `AppBar`, `CommandBar`, or directly within a view.

Legerity provides an element wrapper for the `AppBarButton` implementation providing a simple abstraction that allows the button to be clicked.

```csharp
public AppBarButton SaveButton => App.FindElementByAutomationId("SaveButton");

SaveButton.Click();
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

For more information, view the reference documentation: [AppBarButton](xref:Legerity.Uno.Elements.AppBarButton)
