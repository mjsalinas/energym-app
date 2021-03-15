using Energym.ApiRoutes;
using Energym.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Energym.ViewModels
{
    public class ModificarUnidadMedidaViewModel : INotifyPropertyChanged
    {
        public ModificarUnidadMedidaViewModel()
        {
            ModificarUnidadMedidaCommand = new Command(async () => await ModificarUnidadMedida());
            CancelarCommand = new Command(CancelarModificarUnidadMedida);
            CargarUnidadesMedida = CargarUnidadesMedidaTask();
        }
        
        public Command ModificarUnidadMedidaCommand { get; }
        public Command CancelarCommand { get; }

        public event PropertyChangedEventHandler PropertyChanged;
        ObservableCollection<UnidadMedidaModelo> unidadesMedidaExistentes;
        UnidadMedidaModelo unidadMedidaSeleccionada;
        public Task CargarUnidadesMedida { get; private set; }

        public ObservableCollection<UnidadMedidaModelo> UnidadesMedidaExistentes
        {
            get { return unidadesMedidaExistentes; }
            set { unidadesMedidaExistentes = value; 
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("UnidadesMedidaExistentes"));
            }
        }
        public UnidadMedidaModelo UnidadMedidaSeleccionada
        {
            get { return unidadMedidaSeleccionada; }
            set
            {
                unidadMedidaSeleccionada = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("UnidadMedidaSeleccionada"));
            }
        }
        async Task ModificarUnidadMedida()
        {
        
        }

        void CancelarModificarUnidadMedida()
        {

        }

        async Task CargarUnidadesMedidaTask()
        {
            HttpClient client = new HttpClient();

            var response = await client.GetAsync(Routes.UnidadesMedida);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string objetoRespuesta = await response.Content.ReadAsStringAsync();
                List<UnidadMedidaModelo> unidadesMedidaAlmacenamiento = JsonConvert.DeserializeObject<IEnumerable<UnidadMedidaModelo>>(objetoRespuesta) as List<UnidadMedidaModelo>;
                UnidadesMedidaExistentes = new ObservableCollection<UnidadMedidaModelo>(unidadesMedidaAlmacenamiento);
            }
            //return response.
        }
    }
}
