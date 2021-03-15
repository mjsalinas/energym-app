using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Energym.Views.ClientesView.ClienteView;
//using Energym.Views.ClientesView.RegistroPagosView;
//using Energym.Views.ClientesView.DatosSeguimientoView;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Energym.Views
{
    public partial class GruposMenu : ContentPage
    {
        public GruposMenu()
        {
            InitializeComponent();
            btnToGruposRegistrar.Clicked += (sender, e) =>
            {
                Navigation.PushAsync(new GruposRegistro());
            };
            
            btnToGruposModificar.Clicked += (sender, e) =>
            {
                Navigation.PushAsync(new GruposModificar());
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