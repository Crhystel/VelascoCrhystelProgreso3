using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VelascoCrhystelProgreso3.Interfaces;
using VelascoCrhystelProgreso3.Repositories;

namespace VelascoCrhystelProgreso3.ViewModels
{
    public partial class CVAeroPuertoViewModel:INotifyPropertyChanged
    {
        private readonly CVAeropuertoRepository _aeropuerto;
        private readonly CVConexionDBRepository _conexionDBRepository;
        private string _buscarAeropuerto;
        private string _mensaje;
        public ICommand BuscarAeropuertoCommand { get;}
        public ICommand LimpiarAeropuertoCommand { get; }

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
        public CVAeroPuertoViewModel(CVAeropuertoRepository cVAeropuertoRepository)
        {
            _aeropuerto = cVAeropuertoRepository;
            BuscarAeropuertoCommand = new Command(async () => await BuscarAeropuertoAsync(),Buscar);
            LimpiarAeropuertoCommand = new Command(LimpiarAeropuerto);
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
            var aeropuerto = await _aeropuerto.GetAeropuerto(BuscarAeropuerto);
            if (aeropuerto != null)
            {
                aeropuerto.UserName = "VelascoCrhystel";
                _conexionDBRepository.Add(aeropuerto);
                await _conexionDBRepository.SaveChangesAsync();
                Mensaje = "Aeropuerto encontrado";
            }
            else
            {
                Mensaje = "Aeropuerto no existe";
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
