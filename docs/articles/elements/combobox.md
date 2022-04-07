---
uid: legerity-elements-combobox
title: ComboBox
---

# ComboBox

A `ComboBox` is a control that allows a value to be selected from a drop down style list.

Legerity provides an element wrapper for the `ComboBox` implementation providing a simple abstraction that allows values to be selected.

```csharp
public ComboBox ColorComboBox => App.FindElementByAutomationId("ColorComboBox");

ColorComboBox.SelectItem("Green");
var selectedItem = ColorComboBox.SelectedItem;
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
| `SelectedItem` | `string` | The currently selected item |
| `Driver` | `RemoteWebDriver` | The instance of the driver for the app |
| `Element` | `RemoteWebElement` | The original reference object |
| `IsEnabled` | `bool` | Whether the element is enabled |
| `IsVisible` | `bool` | Whether the element is visible |

## Actions

| Name | Description |
|-|-|
| SelectItem(string) | Selects an item by the specified item name |

For more information, view the reference documentation: [ComboBox](xref:Legerity.Uno.Elements.ComboBox)
