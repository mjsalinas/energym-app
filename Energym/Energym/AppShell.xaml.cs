using Energym.ViewModels;
using Energym.Views;
//using Energym.Views.ClientesView.ClienteView;
//using Energym.Views.ClientesView.DatosSeguimientoView;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Energym
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            //modulos principales
            
            Routing.RegisterRoute(nameof(ClientesMenu), typeof(ClientesMenu));
            Routing.RegisterRoute(nameof(GruposMenu), typeof(GruposMenu));
            Routing.RegisterRoute(nameof(ConfiguracionPage), typeof(ConfiguracionPage));
            Routing.RegisterRoute(nameof(OportunidadesPage), typeof(OportunidadesPage));

            //pantallas Menu Clientes
            Routing.RegisterRoute(nameof(ClientesRegistro), typeof(ClientesRegistro));
            Routing.RegisterRoute(nameof(ClientesModificar), typeof(ClientesModificar));
            Routing.RegisterRoute(nameof(ClientesRegistrarPago), typeof(ClientesRegistrarPago));
            Routing.RegisterRoute(nameof(DatosSeguimientoIngresar), typeof(DatosSeguimientoIngresar));
            Routing.RegisterRoute(nameof(DatosSeguimientoModificar), typeof(DatosSeguimientoModificar));

            //pantallas Menu Grupos
            Routing.RegisterRoute(nameof(GruposRegistro), typeof(GruposRegistro));
            Routing.RegisterRoute(nameof(GruposModificar), typeof(GruposModificar));


            //pantallas Menu Configuraciones
            Routing.RegisterRoute(nameof(CamposSeguimientoPage1), typeof(CamposSeguimientoPage1));
            Routing.RegisterRoute(nameof(CamposSeguimientoPage2), typeof(CamposSeguimientoPage2));
            Routing.RegisterRoute(nameof(TipoPlanPage), typeof(TipoPlanPage));
            Routing.RegisterRoute(nameof(TipoPlanPage2), typeof(TipoPlanPage2));
            Routing.RegisterRoute(nameof(UnidadMedidaPage), typeof(UnidadMedidaPage));
            Routing.RegisterRoute(nameof(UnidadMedidaPage2), typeof(UnidadMedidaPage2));

        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
       

    }
}
