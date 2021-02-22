using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Energym.Views.ClientesView.ClienteView;
using Energym.Views.ClientesView.RegistroPagosView;
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