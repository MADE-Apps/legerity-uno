namespace UnoSampleAppTests.Pages
{
    using System;
    using System.Threading;
    using Legerity.Pages;
    using Legerity.Uno.Elements;
    using Legerity.Uno.Extensions;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Appium.Windows;
    using Shouldly;
    using ByExtensions = Legerity.Windows.Extensions.ByExtensions;

    public class ControlsPage : BasePage
    {
        private const string SampleControlPrefix = "Sample";

        protected override By Trait => DetermineTrait();

        public Button Button => this.App.FindElementByAutomationId($"{SampleControlPrefix}{nameof(this.Button)}");

        public AppBarButton AppBarButton =>
            this.App.FindElementByAutomationId($"{SampleControlPrefix}{nameof(this.AppBarButton)}");

        public AppBarToggleButton AppBarToggleButton =>
            this.App.FindElementByAutomationId($"{SampleControlPrefix}{nameof(this.AppBarToggleButton)}");

        public CheckBox CheckBox => this.App.FindElementByAutomationId($"{SampleControlPrefix}{nameof(this.CheckBox)}");

        public ComboBox ComboBox => this.App.FindElementByAutomationId($"{SampleControlPrefix}{nameof(this.ComboBox)}");

        public CommandBar CommandBar =>
            this.App.FindElementByAutomationId($"{SampleControlPrefix}{nameof(this.CommandBar)}");

        public DatePicker DatePicker =>
            this.App.FindElementByAutomationId($"{SampleControlPrefix}{nameof(this.DatePicker)}");

        public HyperlinkButton HyperlinkButton =>
            this.App.FindElementByAutomationId($"{SampleControlPrefix}{nameof(this.HyperlinkButton)}");

        public TextBlock TextBlock =>
            this.App.FindElementByAutomationId($"{SampleControlPrefix}{nameof(this.TextBlock)}");

        public TextBox TextBox => this.App.FindElementByAutomationId($"{SampleControlPrefix}{nameof(this.TextBox)}");

        public TextBox ReadonlyTextBox =>
            this.App.FindElementByAutomationId($"{SampleControlPrefix}{nameof(this.ReadonlyTextBox)}");

        public TimePicker TimePicker =>
            this.App.FindElementByAutomationId($"{SampleControlPrefix}{nameof(this.TimePicker)}");

        public ControlsPage ToggleAppBarButton(bool toggleOn)
        {
            if (toggleOn)
            {
                this.AppBarToggleButton.ToggleOn();
            }
            else
            {
                this.AppBarToggleButton.ToggleOff();
            }

            return this;
        }

        public ControlsPage VerifyAppBarButtonToggled(bool expectedToggle)
        {
            this.AppBarToggleButton.WaitUntil(button => button.IsOn, TimeSpan.FromSeconds(5));
            this.AppBarToggleButton.IsOn.ShouldBe(expectedToggle);
            return this;
        }

        public ControlsPage TickCheckBox(bool checkOn)
        {
            if (checkOn)
            {
                this.CheckBox.CheckOn();
            }
            else
            {
                this.CheckBox.CheckOff();
            }

            return this;
        }

        public ControlsPage VerifyCheckBoxTicked(bool expectedCheck)
        {
            this.CheckBox.IsChecked.ShouldBe(expectedCheck);
            return this;
        }

        public ControlsPage SelectComboBoxItem(string item)
        {
            this.ComboBox.SelectItem(item);
            return this;
        }

        public ControlsPage VerifyComboBoxItem(string expectedItem)
        {
            this.ComboBox.SelectedItem.ShouldBe(expectedItem);
            return this;
        }

        public ControlsPage SetDate(DateTime date)
        {
            this.DatePicker.SetDate(date);
            return this;
        }

        public ControlsPage VerifyDate(DateTime expectedDate)
        {
            Thread.Sleep(500); // Uno Wasm applications run too fast to ensure the selected date is set correctly before executing.
            this.DatePicker.SelectedDate.ShouldBe(expectedDate);
            return this;
        }

        public ControlsPage SetTime(TimeSpan time)
        {
            this.TimePicker.SetTime(time);
            return this;
        }

        public ControlsPage VerifyTime(TimeSpan expectedTime)
        {
            Thread.Sleep(500);
            this.TimePicker.SelectedTime.ShouldBe(expectedTime);
            return this;
        }

        public ControlsPage VerifyTextBoxText(string expectedText)
        {
            this.TextBox.Text.ShouldBe(expectedText);
            return this;
        }

        public ControlsPage Invoke(Action<ControlsPage> pageAction)
        {
            pageAction?.Invoke(this);
            return this;
        }

        private By DetermineTrait()
        {
            return this.App switch
            {
                WindowsDriver<WindowsElement> _ => ByExtensions.AutomationId("TitleTextBlock"),
                _ => By.XPath("//*")
            };
        }
    }
}