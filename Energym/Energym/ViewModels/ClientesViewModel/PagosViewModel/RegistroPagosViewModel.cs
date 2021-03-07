using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Energym.ViewModels.ClientesViewModel.PagosViewModel
{
    public class RegistroPagosViewModel : INotifyPropertyChanged
    
    {
        public RegistroPagosViewModel()
        {
            RegistrarPagoCommand = new Command(async () => await RegistrarPago());
            EnviarComprobantedePagoCommand = new Command(async () => await EnviarComprobantedePago());
            CancelarCommand = new Command(CancelarRegistroPago);
        }

        public Command RegistrarPagoCommand { get; }
        public Command EnviarComprobantedePagoCommand { get; }
        public Command CancelarCommand { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        List<string> pagosExistentes;
        int IdPago;
        int IdCliente;
        string EstadoDePago = string.Empty;
        DateTime fechaRealizacionPago = DateTime.Now.AddDays(5);
        
        public List<string> PagosExistentes
        {

            get { return pagosExistentes; }
            set { pagosExistentes = value; }
        }

        public int IDPago
        {
            get { return IdPago; }
            set { IdPago = value; }
        }
        public int IDCliente
        {
            get { return IdCliente; }
            set { IdCliente = value; }
        }
        public string EstadodePago
        {
            get { return EstadoDePago; }
            set { EstadoDePago = value; }
        }
        public DateTime FechaDePago
        {
            get { return fechaRealizacionPago; }
            set { fechaRealizacionPago = value; }
        }

        async Task  RegistrarPago()
        {
            await Task.Delay(400);
        }

        async Task EnviarComprobantedePago()
        {
            await Task.Delay(400);
        }
        void CancelarRegistroPago(object obj)
        {
            EstadodePago = string.Empty;
            
        }

    }

}
