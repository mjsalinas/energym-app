using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        }
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
            //llamada a servicios
            await Task.Delay(400);
        }
        void CancelarRegistroCliente()
        {
            Nombre = string.Empty;
            NumeroTelefono = string.Empty;
        }
    }
}
