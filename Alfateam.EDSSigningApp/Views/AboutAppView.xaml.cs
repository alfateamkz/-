using Alfateam.EDSSigningApp.Abstractions;

namespace Alfateam.EDSSigningApp.Views;

public partial class AboutAppView : AbsContentView
{
	public AboutAppView()
	{
		InitializeComponent();
	}

	public string VersionAndOS => $"{App.Version} ({DeviceInfo.Platform.ToString()})";
    public int CurrentYear => DateTime.Now.Year;

    private void onGoBackTapped(object sender, TappedEventArgs e)
    {
        App.NavigatedMainPage.SetView(new CertsListView());
    }




    private async void onOfertaTapped(object sender, TappedEventArgs e)
    {
        try
        {
            await Browser.Default.OpenAsync("https://vvxx.gayzona.top/cat-zhestkoe/", BrowserLaunchMode.SystemPreferred);
        }
        catch { }
    }
    private async void onPrivacyPolicyTapped(object sender, TappedEventArgs e)
    {
        try
        {
            await Browser.Default.OpenAsync("https://vvxx.gayzona.top/cat-zhestkoe/", BrowserLaunchMode.SystemPreferred);
        }
        catch { }
    }
    private async void onDocsTapped(object sender, TappedEventArgs e)
    {
        try
        {
            await Browser.Default.OpenAsync("https://vvxx.gayzona.top/cat-zhestkoe/", BrowserLaunchMode.SystemPreferred);
        }
        catch { }
    }
}