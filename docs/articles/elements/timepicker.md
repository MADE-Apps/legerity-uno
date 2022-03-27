---
uid: legerity-elements-timepicker
title: TimePicker
---

# TimePicker

A `TimePicker` is a control that allows a user to select a specific time.

Legerity provides an element wrapper for the `TimePicker` implementation providing a simple abstraction that allows a time to be set using a `TimeSpan` value.

```csharp
public TimePicker TimeOfDayPicker => App.FindElementByAutomationId("TimeOfDayPicker");

TimeOfDayPicker.SetTime(new TimeSpan(7, 5, 0));
var selectedDate = TimeOfDayPicker.SelectedTime;
```

## Platform Support

| Platform | Supported |
|-|-|
| Windows | &check; |
| Android | &cross; |
| iOS | &cross; |
| WebAssembly | &cross; |

## Properties

| Name | Type | Description |
|-|-|-|
| `SelectedTime` | `TimeSpan?` | The currently selected time |
| `Driver` | `RemoteWebDriver` | The instance of the driver for the app |
| `Element` | `RemoteWebElement` | The original reference object |
| `IsEnabled` | `bool` | Whether the element is enabled |
| `IsVisible` | `bool` | Whether the element is visible |

## Actions

| Name | Description |
|-|-|
| SetTime(TimeSpan) | Sets the time selected in the TimePicker |

For more information, view the reference documentation: [TimePicker](xref:Legerity.Uno.Elements.TimePicker)
