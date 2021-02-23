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

        private void btnPag4_Clicked(object sender, EventArgs e)
        {

        }

        private async void btnCamposSeguimiento(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CamposSeguimientoPage1());
        }

        private void btnPag3_Clicked(object sender, EventArgs e)
        {

        }
    }

        
    }
