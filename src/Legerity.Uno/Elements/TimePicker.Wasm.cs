namespace Legerity.Uno.Elements
{
    using Legerity.Extensions;
    using Legerity.Uno.Extensions;
    using OpenQA.Selenium;

    public partial class TimePicker
    {
        private static By FlyoutLocatorWasm()
        {
            return ByExtensions.WebXamlType("Windows.UI.Xaml.Controls.TimePickerFlyoutPresenter");
        }

        private static By HourSelectorLocatorWasm()
        {
            return ByExtensions.WebXamlName(HourLoopingSelectorName);
        }

        private static By MinuteSelectorLocatorWasm()
        {
            return ByExtensions.WebXamlName(MinuteLoopingSelectorName);
        }

        private static By AcceptButtonLocatorWasm()
        {
            return ByExtensions.WebXamlName(AcceptButtonName);
        }

        private static IWebElement FindSelectorChildElementByValueWasm(IWebElement element, string value)
        {
            return element.FindElementByText(value);
        }

        private (string hour, string minute) DetermineSelectedTimeWasm()
        {
            string hour = this.Element.FindElementByXamlName("HourTextBlock").Text;
            string minute = this.Element.FindElementByXamlName("MinuteTextBlock").Text;

            return (hour, minute);
        }
    }
}