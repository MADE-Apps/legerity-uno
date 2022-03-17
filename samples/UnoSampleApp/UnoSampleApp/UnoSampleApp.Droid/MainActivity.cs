namespace UnoSampleApp.Droid
{
    using Android.App;
    using Android.Content.PM;
    using Android.Views;

    [Activity(
#if DEBUG
        // Disabled because of https://github.com/xamarin/xamarin-android/issues/6463
	    Exported = true,
#endif
        MainLauncher = true,
        ConfigurationChanges = global::Uno.UI.ActivityHelper.AllConfigChanges,
        WindowSoftInputMode = SoftInput.AdjustPan | SoftInput.StateHidden
    )]
	public class MainActivity : Windows.UI.Xaml.ApplicationActivity
	{
	}
}

