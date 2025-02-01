using Alfateam.EDSSigningApp.Abstractions;
using Alfateam.EDSSigningApp.Models;
using Alfateam.EDSSigningApp.Popups;
using RGPopup.Maui.Extensions;
using System.Collections.ObjectModel;

namespace Alfateam.EDSSigningApp.Pages;

public partial class SelectCert : AbsContentPage
{
	public SelectCert()
	{
		InitializeComponent();
	}


    private ObservableCollection<EDS> _EDSlist = new ObservableCollection<EDS>
    {
        new EDS
        {
            CA_Info = "fdsfdssdf",
            Owner = " sdfsdfdsff",
            OwnerCountry = "sdfds",
            OwnerOrganization = "dsffdsdf",
            OwnerOrganizationNumber = "sdffdsdsffd",
            OwnerType = "fdsfsddffsd",
            Type = Enums.EDSType.Alfateam
        }
    };
    public ObservableCollection<EDS> EDSList
    {
        get => _EDSlist;
        set { _EDSlist = value; OnPropertyChanged(nameof(EDSList)); }
    }

    private void onItemTapped(object sender, EDS e)
    {
        App.Current.MainPage.Navigation.PushPopupAsync(new EnterEDSPasswordPopup());
    }
}