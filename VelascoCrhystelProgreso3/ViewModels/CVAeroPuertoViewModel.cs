using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VelascoCrhystelProgreso3.Interfaces;
using VelascoCrhystelProgreso3.Repositories;

namespace VelascoCrhystelProgreso3.ViewModels
{
    public partial class CVAeroPuertoViewModel:ObservableObject
    {
        private readonly IAeropuerto _aeropuerto;
        private readonly CVConexionDBRepository _conexionDBRepository;
        [ObservableProperty] private string _buscarAeropuerto;
        [ObservableProperty] private string _mensaje;
        public CVAeroPuertoViewModel()
        {
            
        }
    }
}
