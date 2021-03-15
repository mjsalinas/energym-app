using Energym.ViewModels.ClientesViewModel.PagosViewModel;
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
    public partial class ClientesRegistrarPago : ContentPage
    {
        public ClientesRegistrarPago()
        {
            InitializeComponent();
            BindingContext = new RegistroPagosViewModel();
        }
    }
}