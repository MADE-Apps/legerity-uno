namespace Legerity.Uno.Elements
{
    using Legerity.Extensions;
    using Legerity.Uno.Extensions;
    using OpenQA.Selenium;

    public partial class TimePicker
    {
        private static By FlyoutLocatorWasm()
        {
            return ByExtras.WebXamlType("Windows.UI.Xaml.Controls.TimePickerFlyoutPresenter");
        }

        private static By HourSelectorLocatorWasm()
        {
            return ByExtras.WebXamlName(HourLoopingSelectorName);
        }

        private static By MinuteSelectorLocatorWasm()
        {
            return ByExtras.WebXamlName(MinuteLoopingSelectorName);
        }

        private static By AcceptButtonLocatorWasm()
        {
            return ByExtras.WebXamlName(AcceptButtonName);
        }

        private static IWebElement FindSelectorChildElementByValueWasm(IWebElement element, string value)
        {
            return element.FindElementByText(value);
        }

        private (string hour, string minute) DetermineSelectedTimeWasm()
        {
            string hour = this.FindElementByXamlName("HourTextBlock").Text;
            string minute = this.FindElementByXamlName("MinuteTextBlock").Text;

            return (hour, minute);
        }
    }
}