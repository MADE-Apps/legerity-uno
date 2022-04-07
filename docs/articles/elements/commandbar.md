---
uid: legerity-elements-commandbar
title: CommandBar
---

# CommandBar

A `CommandBar` is a control that can contain a collection of primary and secondary buttons directly within a view.

Legerity provides an element wrapper for the `CommandBar` implementation providing a simple abstraction that allows the primary and secondary buttons to be actioned.

```csharp
public CommandBar RichEditCommandBar => App.FindElementByAutomationId("RichEditCommandBar");

RichEditCommandBar.ClickPrimaryButton("BoldButton");
RichEditCommandBar.ClickSecondaryButton("SettingsButton");
var primaryButtons = RichEditCommandBar.PrimaryButtons;
var secondaryButtons = RichEditCommandBar.SecondaryButtons;
var moreButton = RichEditCommandBar.MoreButton;
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
| `PrimaryButtons` | `IEnumerable<AppBarButton>` | The element wrappers for primary button options |
| `SecondaryButtons` | `IEnumerable<AppBarButton>` | The element wrappers for secondary button options, shown when the more button has been pressed |
| `MoreButton` | `AppBarButton` | The element wrappers for the ellipsis more options button |
| `Driver` | `RemoteWebDriver` | The instance of the driver for the app |
| `Element` | `RemoteWebElement` | The original reference object |
| `IsEnabled` | `bool` | Whether the element is enabled |
| `IsVisible` | `bool` | Whether the element is visible |

## Actions

| Name | Description |
|-|-|
| ClickPrimaryButton(string) | Clicks a primary button by name |
| ClickSecondaryButton(string) | Opens the secondary menu and clicks a secondary button by name |

For more information, view the reference documentation: [CommandBar](xref:Legerity.Uno.Elements.CommandBar)
