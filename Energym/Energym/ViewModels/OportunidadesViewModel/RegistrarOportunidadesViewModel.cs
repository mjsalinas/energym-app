using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Energym.ViewModels.OportunidadesViewModel
{
   public class RegistrarOportunidadesViewModel : INotifyPropertyChanged
    { 
        public RegistrarOportunidadesViewModel()
        {
            RegistrarOportunidadesCommand = new Command(async () => await RegistrarOportunidades());
            CancelarCommand = new Command(CancelarRegistroOportunidades);
        }
        public Command RegistrarOportunidadesCommand { get; }
        public Command CancelarCommand { get; }
        public event PropertyChangedEventHandler PropertyChanged;


        string oportunidades = string.Empty;

        public string Oportunidades 
        {
            get { return oportunidades; }
            set { oportunidades = value; }
        }
        async Task RegistrarOportunidades()
        {
            // asignacion de campos y data a mandar a servicios
            //llamada a servicios
            await Task.Delay(400);
        }
        void CancelarRegistroOportunidades()
        {
            oportunidades = string.Empty;   
        }
    }

}

