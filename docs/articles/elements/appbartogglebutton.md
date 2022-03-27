---
uid: legerity-elements-appbartogglebutton
title: AppBarToggleButton
---

# AppBarToggleButton

An `AppBarToggleButton` is a button control that holds a checked state and can be used within an `AppBar`, `CommandBar`, or directly within a view.

Legerity provides an element wrapper for the `AppBarToggleButton` implementation providing a simple abstraction that allows the button to be checked on and off.

```csharp
public AppBarToggleButton BoldButton => App.FindElementByAutomationId("BoldButton");

BoldButton.Click();
BoldButton.ToggleOn();
BoldButton.ToggleOff();
var isBoldOn = BoldButton.IsOn;
```

## Platform Support

| Platform | Supported |
|-|-|
| Windows | &check; |
| Android | &cross; |
| iOS | &cross; |
| WebAssembly | &check; |

## Properties

| Name | Type | Description |
|-|-|-|
| `IsOn` | `bool` | Whether the button is toggled on |
| `Driver` | `RemoteWebDriver` | The instance of the driver for the app |
| `Element` | `RemoteWebElement` | The original reference object |
| `IsEnabled` | `bool` | Whether the element is enabled |
| `IsVisible` | `bool` | Whether the element is visible |

## Actions

| Name | Description |
|-|-|
| Click() | Clicks the button |
| ToggleOn() | Toggles the button into the on state |
| ToggleOff() | Toggles the button into the off state |

For more information, view the reference documentation: [AppBarToggleButton](xref:Legerity.Uno.Elements.AppBarToggleButton)
