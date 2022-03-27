---
uid: legerity-elements-textblock
title: TextBlock
---

# TextBlock

A `TextBlock` is a simple content control that displays text in a readonly state.

Legerity provides an element wrapper for the `TextBlock` implementation providing a simple abstraction that exposes the text value.

```csharp
public TextBlock ContentTextBlock => App.FindElementByAutomationId("ContentTextBlock");

var content = ContentTextBlock.Text;
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
| `Text` | `string` | The content of the `TextBlock` |
| `Driver` | `RemoteWebDriver` | The instance of the driver for the app |
| `Element` | `RemoteWebElement` | The original reference object |
| `IsEnabled` | `bool` | Whether the element is enabled |
| `IsVisible` | `bool` | Whether the element is visible |

For more information, view the reference documentation: [TextBlock](xref:Legerity.Uno.Elements.TextBlock)
