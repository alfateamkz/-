using Alfateam.EDSSigningApp.Abstractions;
using Alfateam.EDSSigningApp.Models;
using System.Collections.ObjectModel;

namespace Alfateam.EDSSigningApp.Controls;

public partial class CertListItem : AbsContentView
{ 
	public CertListItem()
	{
		InitializeComponent();
	}

    protected override void OnBindingContextChanged()
    {
        base.OnBindingContextChanged();

        if(BindingContext is EDS eds)
        {
            EDS = eds;
        }
    }


    private EDS _EDS;
    public EDS EDS
    {
        get => _EDS;
        set { _EDS = value; OnPropertyChanged(nameof(EDS)); }
    }

    public event EventHandler<EDS> Tapped;
    private void onTapped(object sender, TappedEventArgs e)
    {
        Tapped?.Invoke(this, EDS);
    }
}