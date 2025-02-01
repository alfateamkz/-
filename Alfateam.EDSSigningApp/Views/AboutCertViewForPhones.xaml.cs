using Alfateam.EDSSigningApp.Abstractions;
using Alfateam.EDSSigningApp.Models;

namespace Alfateam.EDSSigningApp.Views;

public partial class AboutCertViewForPhones : AbsContentView
{
    public EDS EDS { get; set; }
    public AboutCertViewForPhones(EDS eds)
	{
		EDS = eds;
		InitializeComponent();
	}




    private void onGoBackTapped(object sender, TappedEventArgs e)
    {
        App.NavigatedMainPage.SetView(new CertsListView());
    }
}