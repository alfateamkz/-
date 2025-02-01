using RGPopup.Maui.Extensions;
using RGPopup.Maui.Pages;

namespace Alfateam.EDSSigningApp.Popups;

public partial class SigningErrorPopup : PopupPage
{
	public SigningErrorPopup()
	{
		InitializeComponent();
	}

    private void onGoBackTapped(object sender, EventArgs e)
    {
        App.Current.MainPage.Navigation.RemovePopupPageAsync(this);
    }
}