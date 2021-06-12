namespace UnoSampleApp.Droid
{
    using Android.App;
    using Android.Content.PM;
    using Android.Views;

    [Activity(
        MainLauncher = true,
        ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize,
        WindowSoftInputMode = SoftInput.AdjustPan | SoftInput.StateHidden
    )]
	public class MainActivity : Windows.UI.Xaml.ApplicationActivity
	{
	}
}

