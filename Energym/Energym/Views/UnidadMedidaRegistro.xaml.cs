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
    public partial class UnidadMedidaPage : ContentPage
    {
        public UnidadMedidaPage()
        {
            BindingContext = new ModificarUnidadMedidaViewModel();
            InitializeComponent();
        }

        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
        }
    }
}