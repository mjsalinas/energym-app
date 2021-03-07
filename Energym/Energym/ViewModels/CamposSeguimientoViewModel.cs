﻿using Energym.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Energym.ViewModels
{
    public class CamposSeguimientotviewModel : INotifyPropertyChanged
    {
        public CamposSeguimientotviewModel()
        {
            RegistraCampoSeguimientoCommand = new Command(async () => await RegistrarCampoSeguimiento());
            CancelarCommand = new Command(CancelarRegistroCampoSeguimiento);
            CargarCampoSeguimiento().Wait();
        }

        public Command RegistraCampoSeguimientoCommand { get; }
        public Command CancelarCommand { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        List<CampoSeguimiento> camposSeguimientoExistentes;
       string campoSeguimientoDescripcion;
       string unidadMedida;

        public List<CampoSeguimiento> CamposSeguimientoExistentes
        {
            get { return camposSeguimientoExistentes; }
            set { camposSeguimientoExistentes = value; }
        }
        public string CampoSeguimientoDescripcion
        {
            get { return campoSeguimientoDescripcion; }
            set
            {
                campoSeguimientoDescripcion = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CamposSeguimiento"));
            }
        }
        public string UnidadMedida
        {
            get { return unidadMedida; }
            set
            {
                unidadMedida = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CamposSeguimiento"));
            }

        }


        async Task RegistrarCampoSeguimiento()
        {
            CampoSeguimiento NuevoCampoSeguimiento = new CampoSeguimiento()
            {
                CampoSeguimientoDescripcion =  campoSeguimientoDescripcion,
                UnidadMedida = unidadMedida,
            };

            var json = JsonConvert.SerializeObject(NuevoCampoSeguimiento);
            var registroNuevo = new StringContent(json, Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient();

            var response = await client.PostAsync("http://157.230.13.243/cliente", registroNuevo);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
              await  CargarCampoSeguimiento();
            }
        }
        void CancelarRegistroCampoSeguimiento()
        {
            CampoSeguimientoDescripcion = string.Empty;
        }

        async Task CargarCampoSeguimiento()
        {
            HttpClient client = new HttpClient();

            var response = await client.GetAsync("http://157.230.13.243/cliente");
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string objetoRespuesta = await response.Content.ReadAsStringAsync();
                CamposSeguimientoExistentes = JsonConvert.DeserializeObject<IEnumerable<CampoSeguimiento>>(objetoRespuesta) as List<CampoSeguimiento>;
            }
            //return response.
        }
    }
}

        
       
        




