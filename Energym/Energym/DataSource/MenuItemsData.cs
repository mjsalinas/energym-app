using Energym.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Energym.DataSource
{
    public class MenuItemsData
    {
        public List<MenuItems> MenuItems = new List<MenuItems>()
        {
            new MenuItems()
            {
                Modulo = "Clientes",
                Pantallas = {"Registrar Nuevo Cliente","Modificar Cliente Existente","Registrar Pago"}
            },
            new MenuItems()
            {
                Modulo = "Configuraciones",
                Pantallas = {"Grupos","Tipo de Planes","Unidades Medida","Oportunidades"}
            }
        };
    }
}
