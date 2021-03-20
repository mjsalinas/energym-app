using Energym.ApiRoutes;
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
            CargarUnidadesMedida = CargarUnidadesMedidaTask();
        }

        public Task CargarUnidadesMedida { get; private set; }
        public Task CargarCampoSeguimiento { get; private set; }
        public Command RegistraCampoSeguimientoCommand { get; }
        public Command CancelarCommand { get; }

        public event PropertyChangedEventHandler PropertyChanged;
        ObservableCollection<UnidadMedidaModelo> unidadesMedidaExistentes { get; set; }
        ObservableCollection<CampoSeguimiento> camposSeguimientoExistentes;
        UnidadMedidaModelo unidadMedida;
        CampoSeguimiento campoSeguimientoSeleccionado;
        string camposSeguimiento;
        public ObservableCollection<CampoSeguimiento> CamposSeguimientoExistentes
        {
            get { return camposSeguimientoExistentes; }
            set { camposSeguimientoExistentes = value; }
        }
        public ObservableCollection<UnidadMedidaModelo> UnidadesMedidaExistentes
        {
            get { return unidadesMedidaExistentes; }
            set
            {
                unidadesMedidaExistentes = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("UnidadesMedidaExistentes"));
            }
        }

        public CampoSeguimiento CampoSeguimientoSeleccionado
        {
            get { return campoSeguimientoSeleccionado; }
            set
            {
                campoSeguimientoSeleccionado = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CampoSeguimientoSeleccionado"));
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
        public string CamposSeguimiento
        {
            get { return camposSeguimiento; }
            set
            {
                camposSeguimiento = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CamposSeguimiento"));
            }
        }
        async Task RegistrarCampoSeguimiento()
        {
            CampoSeguimiento NuevoCampoSeguimiento = new CampoSeguimiento()
            {
                CampoSeguimiento1 = camposSeguimiento, 
                IdUnidadMedida = UnidadMedidaSeleccionada.IdUnidadMedida,
                RegistroOculto = 0,
            };

            var json = JsonConvert.SerializeObject(NuevoCampoSeguimiento);
            var registroNuevo = new StringContent(json, Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient();

            var response = await client.PostAsync(Routes.Cliente, registroNuevo);
        }
        void CancelarRegistroCampoSeguimiento()
        {
        }

        private async Task CargarCampoSeguimientoTask()
        {
            HttpClient client = new HttpClient();

            var response = await client.GetAsync(Routes.CamposSeguimiento);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string objetoRespuesta = await response.Content.ReadAsStringAsync();
                List<CampoSeguimiento> campoSeguimientoAlmacenamiento = JsonConvert.DeserializeObject<IEnumerable<CampoSeguimiento>>(objetoRespuesta) as List<CampoSeguimiento>;
                CamposSeguimientoExistentes = new ObservableCollection<CampoSeguimiento>(campoSeguimientoAlmacenamiento);
            }
            //return response.
        }
        public async Task CargarUnidadesMedidaTask()
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








