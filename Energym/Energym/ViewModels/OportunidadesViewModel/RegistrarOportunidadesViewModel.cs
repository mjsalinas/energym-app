using Energym.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
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
            CargarOportunidades().Wait();
        }
         List<Oportunidad> oportunidades { get; set; }
        public Command RegistrarOportunidadesCommand { get; }
        public Command CancelarCommand { get; }
        public event PropertyChangedEventHandler PropertyChanged;


        string oportunidadDescripcion = string.Empty;
        DateTime fechaTransaccion = DateTime.Now.AddDays(5);
        string tipoOportunidad = string.Empty;

        public List<Oportunidad> Oportunidades
        {
            get { return oportunidades; }
            set { oportunidades = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Oportunidades"));
            }
        }
        public string OportunidadDescripcion
        {
            get { return oportunidadDescripcion; }
            set { oportunidadDescripcion = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("OportunidadDescripcion"));
            }
        }

        public DateTime FechaTransaccion
        {
            get { return fechaTransaccion; }
            set { fechaTransaccion = value; }
        }

        public string TipoOportunidad
        {
            get { return tipoOportunidad; }
            set { tipoOportunidad = value; }
        }

        async Task RegistrarOportunidades()
        {
            Oportunidad nuevaOportunidad = new Oportunidad()
            {
                OportunidadDescripcion = oportunidadDescripcion,
                FechaTransaccion=fechaTransaccion,
                TipoOportunidad=tipoOportunidad
          
            };
            var json = JsonConvert.SerializeObject(nuevaOportunidad);
            var registroNuevo = new StringContent(json, Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient();

            var response = await client.PostAsync("http://157.230.13.243/Oportunidades", registroNuevo);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                CargarOportunidades().Wait();
            }
        }
        void CancelarRegistroOportunidades()
        {
            oportunidadDescripcion = string.Empty;   
        }

        async Task CargarOportunidades()
        {
            HttpClient client = new HttpClient();

            var response = await client.GetAsync("http://157.230.13.243/Oportunidades");
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string objetoRespuesta = await response.Content.ReadAsStringAsync();
                Oportunidades = JsonConvert.DeserializeObject<IEnumerable<Oportunidad>>(objetoRespuesta) as List<Oportunidad>;
            }
            //return response.
        }
    }

}

