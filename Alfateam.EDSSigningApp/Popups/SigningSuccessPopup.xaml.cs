using RGPopup.Maui.Extensions;
using RGPopup.Maui.Pages;

namespace Alfateam.EDSSigningApp.Popups;

public partial class SigningSuccessPopup : PopupPage
{
	public SigningSuccessPopup()
	{
		InitializeComponent();
	}

    private void onGoBackTapped(object sender, EventArgs e)
    {
        App.Current.MainPage.Navigation.RemovePopupPageAsync(this);
    }
}