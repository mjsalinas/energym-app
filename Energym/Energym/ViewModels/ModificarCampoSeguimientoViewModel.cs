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
    public class ModificarCampoSeguimientoViewModel : INotifyPropertyChanged
    {
        public ModificarCampoSeguimientoViewModel()
        {
            ModificaCampoSeguimientoCommand = new Command(async () => await ModificarCampoSeguimiento());
            CancelarCommand = new Command(CancelarModificarCampoSeguimiento);
            CargarUnidadesMedida = CargarUnidadesMedidaTask();
        }
        public Command ModificaCampoSeguimientoCommand { get; }
        public Command CancelarCommand { get; }

        public event PropertyChangedEventHandler PropertyChanged;
        public Task CargarUnidadesMedida { get; private set; }
        ObservableCollection<UnidadMedidaModelo> unidadesMedidaExistentes;
        ObservableCollection<CampoSeguimiento> camposSeguimientoExistentes;
        bool estaHabilitado;
        CampoSeguimiento campoSeguimientoSeleccionado;

        public ObservableCollection<UnidadMedidaModelo> UnidadesMedidaExistentes
        {
            get { return unidadesMedidaExistentes; }
            set
            {
                unidadesMedidaExistentes = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("UnidadesMedidaExistentes"));
            }
        }
        public ObservableCollection<CampoSeguimiento> CamposSeguimientoExistentes
        {
            get { return camposSeguimientoExistentes; }
            set { camposSeguimientoExistentes = value; }
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
        public bool EstaHabilitado
        {
            get { return estaHabilitado; }
            set
            {
                estaHabilitado = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("EstaHabilitado"));
            }
        }
        async Task ModificarCampoSeguimiento()
        {
            CampoSeguimiento NuevoCampoSeguimiento = new CampoSeguimiento()
            {
                IdCampoSeguimiento = CampoSeguimientoSeleccionado.IdCampoSeguimiento,
                CampoSeguimiento1 = CampoSeguimientoSeleccionado.CampoSeguimiento1,
                IdUnidadMedida = CampoSeguimientoSeleccionado.IdUnidadMedida,
                RegistroOculto = (sbyte?)(EstaHabilitado == true ? 0 : 1)
            };
            var json = JsonConvert.SerializeObject(NuevoCampoSeguimiento);
            var registroMoficicado = new StringContent(json, Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient();

            var response = await client.PutAsync(Routes.Cliente, registroMoficicado);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                await CargarCampoSeguimiento();
            }

        }
        void CancelarModificarCampoSeguimiento()
        {
        }
        async Task CargarCampoSeguimiento()
        {
            HttpClient client = new HttpClient();

            var response = await client.GetAsync(Routes.Cliente);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string objetoRespuesta = await response.Content.ReadAsStringAsync();
                List<CampoSeguimiento>campoSeguimientoAlmacenamiento = JsonConvert.DeserializeObject<IEnumerable<CampoSeguimiento>>(objetoRespuesta) as List<CampoSeguimiento>;
                CamposSeguimientoExistentes = new ObservableCollection<CampoSeguimiento>(campoSeguimientoAlmacenamiento);
            }
            //return response.
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
