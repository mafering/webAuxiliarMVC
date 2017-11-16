using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model.DAL
{
    interface ObligatorioDet<anyclass>
    {
        //Auxiliar de Obra (detalle)
        List<anyclass> findAuxObraNroDet(anyclass obj);
        List<anyclass> findAllDet();

    }
}
