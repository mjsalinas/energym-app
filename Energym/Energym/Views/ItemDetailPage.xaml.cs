using Energym.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace Energym.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}