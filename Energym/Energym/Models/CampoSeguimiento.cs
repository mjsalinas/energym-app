using System;
using System.Collections.Generic;
using System.Text;

namespace Energym.Models
{
   public  class CampoSeguimiento
    {
        

        public int IdCampoSeguimiento { get; set; }
        public string CampoSeguimiento1 { get; set; }
        public int IdUnidadMedida { get; set; }
        public sbyte? RegistroOculto { get; set; }
        public string MensajeDeError { get; set; }
    }
}
