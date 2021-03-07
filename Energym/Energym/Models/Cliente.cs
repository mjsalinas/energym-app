using System;
using System.Collections.Generic;
using System.Text;

namespace Energym.Models
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public string NumeroTelefono { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string Correo { get; set; }
        public int TipoPlan { get; set; }
        public int IdGrupo { get; set; }
        public sbyte Activo { get; set; }
        public string EstadoCliente { get; set; }
        public string MensajeDeError { get; set; }
    }
}
