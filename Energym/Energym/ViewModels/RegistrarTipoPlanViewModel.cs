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
    public class RegistrarTipoPlanViewModel : INotifyPropertyChanged
    {
        public RegistrarTipoPlanViewModel()
        {
            RegistrarTipoPlanCommand = new Command(async () => await RegistrarTipoPlan());
            CancelarCommand = new Command(CancelarRegistroTipoPlan);
            CargarTipoPlan();

        }

        public List<TipoPlan> TipoPlanes { get; set; }
        public Command RegistrarTipoPlanCommand { get; }
        public Command CancelarCommand { get; }
        public event PropertyChangedEventHandler PropertyChanged;

        string nombre = "Individual";
        int integrantes;
        decimal costoPlan;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public int Integrantes
        {
            get { return integrantes; }
            set { integrantes = value; }
        }
        public decimal CostoPlan
        {
            get { return costoPlan; }
            set { costoPlan = value; }
        }

        async Task RegistrarTipoPlan()
        {
            // asignacion de campos y data a mandar a servicios
            TipoPlan nuevoTipoPlan = new TipoPlan()
            {
                NombrePlan = nombre,
                NoIntegrantes = integrantes,
                CostoPlan = costoPlan
            };
            //llamada a servicios
            var json = JsonConvert.SerializeObject(nuevoTipoPlan);
            var registroNuevo = new StringContent(json, Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient();

            var response = await client.PostAsync(Routes.TipoPlan, registroNuevo);
        }

        void CancelarRegistroTipoPlan()
        {
            Nombre = string.Empty;
        }

        async Task CargarTipoPlan()
        {
            HttpClient client = new HttpClient();

            var response = await client.GetAsync(Routes.TipoPlan);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string objetoRespuesta = await response.Content.ReadAsStringAsync();
                TipoPlanes = JsonConvert.DeserializeObject<IEnumerable<TipoPlan>>(objetoRespuesta) as List<TipoPlan>;
            }
            //return response.
        }
    }
}
 