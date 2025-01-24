using VelascoCrhystelProgreso3.Repositories;
using VelascoCrhystelProgreso3.ViewModels;

namespace VelascoCrhystelProgreso3.Views;

public partial class MostrarBDView : ContentPage
{

	public MostrarBDView(CVAeroPuertoViewModel viewModel)
	{
		InitializeComponent();
		BindingContext=viewModel;
	}
}