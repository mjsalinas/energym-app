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
   public class ModificarDatoSeguimientoViewModel : INotifyPropertyChanged
    {
        public ModificarDatoSeguimientoViewModel()
        {
            ModificardatoSeguimientoCommand = new Command(async () => await ModificarDatoSeguimiento());
            CancelarCommand = new Command(CancelarModificarDatoSeguimiento);
        }

        public Command ModificardatoSeguimientoCommand { get; }
        public Command CancelarCommand { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        List<DatoSeguimiento> datosSeguimientoExistentes { get; set; }

        int idCampoSeguimiento;
        int idCliente;
        string datosSeguimiento = string.Empty;
        DateTime fechaRegistro = DateTime.Now.AddDays(5);

        public List<DatoSeguimiento> DatosSeguimientos
        {
            get { return datosSeguimientoExistentes; }
            set
            {
                datosSeguimientoExistentes = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("DatosSeguimientos"));
            }


        }
        public int IdCampoSeguimiento
        {
            get { return idCampoSeguimiento; }
            set { idCampoSeguimiento = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IdCampoSeguimiento"));
            }
        }
        public int IdCliente
        {
            get { return idCliente; }
            set { idCliente = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IdCliente"));
            }
        }
        public string DatosSeguimiento
        {
            get { return datosSeguimiento; }
            set
            {
                datosSeguimiento = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("DatosSeguimiento"));
            }
        }
        public DateTime FechaRegistro
        {
            get { return fechaRegistro; }
            set { fechaRegistro = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FechaRegistro"));
            }
        }

        async Task ModificarDatoSeguimiento()
        {
            DatoSeguimiento ModificarDatoSeguimiento = new DatoSeguimiento()
            {
                IdCliente=idCliente,
                DatosSeguimiento = datosSeguimiento,
                FechaRegistro = fechaRegistro

            };
            var json = JsonConvert.SerializeObject(ModificarDatoSeguimiento);
            var registroNuevo = new StringContent(json, Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient();

            var response = await client.PutAsync("http://157.230.13.243/DatosSeguimiento", registroNuevo);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                CargarDatosSeguimiento().Wait();
            }
        }

      void CancelarModificarDatoSeguimiento(object obj)
        {
            datosSeguimiento = string.Empty;
        }

        async Task CargarDatosSeguimiento()
        {
            HttpClient client = new HttpClient();

            var response = await client.GetAsync("http://157.230.13.243/DatosSeguimiento");
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string objetoRespuesta = await response.Content.ReadAsStringAsync();
                DatosSeguimientos = JsonConvert.DeserializeObject<IEnumerable<DatoSeguimiento>>(objetoRespuesta) as List<DatoSeguimiento>;
            }
            //return response.
        }



    }
}
