using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model.DEL; //capa de entidades
using model.DAL; //capa de acceso a datos

namespace model.BEL
{
    public class AuxServicioBEL
    {
        private AuxServicioDAL objAuxServDAL;
        private AuxServicioDetDAL objAuxServDetDAL;

        public AuxServicioBEL()
        {
            objAuxServDAL = new AuxServicioDAL();
            objAuxServDetDAL = new AuxServicioDetDAL();
        }

        public void create(AuxiliarServicio objAuxServicio)
        {

        }

        public void update(AuxiliarServicio objAuxServicio)
        {

        }

        public void delete(AuxiliarServicio objAuxServicio)
        {

        }

        public List<AuxiliarServicio> findAll()
        {
            return objAuxServDAL.findAll();
        }

        public List<AuxiliarServicio> findAuxServNro(AuxiliarServicio objAuxServicio)
        {
            return objAuxServDAL.findAuxServNro(objAuxServicio);
        }

        public List<AuxiliarServicio> findAuxServDate(string objFechaInio, string objFechaFin)
        {
            return objAuxServDAL.findAuxServDate(objFechaInio, objFechaFin);
        }

        public List<AuxiliarServicioDet> findAuxServNroDet(AuxiliarServicioDet objAuxServicioDet)
        {
            
            return objAuxServDetDAL.findAuxServNroDet(objAuxServicioDet);
        }

        public List<AuxiliarServicioDet> findAllDet()
        {
            return objAuxServDetDAL.findAllServDet();
        }


    }
}
