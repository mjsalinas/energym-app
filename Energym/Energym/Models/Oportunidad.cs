using System;
using System.Collections.Generic;
using System.Text;

namespace Energym.Models
{
    public class Oportunidad
    {
        public int IdOportunidad { get; set; }
        public string OportunidadDescripcion { get; set; }
        public DateTime FechaTransaccion { get; set; }
        public string TipoOportunidad { get; set; }
        public string MensajeDeError { get; set; }

    }
}
