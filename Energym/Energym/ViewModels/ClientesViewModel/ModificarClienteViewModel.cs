using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        }
        public Command ModificarClienteCommand { get; }
        public Command CancelarCommand { get; }
        
        public event PropertyChangedEventHandler PropertyChanged;

        List<string> clientesExistentes;
        string nombre = "prueba";
        string numeroTelefono = string.Empty;
        string correo = string.Empty;
        DateTime fechaIngreso = DateTime.Now.AddDays(5);
        int tipoPlanId;

        public List<string> ClientesExistentes
        {

            get { return clientesExistentes; }
            set { clientesExistentes = value; }
        }
        
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
        public DateTime FechaIngreso
        {
            get { return fechaIngreso; }
            set { fechaIngreso = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FechaIngreso"));
            }
        }
        async Task ModificarCliente ()
        {

        }

        void CancelarModificarCliente()
        {

        }
    }
}
