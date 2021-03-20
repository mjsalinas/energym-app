using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Energym.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConfiguracionPage : ContentPage
    {
        public ConfiguracionPage()
        {
            InitializeComponent();

           
        }

        private async void btnPag4_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TipoPlanPage2());
        }

        private async void btnCamposSeguimiento(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CamposSeguimientoPage1());
        }
        private async void btnCamposSeguimientoModificar(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CamposSeguimientoPage2());
        }
        private async void btnPag3_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UnidadMedidaPage2());
        }
        private async void btnModificarUnidadMedida_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UnidadMedidaPage());
        }
        private async void btnPag5_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TipoPlanPage());

        }
    }

        
    }
