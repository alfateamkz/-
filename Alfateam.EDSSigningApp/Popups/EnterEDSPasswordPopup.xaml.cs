using RGPopup.Maui.Extensions;
using RGPopup.Maui.Pages;

namespace Alfateam.EDSSigningApp.Popups;

public partial class EnterEDSPasswordPopup : PopupPage
{
	public EnterEDSPasswordPopup()
	{
		InitializeComponent();
	}


    private string password;
    public string Password
    {
        get => password;
        set { password = value; OnPropertyChanged(nameof(Password)); }
    }




    private void onCancelTapped(object sender, EventArgs e)
    {
        App.Current.MainPage.Navigation.RemovePopupPageAsync(this);
    }
    private void onConfirmTapped(object sender, EventArgs e)
    {
        App.Current.MainPage.Navigation.RemovePopupPageAsync(this);
        App.Current.MainPage.Navigation.PushPopupAsync(new SigningErrorPopup());
        App.Current.MainPage.Navigation.PushPopupAsync(new SigningSuccessPopup());
    }
}