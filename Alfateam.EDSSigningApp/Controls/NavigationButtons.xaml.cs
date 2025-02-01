using Alfateam.EDSSigningApp.Abstractions;
using Alfateam.EDSSigningApp.Views;

namespace Alfateam.EDSSigningApp.Controls;

public partial class NavigationButtons : AbsContentView
{
	public NavigationButtons()
	{
		InitializeComponent();
	}




    private void onMainBtnTapped(object sender, TappedEventArgs e)
    {
        App.NavigatedMainPage.SetView(new CertsListView());
    }
    private void onAboutUsBtnTapped(object sender, TappedEventArgs e)
    {
        App.NavigatedMainPage.SetView(new AboutAppView());
    }
    private void onSettingsBtnTapped(object sender, TappedEventArgs e)
    {
        App.NavigatedMainPage.SetView(new SettingsView());
    }
}