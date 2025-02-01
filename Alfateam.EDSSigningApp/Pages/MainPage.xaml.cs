using Alfateam.EDSSigningApp.Abstractions;
using Alfateam.EDSSigningApp.Views;

namespace Alfateam.EDSSigningApp.Pages;

public partial class MainPage : AbsContentPage
{
	public MainPage()
	{
		InitializeComponent();
		SetView(new CertsListView());

    }

	public void SetView(AbsContentView view)
	{
        contentLayout.Content = view;
    }
}