using System;
using System.Collections.Generic;
using System.Text;

namespace Energym.ApiRoutes
{
    static class Routes
    {
        public static string ApiUrl = "http://157.230.13.243/";
        public static string UnidadesMedida
        {
            get { return ApiUrl + "UnidadesMedida"; }
        }
        public static string CamposSeguimiento
        {
            get { return ApiUrl + "camposseguimiento"; }
        }
        public static string Cliente
        {
            get { return ApiUrl + "cliente"; }
        }
        public static string DatosSeguimiento
        {
            get { return ApiUrl + "DatosSeguimiento"; }
        }
        public static string Oportunidades
        {
            get { return ApiUrl + "Oportunidades"; }
        }
        public static string TipoPlan
        {
            get { return ApiUrl + "TipoPlan"; }
        }
    }
}
