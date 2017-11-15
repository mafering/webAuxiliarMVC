using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace model.DAL
{
    interface Obligatorio<anyclass>
    {
        //Auxiliares de Obra
        void create(anyclass obj);
        void update(anyclass obj);
        void delete(anyclass obj);
        //anyclass find(anyclass obj);
        bool find(anyclass obj);
        List<anyclass> findAll();
        List<anyclass> findAuxObraNro(anyclass obj);
        List<anyclass> findAuxObraDate(string objFechaInicio, string objFechaFin);
    }
}
