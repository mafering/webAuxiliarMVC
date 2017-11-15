using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model.DAL
{
    interface ObligatorioServDet<anyclass>
    {
        //Auxiliar de Servicios (detalle)
        List<anyclass> findAuxServNroDet(anyclass obj);
        List<anyclass> findAllServDet();
    }
}
