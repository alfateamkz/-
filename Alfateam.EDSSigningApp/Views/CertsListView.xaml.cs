using Alfateam.EDSSigningApp.Abstractions;
using Alfateam.EDSSigningApp.Models;
using Alfateam.EDSSigningApp.Popups;
using RGPopup.Maui.Extensions;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Alfateam.EDSSigningApp.Views;

public partial class CertsListView : AbsContentView
{
	public CertsListView()
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




    private async void onAddCertBtnClicked(object sender, EventArgs e)
    {
		var fileTypes = new List<string>() { "p12", "pfx"};

		var res = await FilePicker.PickAsync(new PickOptions
		{
			FileTypes = new FilePickerFileType(new Dictionary<DevicePlatform, IEnumerable<string>>
			{
				{DevicePlatform.Android, fileTypes },
                {DevicePlatform.iOS, fileTypes },
                {DevicePlatform.WinUI, fileTypes },
                {DevicePlatform.MacCatalyst, fileTypes },
                {DevicePlatform.macOS, fileTypes },
            })
		});

		if(res != null)
		{
            Directory.CreateDirectory(App.EDSDirectory);

			var copyToFullPath = Path.Combine(App.EDSDirectory, $"{System.Guid.NewGuid().ToString()}{Path.GetExtension(res.FileName)}");
            File.Copy(res.FullPath, copyToFullPath);

			//TODO: отображение только что добавленной Ё÷ѕ в UI
		}
    }

    private void onItemTapped(object sender, EDS e)
    {
        if (DeviceInfo.Idiom != DeviceIdiom.Phone)
        {
            App.Current.MainPage.Navigation.PushPopupAsync(new AboutCertPopup(e));
        }
        else
        {
            App.NavigatedMainPage.SetView(new AboutCertViewForPhones(e));
        }
    }
}