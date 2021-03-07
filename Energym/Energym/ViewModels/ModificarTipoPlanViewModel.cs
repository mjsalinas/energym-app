using Energym.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Energym.ViewModels
{
    public class ModificarTipoPlanViewModel : INotifyPropertyChanged
    {
        public ModificarTipoPlanViewModel()
        {
            ModificarTipoPlanCommand = new Command(async () => await ModificarTipoPlan());
            CancelarCommand = new Command(CancelarModificarTipoPlan);
        }

        public Command ModificarTipoPlanCommand { get; }
        public Command CancelarCommand { get; }
        public event PropertyChangedEventHandler PropertyChanged;

        List<string> tipoPlanesExistentes;
        string nombre = "Individual";
        int integrantes;
        decimal costoPlan;

        public List<string> TipoPlanesExistentes
        {

            get { return tipoPlanesExistentes; }
            set { tipoPlanesExistentes = value; }
        }
        public string Nombre
        {
            get { return nombre; }
            set
            {
                nombre = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Nombre"));
            }
        }

        public int Integrantes
        {
            get { return integrantes; }
            set
            {
                integrantes = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Integrantes"));
            }
        }
        public decimal CostoPlan
        {
            get { return costoPlan; }
            set
            {
                costoPlan = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CostoPlan"));

            }
        }

        async Task ModificarTipoPlan()
        {
}

        void CancelarModificarTipoPlan()
        {

        }

    }
}
 