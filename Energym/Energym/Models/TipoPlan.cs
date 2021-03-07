using System;
using System.Collections.Generic;
using System.Text;

namespace Energym.Models
{
    public class TipoPlan
    {
        public int IdPlan { get; set; }
        public string NombrePlan { get; set; }
        public int NoIntegrantes { get; set; }
        public decimal CostoPlan { get; set; }
        public sbyte RegistroOculto { get; set; }
        public string MensajeDeError { get; set; }
    }
}
