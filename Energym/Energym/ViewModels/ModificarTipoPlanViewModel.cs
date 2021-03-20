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
    public class ModificarTipoPlanViewModel : INotifyPropertyChanged
    {
        public ModificarTipoPlanViewModel()
        {
            ModificarTipoPlanCommand = new Command(async () => await ModificarTipoPlan());
            CancelarCommand = new Command(CancelarModificarTipoPlan);
            CargarTiposDePlan = CargarTiposDePlanTask();

        }
        public Task CargarTiposDePlan { get; private set; }

        ObservableCollection<TipoPlan> planesExistentes;
        TipoPlan planSeleccionado;

        public ObservableCollection<TipoPlan> TipoPlanes { get; set; }
        public Command ModificarTipoPlanCommand { get; }
        public Command CancelarCommand { get; }
        public event PropertyChangedEventHandler PropertyChanged;

        string nombre;
        int integrantes;
        decimal costoPlan;

        public ObservableCollection<TipoPlan> TipoPlanesExistentes
        {

            get { return planesExistentes; }
            set {
                planesExistentes = value; 
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TipoPlanesExistentes"));

            }
        }
      
        public string NombrePlan
        {
            get { return nombre; }
            set
            {
                nombre = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("NombrePlan"));
            }
        }

        public int NoIntegrantes
        {
            get { return integrantes; }
            set
            {
                integrantes = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("NoIntegrantes"));
            }
        }
        public decimal CostoPlan
        {
            get { return costoPlan; }
            set
            {
                costoPlan = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CostoPlan"));

            }
        }
        public TipoPlan PlanSeleccionado
        {
            get { return planSeleccionado; }
            set
            {
                planSeleccionado = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("PlanSeleccionado"));
            }
        }
        public ObservableCollection<TipoPlan> PlanesExistentes
        {
            get { return planesExistentes; }
            set
            {
                planesExistentes = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("PlanesExistentes"));
            }
        }
        async Task ModificarTipoPlan()
        {
            TipoPlan nuevoTipoPlan = new TipoPlan()
            {
                NombrePlan = NombrePlan,
                NoIntegrantes = NoIntegrantes,
                CostoPlan = CostoPlan
            };
            //llamada a servicios
            var json = JsonConvert.SerializeObject(nuevoTipoPlan);
            var registroNuevo = new StringContent(json, Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient();

            var response = await client.PutAsync(Routes.TipoPlan, registroNuevo);
        }

        void CancelarModificarTipoPlan()
        {

        }
        async Task CargarTiposDePlanTask()
        {
            HttpClient client = new HttpClient();

            var response = await client.GetAsync(Routes.TipoPlan);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string objetoRespuesta = await response.Content.ReadAsStringAsync();
                List<TipoPlan> planesAlmacenamiento = JsonConvert.DeserializeObject<IEnumerable<TipoPlan>>(objetoRespuesta) as List<TipoPlan>;
                TipoPlanesExistentes = new ObservableCollection<TipoPlan>(planesAlmacenamiento);
            }
            //return response.
        }
      
    }
}
 