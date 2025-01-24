using VelascoCrhystelProgreso3.Repositories;
using VelascoCrhystelProgreso3.ViewModels;

namespace VelascoCrhystelProgreso3
{
    public partial class MainPage : ContentPage
    {
        private readonly CVAeroPuertoViewModel _viewModel;

        public MainPage()
        {
            InitializeComponent();
            _viewModel = new CVAeroPuertoViewModel(new CVAeropuertoRepository(new HttpClient()));
        }

    }

}
