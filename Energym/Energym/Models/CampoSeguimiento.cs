using System;
using System.Collections.Generic;
using System.Text;

namespace Energym.Models
{
   public  class CampoSeguimiento
    {
        public int Id { get; set; }
        public string CampoSeguimientoDescripcion { get; set; }
        public string UnidadMedida { get; set; }
        public string RegistroActivo { get; set; }
    }
}
