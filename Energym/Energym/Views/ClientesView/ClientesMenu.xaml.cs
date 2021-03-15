using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Energym.Views;
//using Energym.Views.ClientesView.ClienteView;
//using Energym.Views.ClientesView.RegistroPagosView;
//using Energym.Views.ClientesView.DatosSeguimientoView;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Energym.Views
{
    public partial class ClientesMenu : ContentPage
    {
        public ClientesMenu()
        {
            InitializeComponent();
            btnToClientesRegistrar.Clicked += (sender, e) =>
            {
                Navigation.PushAsync(new ClientesRegistro());
            };
            btnToClientesModificar.Clicked += (sender, e) =>
            {
                Navigation.PushAsync(new ClientesModificar());
            };

            btnToClientesRegistrarPago.Clicked += (sender, e) =>
            {
                Navigation.PushAsync(new ClientesRegistrarPago());
            };
            btnToDatosSeguimientoRegistro.Clicked += (sender, e) =>
            {
                Navigation.PushAsync(new DatosSeguimientoIngresar());
            };
            btnToDatosSeguimientoModificar.Clicked += (sender, e) =>
            {
                Navigation.PushAsync(new DatosSeguimientoModificar());
            };
        }
        //public ToClientesModificar()
        //{
        //    InitializeComponent();
        //    btnToClientesRegistrar.Clicked += (sender, e) =>
        //    {
        //        Navigation.PushAsync(new ClientesRegistro());
        //    };
    }
}