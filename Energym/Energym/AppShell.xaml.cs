using Energym.ViewModels;
using Energym.Views;
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
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            Routing.RegisterRoute(nameof(OportunidadesPage), typeof(OportunidadesPage));
            Routing.RegisterRoute(nameof(ClientesMenu), typeof(ClientesMenu));

            //pantallas especificas
            Routing.RegisterRoute(nameof(ClientesRegistro), typeof(ClientesRegistro));

        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
       

    }
}
