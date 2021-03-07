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
    public class ModificarCampoSeguimientoViewModel : INotifyPropertyChanged
    {
        public ModificarCampoSeguimientoViewModel()
        {
            ModificaCampoSeguimientoCommand = new Command(async () => await ModificarCampoSeguimiento());
            CancelarCommand = new Command(CancelarModificarCampoSeguimiento);
        }
        public Command ModificaCampoSeguimientoCommand { get; }
        public Command CancelarCommand { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        List<CampoSeguimiento> camposSeguimientoExistentes;
        string campoSeguimientoDescripcion;
        string unidadMedida;
        string registroActivo;


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

        public string UnidadMedida
        {
            get { return unidadMedida; }
            set
            {
                unidadMedida = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CamposSeguimiento"));
            }
        }
       public string RegistroActivo
        {
            get { return registroActivo; }
            set
            {
                RegistroActivo = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CamposSeguimiento"));
            }
        }
        async Task ModificarCampoSeguimiento()
        {
            CampoSeguimiento NuevoCampoSeguimiento = new CampoSeguimiento()
            {
                CampoSeguimientoDescripcion = campoSeguimientoDescripcion,
                UnidadMedida = unidadMedida,
                RegistroActivo = registroActivo,
            };

            var json = JsonConvert.SerializeObject(NuevoCampoSeguimiento);
            var registroMoficicado = new StringContent(json, Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient();

            var response = await client.PutAsync("http://157.230.13.243/cliente", registroMoficicado);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                await CargarCampoSeguimiento();
            }

        }
        void CancelarModificarCampoSeguimiento()
        {
            CampoSeguimientoDescripcion = string.Empty;
        }
        async Task CargarCampoSeguimiento()
        {
            HttpClient client = new HttpClient();

            var response = await client.GetAsync("http://157.230.13.243/cliente");
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string objetoRespuesta = await response.Content.ReadAsStringAsync();
                CamposSeguimientoExistentes = JsonConvert.DeserializeObject<IEnumerable<CampoSeguimiento>>(objetoRespuesta) as List<CampoSeguimiento>;
            }
            //return response.
        }
    }
}
