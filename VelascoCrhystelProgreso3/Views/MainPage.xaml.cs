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
            var httpClient = new HttpClient();
            var aeropuertoRepository = new CVAeropuertoRepository(httpClient);
            var conexionDBRepository = new CVConexionDBRepository(httpClient);
            _viewModel = new CVAeroPuertoViewModel(aeropuertoRepository, conexionDBRepository);
            BindingContext = _viewModel;
        }

    }

}
