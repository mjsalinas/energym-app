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
    public class ModificarClienteViewModel : INotifyPropertyChanged
    {
        public ModificarClienteViewModel()
        {
            ModificarClienteCommand = new Command(async () => await ModificarCliente());
            CancelarCommand = new Command(CancelarModificarCliente);
            CargarTiposDePlan = CargarTiposDePlanTask();
            CargarClientes = CargarClientesTask();
        }
        public Task CargarTiposDePlan { get; private set; }
        public Task CargarClientes { get; private set; }
        public Command ModificarClienteCommand { get; }
        public Command CancelarCommand { get; }
        
        public event PropertyChangedEventHandler PropertyChanged;

        ObservableCollection<TipoPlan> planesExistentes;

        ObservableCollection<Cliente> clientesExistentes;

        TipoPlan planSeleccionado;

        Cliente clienteSeleccionado;

        string nombre = string.Empty;
        string numeroTelefono = string.Empty;
        DateTime fechaIngreso;
        string correo = string.Empty;
        int tipoPlanId;
        bool activo;
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
            set
            {
                numeroTelefono = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("NumeroTelefono"));

            }
        }
        public string Correo
        {
            get { return correo; }
            set
            {
                correo = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Correo"));
            }
        }
        public bool Activo
        {
            get { return activo; }
            set
            {
                activo = value;
                FechaIngreso = DateTime.Now;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Activo"));
            }
        }
        public DateTime FechaIngreso
        {
            get { return fechaIngreso; }
            set { fechaIngreso = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FechaIngreso"));
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
        public Cliente ClienteSeleccionado
        {
            get { return clienteSeleccionado; }
            set
            {
                clienteSeleccionado = value;
                FechaIngreso = clienteSeleccionado.FechaIngreso;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ClienteSeleccionado"));
            }
        }
        async Task ModificarCliente ()
        {
            // asignacion de campos y data a mandar a servicios
            Cliente clienteModificado = new Cliente()
            {
                Nombre = Nombre,
                NumeroTelefono = NumeroTelefono,
                FechaIngreso = FechaIngreso,
                Correo = Correo,
                Activo = (sbyte)(Activo == true ? 0 : 1),
                EstadoCliente = ClienteSeleccionado.EstadoCliente,
                TipoPlan = PlanSeleccionado.IdPlan,
                IdGrupo = ClienteSeleccionado.IdGrupo
            };
            var json = JsonConvert.SerializeObject(clienteModificado);
            var registroModificado = new StringContent(json, Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient();

            var response = await client.PutAsync(Routes.Cliente, registroModificado);   //llamada a servicios
        }

        void CancelarModificarCliente()
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
            ClienteSeleccionado = !(ClientesExistentes == null) && ClientesExistentes.Count > 0 ? ClientesExistentes[0] : ClienteSeleccionado;
            Activo = !(ClienteSeleccionado.Activo == null) ? ClienteSeleccionado.Activo == 0 ? true : false : false;

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


    }
}
