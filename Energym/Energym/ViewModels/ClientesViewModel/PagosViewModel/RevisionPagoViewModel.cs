using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Energym.ViewModels.ClientesViewModel.PagosViewModel
{
    class RevisionPagoViewModel : INotifyPropertyChanged
    {
        public RevisionPagoViewModel()
        {
           
            EnviarComprobantedePagoCommand = new Command(async () => await EnviarComprobantedePago());
            CancelarCommand = new Command(CancelarRevisionRegistroPago);
        }

        public Command EnviarComprobantedePagoCommand { get; }
        public Command CancelarCommand { get; }

        public event PropertyChangedEventHandler PropertyChanged;
        List<string> registroPagosExistentes;
        int IdPago;
        int IdCliente;
        string EstadoDePago = string.Empty;
        DateTime fechaRealizacionPago = DateTime.Now.AddDays(5);
       
        public List<string> RegistroPagosExistentes
        {

            get { return registroPagosExistentes; }
            set { registroPagosExistentes = value; }
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
        async Task EnviarComprobantedePago()
        {
            await Task.Delay(400);
        }

         void CancelarRevisionRegistroPago(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
