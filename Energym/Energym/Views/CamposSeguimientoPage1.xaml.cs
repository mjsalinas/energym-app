using Energym.Models;
using Energym.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.ComponentModel;

namespace Energym.Views
{
    
    public partial class CamposSeguimientoPage1 : ContentPage
    {
        public CamposSeguimientoPage1()
        {
            InitializeComponent();
     
            this.BindingContext = new CamposSeguimientotviewModel();


        }

        private void btnAceptar_Clicked(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Clicked(object sender, EventArgs e)
        {
     
        }
     }

}



