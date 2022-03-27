---
uid: legerity-elements-textbox
title: TextBox
---

# TextBox

A `TextBox` is a control that allows a user to input a text value, usually used in a form.

Legerity provides an element wrapper for the `TextBox` implementation providing a simple abstraction that allows a value to be set.

```csharp
public TextBox UsernameTextBox => App.FindElementByAutomationId("UsernameTextBox");

UsernameTextBox.SetText("legerity");
UsernameTextBox.AppendText("lovesunoplatform");
UsernameTextBox.ClearText();
var text = UsernameTextBox.Text;
var isReadonly = UsernameTextBox.IsReadonly;
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
| `Text` | `string` | The value that has been input |
| `IsReadonly` | `bool` | Whether the input is disabled |
| `Driver` | `RemoteWebDriver` | The instance of the driver for the app |
| `Element` | `RemoteWebElement` | The original reference object |
| `IsEnabled` | `bool` | Whether the element is enabled |
| `IsVisible` | `bool` | Whether the element is visible |

## Actions

| Name | Description |
|-|-|
| SetText(string) | Clears the current value and sets a new one |
| AppendText(string) | Appends a value to the current existing value |
| ClearText() | Clears the current value |

For more information, view the reference documentation: [TextBox](xref:Legerity.Uno.Elements.TextBox)
