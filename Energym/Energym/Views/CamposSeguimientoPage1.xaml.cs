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
        bool isNameSorted = true;
        List<CampoSeguimiento> Campoos = new List<CampoSeguimiento>();
        public CamposSeguimientoPage1()
        {
            InitializeComponent();
            this.BindingContext = new CamposSeguimientotviewModel();


        }

        public void NameSort_Tapped(object sender, EventArgs e)
        {
            List<CampoSeguimiento> CampossList = new List<CampoSeguimiento>();
            Campoos = new List<CampoSeguimiento>();
            
            if (CamposList.ItemsSource is ObservableCollection<CampoSeguimiento> empCollection)
                CampossList.AddRange(empCollection);
            else if (CamposList.ItemsSource is List<CampoSeguimiento> empList)
                CampossList.AddRange(empList);

            if (isNameSorted)
            {
                CampossList = CampossList.OrderBy(x => x.campoSeguimiento).ToList();
                foreach (var item in CampossList)
                {
                    Campoos.Add(item);
                }
            }
            else
            {
                CampossList = CampossList.OrderByDescending(x => x.campoSeguimiento).ToList();
                foreach (var item in CampossList)
                {
                    Campoos.Add(item);
                }
            }
            CamposList.ItemsSource = Campoos;
            isNameSorted = !isNameSorted;
        }
   


        private void btnAceptar_Clicked(object sender, EventArgs e)
        {

        }

        private async void btnCancelar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ConfiguracionPage());
        }
     }

}



