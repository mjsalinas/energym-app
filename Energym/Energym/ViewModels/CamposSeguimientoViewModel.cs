using Energym.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Energym.ViewModels
{
    public class CamposSeguimientotviewModel : INotifyPropertyChanged
    {

        public CamposSeguimientotviewModel()
        {
            RegistraCampoSeguimientoCommand = new Command(async () => await RegistrarCampoSeguimiento());
            CancelarCommand = new Command(CancelarRegistroCampoSeguimiento);
        }

        public Command RegistraCampoSeguimientoCommand { get; }
        public Command CancelarCommand { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        List<string> camposSeguimientoExistentes;
        string campoSeguimiento = "peso";
        public List<string> CamposSeguimientoExistentes
        {
            get { return camposSeguimientoExistentes; }
            set { camposSeguimientoExistentes = value; }
        }
        public string CamposSeguimiento
        {
            get { return campoSeguimiento; }
            set
            {
                campoSeguimiento = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CamposSeguimiento"));
            }
        }
        async Task RegistrarCampoSeguimiento()
        {
            await Task.Delay(400);
        }
        void CancelarRegistroCampoSeguimiento()
        {
            CamposSeguimiento = string.Empty;
        }
    }
}

        
       
        




