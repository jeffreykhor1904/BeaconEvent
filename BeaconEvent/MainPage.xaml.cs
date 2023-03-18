using System.Text;
using BeaconEvent.ViewModels;
using Newtonsoft.Json;

namespace BeaconEvent;

public partial class MainPage : ContentPage
{
    //int count = 0;
    private string _deviceToken;

	public MainPage(MainPageViewModel viewModel)
	{
		InitializeComponent();
        BeaconEventWebView.Source = "https://learn.microsoft.com/dotnet/maui";
		BindingContext = viewModel;
        if (Preferences.ContainsKey("DeviceToken")) { _deviceToken = Preferences.Get("DeviceToken", ""); }
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
    }

    protected override void OnNavigatedFrom(NavigatedFromEventArgs args)
    {
        base.OnNavigatedFrom(args);
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
    }

    private async void OnCounterClicked(object sender, EventArgs e)
    {
        //count++;
        //if (count == 1)
        //    CounterBtn.Text = $"Clicked {count} time";
        //else
        //    CounterBtn.Text = $"Clicked {count} times";
        //SemanticScreenReader.Announce(CounterBtn.Text);
        var pushNotificationRequest = new PushNotificationRequest
        {
            NotificationCenter = new NotificationMessageBody
            {
                title = "Notification Title",
                body = "Notification Body"
            },
            registration_ids = new List<string> { _deviceToken }
        };

        string url = "https://fcm.googleapis.com/fcm/send";

        using(var client = new HttpClient())
        {
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("key", "=" + "BLsn5QBaW41a6GaYsPJ7cUaW870R-kKdzv1dNC9lreb13eFGDTQERlLfTMaU-tPM1dCoTv0hT_Fuwt4iBUQ6GHw");
            string serializeRequest = JsonConvert.SerializeObject(pushNotificationRequest);
            var response = await client.PostAsync(url, new StringContent(serializeRequest, Encoding.UTF8, "application/json"));
            if(Equals(response.StatusCode, System.Net.HttpStatusCode.OK))
            {
                await App.Current.MainPage.DisplayAlert("Notification Sent", "Notification Sent", "OK");
            }
        }
    }
}