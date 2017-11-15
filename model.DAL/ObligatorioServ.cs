using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model.DAL
{
    interface ObligatorioServ<anyclass>
    {
        //Auxiliares de Servicios
        void create(anyclass obj);
        void update(anyclass obj);
        void delete(anyclass obj);
        //anyclass find(anyclass obj);
        bool find(anyclass obj);
        List<anyclass> findAll();
        List<anyclass> findAuxServNro(anyclass obj);
        List<anyclass> findAuxServDate(string objFechaInicio, string objFechaFin);
    }
}
