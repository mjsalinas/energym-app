using Energym.ApiRoutes;
using Energym.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            CargarUnidadesMedida = CargarUnidadesMedidaTask();
        }
        public Command RegistraUnidadMedidaCommand { get; }
        public Command CancelarCommand { get; }
        public Task CargarUnidadesMedida { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;

        ObservableCollection<UnidadMedidaModelo> unidadesMedidaExistentes;
        string unidadMedida;

        public ObservableCollection<UnidadMedidaModelo> UnidadesMedidaExistentes
        {
            get { return unidadesMedidaExistentes; }
            set { unidadesMedidaExistentes = value; 
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("UnidadesMedidaExistentes"));
            }
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
            CargarUnidadesMedidaTask().Wait();
        }
        void CancelarRegistroUnidadMedida()
        {
            UnidadMedida = string.Empty;
        }
        async Task CargarUnidadesMedidaTask()
        {
            HttpClient client = new HttpClient();

            var response = await client.GetAsync(Routes.UnidadesMedida);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string objetoRespuesta = await response.Content.ReadAsStringAsync();
                List<UnidadMedidaModelo> unidadesMedidaAlmacenamiento = JsonConvert.DeserializeObject<IEnumerable<UnidadMedidaModelo>>(objetoRespuesta) as List<UnidadMedidaModelo>;
                UnidadesMedidaExistentes = new ObservableCollection<UnidadMedidaModelo>(unidadesMedidaAlmacenamiento);
            }
            //return response.
        }
    }
}
