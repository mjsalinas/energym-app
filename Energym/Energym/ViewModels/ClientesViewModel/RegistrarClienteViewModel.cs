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

namespace Energym.ViewModels.ClientesViewModel
{
    public class RegistrarClienteViewModel : INotifyPropertyChanged
    {

        public RegistrarClienteViewModel()
        {
            RegistrarClienteCommand = new Command(async () => await RegistrarCliente());
            CancelarCommand = new Command(CancelarRegistroCliente);
            CargarTiposDePlan = CargarTiposDePlanTask();
            CargarClientes = CargarClientesTask();
        }

        #region Definiciones
        public Task CargarTiposDePlan { get; private set; }
        public Task CargarClientes { get; private set; }
        public Command RegistrarClienteCommand { get; } 
        public Command CancelarCommand { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        ObservableCollection<TipoPlan> planesExistentes;

        ObservableCollection<Cliente> clientesExistentes;

        TipoPlan planSeleccionado;
        #endregion

        #region Propiedades 

        string nombre;
        string numeroTelefono = string.Empty;
        DateTime fechaIngreso;
        string correo = string.Empty;
        int tipoPlan;
        sbyte activo = 1;
        string estadoCliente = string.Empty;
        int idGrupo;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; 
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Nombre"));
            }
        }
        public string NumeroTelefono
        {
            get { return numeroTelefono; }
            set { numeroTelefono = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("NumeroTelefono"));
            }
        }
        public string Correo
        {
            get { return correo; }
            set { correo = value; 
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Correo"));
            }
        }
        public int TipoPlan
        {
            get { return tipoPlan; }
            set { tipoPlan = value; 
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TipoPlan"));
            }
        }
        public sbyte Activo
        {
            get { return activo; }
            set { activo = value; 
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Activo"));
            }
        }
        public string EstadoCliente
        {
            get { return estadoCliente; }
            set { estadoCliente = value; 
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("EstadoCliente"));
            }
        }
        public int NumGrupo
        {
            get { return idGrupo; }
            set
            {
                idGrupo = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("NumGrupo"));
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
        public ObservableCollection<Cliente> ClientesExistentes
        {
            get { return clientesExistentes; }
            set
            {
                clientesExistentes = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ClientesExistentes"));
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
        #endregion

        #region Metodos 

        async Task RegistrarCliente ()
        {
            // asignacion de campos y data a mandar a servicios
            Cliente nuevoCliente = new Cliente()
            {
                Nombre = nombre,
                NumeroTelefono = numeroTelefono,
                FechaIngreso = fechaIngreso,
                Correo = correo,
            
                TipoPlan = PlanSeleccionado.IdPlan,
                IdGrupo = idGrupo
            };
             var json = JsonConvert.SerializeObject(nuevoCliente);
            var registroNuevo = new StringContent(json, Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient();
        
            var response = await client.PostAsync(Routes.Cliente, registroNuevo);   //llamada a servicios
        }
        void CancelarRegistroCliente()
        {
            Nombre = string.Empty;
            NumeroTelefono = string.Empty;
            Correo = string.Empty;

        }
        async Task CargarClientesTask()
        {
            HttpClient client = new HttpClient();

            var response = await client.GetAsync(Routes.Cliente);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string objetoRespuesta = await response.Content.ReadAsStringAsync();
                List<Cliente> clientes = JsonConvert.DeserializeObject<IEnumerable<Cliente>>(objetoRespuesta) as List<Cliente>;
                ClientesExistentes = new ObservableCollection<Cliente>(clientes);
            }
            //return response.
        }

        async Task CargarTiposDePlanTask()
        {
            HttpClient client = new HttpClient();

            var response = await client.GetAsync(Routes.TipoPlan);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string objetoRespuesta = await response.Content.ReadAsStringAsync();
                List<TipoPlan> planesAlmacenamiento = JsonConvert.DeserializeObject<IEnumerable<TipoPlan>>(objetoRespuesta) as List<TipoPlan>;
                PlanesExistentes = new ObservableCollection<TipoPlan>(planesAlmacenamiento);
            }
            //return response.
        }
        #endregion
    }
}
