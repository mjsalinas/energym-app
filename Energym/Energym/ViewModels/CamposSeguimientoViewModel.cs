using Energym.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Energym.ViewModels
{
    class CamposSeguimientotviewModel : BaseViewModel
    {
        #region Inits
        public ObservableCollection<CampoSeguimiento> _Campo;
        public ObservableCollection<CampoSeguimiento> Campoos
        {
            get { return _Campo; }
            set
            {
                _Campo = value;
                OnPropertyChanged(nameof(_Campo));
            }
        }
        #endregion

        #region Ctor
        public CamposSeguimientotviewModel()
        {
            Campoos = new ObservableCollection<CampoSeguimiento>()
            {
                 new CampoSeguimiento(){ Id=1, campoSeguimiento= "PruebaL", UnidadMedida= "LB"},
                new CampoSeguimiento(){ Id=2, campoSeguimiento= "Otra", UnidadMedida= "KG"},
                new CampoSeguimiento(){ Id=3, campoSeguimiento= "Otra", UnidadMedida= "KG"},
                 new CampoSeguimiento(){ Id=4, campoSeguimiento= "Otra", UnidadMedida= "KG"},
                  new CampoSeguimiento(){ Id=5, campoSeguimiento= "Otra", UnidadMedida= "KG"},
                   new CampoSeguimiento(){ Id=6, campoSeguimiento= "Otra", UnidadMedida= "KG"},
                    new CampoSeguimiento(){ Id=7, campoSeguimiento= "Otra", UnidadMedida= "KG"},
                     new CampoSeguimiento(){ Id=8, campoSeguimiento= "Otra", UnidadMedida= "KG"},
                     new CampoSeguimiento(){ Id=9, campoSeguimiento= "Otra", UnidadMedida= "KG"},
                     new CampoSeguimiento(){ Id=10, campoSeguimiento= "Otra", UnidadMedida= "KG"},
                     new CampoSeguimiento(){ Id=11, campoSeguimiento= "Otra", UnidadMedida= "KG"},
                  new CampoSeguimiento(){ Id=12, campoSeguimiento= "Otra", UnidadMedida= "KG"},
            };
        }
        #endregion

        #region Sort
        bool isNameSorted = true;


        public ICommand NameSortCommand => new Command(() =>
        {
            List<CampoSeguimiento> CamposList = new List<CampoSeguimiento>();
            CamposList.AddRange(Campoos);
            Campoos = new ObservableCollection<CampoSeguimiento>();
            if (isNameSorted)
            {
                CamposList = CamposList.OrderBy(x => x.campoSeguimiento).ToList();
                foreach (var item in CamposList)
                {
                    Campoos.Add(item);
                }
            }
            else
            {
                CamposList = CamposList.OrderByDescending(x => x.campoSeguimiento).ToList();
                foreach (var item in CamposList)
                {
                    Campoos.Add(item);
                }
            }
            isNameSorted = !isNameSorted;
        });

        #endregion
    }
}

        
       
        




