using Alfateam.EDSSigningApp.Abstractions;
using Alfateam.EDSSigningApp.Models;
using System.Collections.ObjectModel;

namespace Alfateam.EDSSigningApp.Views;

public partial class SettingsView : AbsContentView
{
	public SettingsView()
	{
        Settings = App.Settings;
		InitializeComponent();
	}

    private ObservableCollection<string> languages = new ObservableCollection<string>
    {
        "Русский",
        "Қазақша",
        "English",
        "Монгол",
        "Кыргызча"
    };
    public ObservableCollection<string> Languages
    {
        get => languages;
        set { languages = value; OnPropertyChanged(nameof(Languages)); }
    }



    private AppSettings settings;
    public AppSettings Settings
    {
        get => settings;
        set { settings = value; OnPropertyChanged(nameof(Settings)); }
    }


    private void onGoBackTapped(object sender, TappedEventArgs e)
    {
        App.NavigatedMainPage.SetView(new CertsListView());
    }
}