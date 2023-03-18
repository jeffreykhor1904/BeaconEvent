using Android.App;
using Android.Content.PM;
using Android.OS;

namespace BeaconEvent;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]

public class MainActivity : MauiAppCompatActivity
{
    //internal static readonly StringNormalizationExtensions Channel_ID = "TestChannel";
    public const string Channel_ID = "TestChannel";
    public const int NotificationID = 101;

    protected override void OnCreate(Bundle savedInstanceState)
    {
        base.OnCreate(savedInstanceState);

        CreateNotificationChannel();
    }

    private void CreateNotificationChannel()
    {
        if(OperatingSystem.IsOSPlatformVersionAtLeast("android", 26))
        {
            var channel = new NotificationChannel(Channel_ID, "Test Notification Channel", NotificationImportance.Default);
            var NotificationManager = (NotificationManager)GetSystemService(Android.Content.Context.NotificationService);
            NotificationManager.CreateNotificationChannel(channel);
        }        
    }
}