using System;
using System.Collections.Generic;
using System.Text;

namespace Energym.Models
{
    public class UnidadMedida
    {
        public int IdUnidadMedida { get; set; }
        public string UnidadMedidaDescripcion { get; set; }
        public byte? RegistroOculto { get; set; }
        public string MensajeDeError { get; set; }


    }
}
