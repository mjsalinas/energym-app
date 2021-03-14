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
    public class RegistrarDatoSeguimientoViewModel : INotifyPropertyChanged
    {
        public RegistrarDatoSeguimientoViewModel()
        {
            RegistrarOportunidadesCommand = new Command(async () => await RegistrarDatosSeguimeinto());
            CancelarCommand = new Command(CancelarRegistroDatosSeguimiento);
            CargarDatosSeguimiento = CargarDatosSeguimientoTask();
            CargarUnidadesMedida=  CargarUnidadesMedidaTask();
        }
        
        List<DatoSeguimiento> datosSeguimiento { get; set; }
        List<UnidadMedidaModelo> unidadesMedida { get; set; }
        public Command RegistrarOportunidadesCommand { get; }
        public Command CancelarCommand { get; }
        public event PropertyChangedEventHandler PropertyChanged;
       
        int idCampoSeguimiento;
        int idCliente;
        string datoSeguimientoDescripcion = string.Empty;
        DateTime fechaRegistro = DateTime.Now.AddDays(5);

        public List<DatoSeguimiento> DatosSeguimientos
        {
            get { return datosSeguimiento; }
            set
            {
                datosSeguimiento = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("DatosSeguimientos"));
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
        public int IdCampoSeguimiento
        {
            get { return idCampoSeguimiento; }
            set { idCampoSeguimiento = value; }
        }
        public int IdCliente
        {
            get { return idCliente; }
            set { idCliente = value; }
        }
        public string DatosSeguimiento
        {
            get { return datoSeguimientoDescripcion; }
            set
            {
                datoSeguimientoDescripcion = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("DatoSeguimientoDescripcion"));
            }
        }
        public DateTime FechaRegistro
        {
            get { return fechaRegistro; }
            set { fechaRegistro = value; }
        }
        async Task RegistrarDatosSeguimeinto()
        {
            DatoSeguimiento nuevoDatoSeguimiento = new DatoSeguimiento()
            {
               IdCampoSeguimiento=idCampoSeguimiento,
                IdCliente=idCliente,
                DatosSeguimiento= datoSeguimientoDescripcion,
                FechaRegistro=fechaRegistro
            };
            var json = JsonConvert.SerializeObject(nuevoDatoSeguimiento);
            var registroNuevo = new StringContent(json, Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient();

            var response = await client.PostAsync(Routes.DatosSeguimiento, registroNuevo);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                CargarDatosSeguimientoTask().Wait();
            }
        }
        private void CancelarRegistroDatosSeguimiento(object obj)
        {
            datoSeguimientoDescripcion = string.Empty;
        }
        public Task CargarUnidadesMedida { get; private set; }
        public Task CargarDatosSeguimiento { get; private set; }

        async Task CargarDatosSeguimientoTask()
        {
            HttpClient client = new HttpClient();

            var response = await client.GetAsync(Routes.DatosSeguimiento);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string objetoRespuesta = await response.Content.ReadAsStringAsync();
                DatosSeguimientos = JsonConvert.DeserializeObject<IEnumerable<DatoSeguimiento>>(objetoRespuesta) as List<DatoSeguimiento>;
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
                UnidadesMedida = JsonConvert.DeserializeObject<IEnumerable<UnidadMedidaModelo>>(objetoRespuesta) as List<UnidadMedidaModelo>;
            }
            //return response.
        }
    }
}
