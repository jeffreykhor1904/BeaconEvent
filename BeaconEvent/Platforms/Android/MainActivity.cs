using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using BeaconEvent.Models;
using CommunityToolkit.Mvvm.Messaging;

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

    protected override void OnNewIntent(Intent intent)
    {
        base.OnNewIntent(intent);

        if (Intent.Extras != null)
        {
            foreach (var key in Intent.Extras.KeySet())
            {
                if (key == "NavigationID")
                {
                    string idValue = Intent.Extras.GetString(key);
                    if (Preferences.ContainsKey("NavigatioNID"))
                        Preferences.Remove("NavigationID");
                    Preferences.Set("NotificationID", idValue);
                    WeakReferenceMessenger.Default.Send(new PushNotificationReceived("test"));
                }
            }
        }
    }

    private void CreateNotificationChannel()
    {
        if (OperatingSystem.IsOSPlatformVersionAtLeast("android", 26))
        {
            var channel = new NotificationChannel(Channel_ID, "Test Notification Channel", NotificationImportance.Default);
            var NotificationManager = (NotificationManager)GetSystemService(Android.Content.Context.NotificationService);
            NotificationManager.CreateNotificationChannel(channel);
        }
    }
}