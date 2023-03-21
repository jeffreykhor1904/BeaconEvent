namespace BeaconEvent;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
        Routing.RegisterRoute(nameof(PreviewPage), typeof(PreviewPage));
        Routing.RegisterRoute(nameof(DevicePage), typeof(DevicePage));
    }
}