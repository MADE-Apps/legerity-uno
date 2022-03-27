---
uid: legerity-elements-datepicker
title: DatePicker
---

# DatePicker

A `DatePicker` is a control that allows a user to select a specific date.

Legerity provides an element wrapper for the `DatePicker` implementation providing a simple abstraction that allows a date to be set using a `DateTime` value.

```csharp
public DatePicker DateOfBirthPicker => App.FindElementByAutomationId("DateOfBirthPicker");

DateOfBirthPicker.SetDate(DateTime.Now);
var selectedDate = DateOfBirthPicker.SelectedDate;
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
| `SelectedDate` | `DateTime?` | The currently selected date |
| `Driver` | `RemoteWebDriver` | The instance of the driver for the app |
| `Element` | `RemoteWebElement` | The original reference object |
| `IsEnabled` | `bool` | Whether the element is enabled |
| `IsVisible` | `bool` | Whether the element is visible |

## Actions

| Name | Description |
|-|-|
| SetDate(DateTime) | Sets the date selected in the DatePicker |

For more information, view the reference documentation: [DatePicker](xref:Legerity.Uno.Elements.DatePicker)
