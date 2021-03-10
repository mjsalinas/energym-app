using System;
using System.Collections.Generic;
using System.Text;

namespace Energym.Models
{
    public class UnidadMedidaModelo
    {
       
        public int IdUnidadMedida { get; set; }
        public string UnidadMedida { get; set; }
        public byte? RegistroOculto { get; set; }
        public string MensajeDeError { get; set; }


    }
}
