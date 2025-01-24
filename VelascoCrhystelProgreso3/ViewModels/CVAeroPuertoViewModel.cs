using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VelascoCrhystelProgreso3.Interfaces;
using VelascoCrhystelProgreso3.Models;
using VelascoCrhystelProgreso3.Repositories;

namespace VelascoCrhystelProgreso3.ViewModels
{
    public partial class CVAeroPuertoViewModel:INotifyPropertyChanged
    {
        private readonly CVAeropuertoRepository _aeropuerto;
        private readonly CVConexionDBRepository _conexionDBRepository;
        private string _buscarAeropuerto;
        private string _mensaje;
        private ObservableCollection<CVAeropuertoBD> _aeropuertos;
        public ICommand BuscarAeropuertoCommand { get;}
        public ICommand LimpiarAeropuertoCommand { get; }
        public ICommand CargarInfoBDCommand { get; }

        public string BuscarAeropuerto
        {
            get => _buscarAeropuerto;
            set
            {
                if (_buscarAeropuerto != value)
                {
                    _buscarAeropuerto = value;
                    OnPropertyChanged();
                    ((Command)BuscarAeropuertoCommand).ChangeCanExecute();
                }
            }
        }
        
        public string Mensaje
        {
            get => _mensaje;
            set
            {
                if (_mensaje != value)
                {
                    _mensaje = value;
                    OnPropertyChanged();
                }
            }
        }
        public ObservableCollection<CVAeropuertoBD> Aeropuertos
        {
            get => _aeropuertos;
            set
            {
                if (_aeropuertos != value)
                {
                    _aeropuertos = value;
                    OnPropertyChanged();
                }
            }
        }
        public CVAeroPuertoViewModel(CVAeropuertoRepository cVAeropuertoRepository,CVConexionDBRepository conexionDBRepository)
        {
            _aeropuerto = cVAeropuertoRepository;
            _conexionDBRepository = conexionDBRepository;
            Aeropuertos = new ObservableCollection<CVAeropuertoBD>();
            BuscarAeropuertoCommand = new Command(async () => await BuscarAeropuertoAsync(),Buscar);
            LimpiarAeropuertoCommand = new Command(LimpiarAeropuerto);
            CargarInfoBDCommand = new Command(CargarInfoBD);
        }
        public CVAeroPuertoViewModel()
        {
            
        }
        private bool Buscar()
        {
            return !string.IsNullOrEmpty(BuscarAeropuerto);
        }
        private async Task BuscarAeropuertoAsync()
        {
            if (!Buscar())
            {
                Mensaje = "Aeropuerto no existe bro ingresa algo";
                return;
            }
            try
            {
                var aeropuertos = await _aeropuerto.GetAeropuerto(BuscarAeropuerto);

                if (aeropuertos != null && aeropuertos.Any())
                {
                    var aeropuerto = aeropuertos.First();

                    _conexionDBRepository.Add(aeropuerto);
                    await _conexionDBRepository.SaveChangesAsync();

                    Mensaje = $"Aeropuerto encontrado: {aeropuerto.name}, Código: {aeropuerto.code}";
                }
                else
                {
                    Mensaje = "No papi eso no esta en la info de la API pon otra cosa";
                }
            }
            catch (Exception ex)
            {
                Mensaje = $"Error al buscar aeropuerto: {ex.Message}";
            }
        }

        private void CargarInfoBD()
        {
            var aeropuertoLista = _conexionDBRepository.GetAeropuertoBD();
            Aeropuertos.Clear();
            foreach (var aeropuerto in aeropuertoLista)
            {
                Aeropuertos.Add(aeropuerto);
            }
        }
        private void LimpiarAeropuerto()
        {
            BuscarAeropuerto = string.Empty;
            Mensaje = string.Empty;
            ((Command)BuscarAeropuertoCommand).ChangeCanExecute();
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
