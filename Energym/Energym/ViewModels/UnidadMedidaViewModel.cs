using Energym.ApiRoutes;
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
            UnidadMedidaModelo nuevaUnidadMedida = new UnidadMedidaModelo()
            {
               UnidadMedida = UnidadMedida,
               RegistroOculto = 0
            };
            var json = JsonConvert.SerializeObject(nuevaUnidadMedida);
            var registroNuevo = new StringContent(json, Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient();

            var response = await client.PostAsync(Routes.UnidadesMedida, registroNuevo);   //llamada a servicios

        }
        void CancelarRegistroUnidadMedida()
        {
            UnidadMedida = string.Empty;
        }
    }
}
