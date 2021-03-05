using Energym.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
            CargarClientes();
        }
        public List<Cliente> Clientes { get; set; }
        public Command RegistrarClienteCommand { get; } 
        public Command CancelarCommand { get; }
        public event PropertyChangedEventHandler PropertyChanged;


        string nombre = "maria";
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
            set { nombre = value; }
        }
        public string NumeroTelefono
        {
            get { return numeroTelefono; }
            set { numeroTelefono = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("NumeroTelefono"));
            }
        }
        public DateTime FechaIngreso
        {
            get { return fechaIngreso; }
            set { fechaIngreso = value; }
        }
        public string Correo
        {
            get { return correo; }
            set { correo = value; }
        }
        public int TipoPlan
        {
            get { return tipoPlan; }
            set { tipoPlan = value; }
        }
        public sbyte Activo
        {
            get { return activo; }
            set { activo = value; }
        }
        public string EstadoCliente
        {
            get { return estadoCliente; }
            set { estadoCliente = value; }
        }
        async Task RegistrarCliente ()
        {
            // asignacion de campos y data a mandar a servicios
            Cliente nuevoCliente = new Cliente()
            {
                Nombre = nombre,
                NumeroTelefono = numeroTelefono,
                Correo = correo,
                Activo = activo,
                EstadoCliente = estadoCliente,
                TipoPlan = tipoPlan,
                IdGrupo = idGrupo
            };
            //llamada a servicios
            var json = JsonConvert.SerializeObject(nuevoCliente);
            var registroNuevo = new StringContent(json, Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient();
        
            var response = await client.PostAsync("http://157.230.13.243/cliente", registroNuevo);
        }
        void CancelarRegistroCliente()
        {
            Nombre = string.Empty;
            NumeroTelefono = string.Empty;
        }
        async Task CargarClientes()
        {
            HttpClient client = new HttpClient();

            var response = await client.GetAsync("http://157.230.13.243/cliente");
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string objetoRespuesta = await response.Content.ReadAsStringAsync();
                Clientes = JsonConvert.DeserializeObject<IEnumerable<Cliente>>(objetoRespuesta) as List<Cliente>;
            }
            //return response.
        }
    }
}
