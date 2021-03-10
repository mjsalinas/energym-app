using Energym.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
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
            CargarCampoSeguimiento = CargarCampoSeguimientoTask();
        }

        public Command RegistraCampoSeguimientoCommand { get; }
        public Command CancelarCommand { get; }

        public event PropertyChangedEventHandler PropertyChanged;
        List<UnidadMedidaModelo> unidadesMedida { get; set; }

        List<CampoSeguimiento> camposSeguimientoExistentes;
       string campoSeguimientoDescripcion;
        UnidadMedidaModelo unidadMedida;

        public List<CampoSeguimiento> CamposSeguimientoExistentes
        {
            get { return camposSeguimientoExistentes; }
            set { camposSeguimientoExistentes = value; }
        }
        public string CampoSeguimientoDescripcion
        {
            get { return campoSeguimientoDescripcion; }
            set
            {
                campoSeguimientoDescripcion = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CamposSeguimiento"));
            }
        }
        public UnidadMedidaModelo UnidadMedidaSeleccionada
        {
            get { return unidadMedida; }
            set
            {
                unidadMedida = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("UnidadesMedidaSeleccionada"));
            }

        }
        public List<UnidadMedidaModelo> UnidadesMedida
        {
            get { return unidadesMedida; }
            set
            {
                unidadesMedida = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("UnidadesMedida"));
            }
        }

        
            async Task RegistrarCampoSeguimiento()
        {
            CampoSeguimiento NuevoCampoSeguimiento = new CampoSeguimiento()
            {
                CampoSeguimiento1 =  campoSeguimientoDescripcion,
                IdUnidadMedida = UnidadMedidaSeleccionada.IdUnidadMedida,
            };

            var json = JsonConvert.SerializeObject(NuevoCampoSeguimiento);
            var registroNuevo = new StringContent(json, Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient();

            var response = await client.PostAsync("http://157.230.13.243/cliente", registroNuevo);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
              await  CargarCampoSeguimientoTask();
            }
        }
        void CancelarRegistroCampoSeguimiento()
        {
            CampoSeguimientoDescripcion = string.Empty;
        }

        public Task CargarCampoSeguimiento { get; private set; }
        private async Task CargarCampoSeguimientoTask()
        {
            HttpClient client = new HttpClient();

            var response = await client.GetAsync("http://157.230.13.243/camposseguimiento");
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string objetoRespuesta = await response.Content.ReadAsStringAsync();
                CamposSeguimientoExistentes = JsonConvert.DeserializeObject<IEnumerable<CampoSeguimiento>>(objetoRespuesta) as List<CampoSeguimiento>;
            }
            //return response.
        }
        public async Task CargarUnidadesMedidaTask()
        {
            HttpClient client = new HttpClient();

            var response = await client.GetAsync("http://157.230.13.243/UnidadesMedida");
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string objetoRespuesta = await response.Content.ReadAsStringAsync();
                UnidadesMedida = JsonConvert.DeserializeObject<IEnumerable<UnidadMedidaModelo>>(objetoRespuesta) as List<UnidadMedidaModelo>;
            }
            //return response.
        }
    }
}

        
       
        




