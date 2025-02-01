using Alfateam.EDSSigningApp.Models;
using RGPopup.Maui.Extensions;
using RGPopup.Maui.Pages;

namespace Alfateam.EDSSigningApp.Popups;

public partial class AboutCertPopup : PopupPage
{
    public AboutCertPopup(EDS eds)
    {
        EDS = eds;
        InitializeComponent();
    }


    public static readonly BindableProperty EDSProperty = BindableProperty.Create(nameof(EDS), typeof(EDS), typeof(AboutCertPopup));
    public EDS EDS
    {
        get { return (EDS)GetValue(EDSProperty); }
        set { SetValue(EDSProperty, value); }
    }

    private void onGoBackTapped(object sender, EventArgs e)
    {
        App.Current.MainPage.Navigation.RemovePopupPageAsync(this);
    }
}