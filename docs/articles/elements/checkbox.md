---
uid: legerity-elements-checkbox
title: CheckBox
---

# CheckBox

A `CheckBox` is a control that holds a checked state, as well as an indeterminate state. This can be used for managing selections within a form.

Legerity provides an element wrapper for the `CheckBox` implementation providing a simple abstraction that allows the control to be checked on and off.

```csharp
public CheckBox AcceptCheckBox => App.FindElementByAutomationId("AcceptCheckBox");

AcceptCheckBox.CheckOn();
AcceptCheckBox.CheckOff();
var isAcceptChecked = AcceptCheckBox.IsChecked;
var isAcceptIndeterminate = AcceptCheckBox.IsIndeterminate;
```

## Platform Support

| Platform | Supported |
|-|-|
| Windows | &check; |
| Android | &check; |
| iOS | &cross; |
| WebAssembly | &check; |

## Properties

| Name | Type | Description |
|-|-|-|
| `IsChecked` | `bool` | Whether the checkbox is checked |
| `IsIndeterminate` | `bool` | Whether the checkbox is in an indeterminate state |
| `Driver` | `RemoteWebDriver` | The instance of the driver for the app |
| `Element` | `RemoteWebElement` | The original reference object |
| `IsEnabled` | `bool` | Whether the element is enabled |
| `IsVisible` | `bool` | Whether the element is visible |

## Actions

| Name | Description |
|-|-|
| CheckOn() | Checks the checkbox |
| CheckOff() | Unchecks the checkbox |

For more information, view the reference documentation: [CheckBox](xref:Legerity.Uno.Elements.CheckBox)
