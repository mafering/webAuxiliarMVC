using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webAuxiliar.Utils
{
    public class GlobalVarAux
    {
        protected GlobalVarAux()
        { 
        }
        public static string fechaDesde { get; set; }
        public static string fechaHasta { get; set; }
        public static void InicializarVar()
        {
            fechaDesde = "";
            fechaHasta = "";
        }

    }
}