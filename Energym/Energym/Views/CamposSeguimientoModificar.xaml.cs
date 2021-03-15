using Energym.ViewModels;
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
    public partial class CamposSeguimientoPage2 : ContentPage
    {
        public CamposSeguimientoPage2()
        {
            InitializeComponent();
            BindingContext = new ModificarCampoSeguimientoViewModel();
        }

        private void btnAceptar_Clicked(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Clicked(object sender, EventArgs e)
        {

        }

        private void NameSort_Tapped(object sender, EventArgs e)
        {

        }
    }
}