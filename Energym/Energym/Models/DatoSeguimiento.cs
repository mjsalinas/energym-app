using System;
using System.Collections.Generic;
using System.Text;

namespace Energym.Models
{
   public class DatoSeguimiento
    {
        public int IdCampoSeguimiento { get; set; }
        public int IdCliente { get; set; }
        public string DatosSeguimiento { get; set; }
        public DateTime FechaRegistro { get; set; }

    }
}
