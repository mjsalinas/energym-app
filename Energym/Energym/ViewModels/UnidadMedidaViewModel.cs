using Energym.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Energym.ViewModels
{
    public class UnidadMedidaViewModel : INotifyPropertyChanged
    {
        public UnidadMedidaViewModel()
        {
            RegistraUnidadMedidaCommand = new Command(async () => await RegistrarUnidadMedida());
            CancelarCommand = new Command(CancelarRegistroUnidadMedida);
        }
        public Command RegistraUnidadMedidaCommand { get; }
        public Command CancelarCommand { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        List<UnidadMedidaModelo> unidadesMedidaExistentes;
        string unidadMedida;

        public List<UnidadMedidaModelo> UnidadesMedidaExistentes
        {
            get { return unidadesMedidaExistentes; }
            set { unidadesMedidaExistentes = value; }
        }
        public string UnidadMedida
        {
            get { return unidadMedida; }
            set { unidadMedida = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("UnidadMedida"));
            }
        }
        async Task RegistrarUnidadMedida()
        {

        }
        void CancelarRegistroUnidadMedida()
        {
            UnidadMedida = string.Empty;
        }
    }
}
