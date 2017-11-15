using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model.DEL; //capa de entidades
using model.DAL; //capa de acceso a datos

namespace model.BEL
{
    public class AuxObraBEL
    {
        private AuxObraDAO objAuxObraDAO;
        private AuxObraDALdet objAuxObraDALdet;

        public AuxObraBEL()
        {
            objAuxObraDAO = new AuxObraDAO();
            objAuxObraDALdet = new AuxObraDALdet();
        }

        public void create(AuxiliarObra objAuxObra)
        {
            bool validar;
            //validar Numero Axiliar, estado =1
            string codigo = objAuxObra.NumeroAux.ToString();
            if (codigo == null)
            {
                objAuxObra.Estado_error = 10;
            }
            else
            {
                try
                {
                    validar = Convert.ToInt32(codigo) >= 0;
                    if (!validar)
                    {
                        objAuxObra.Estado_error = 1;
                        return;
                    }
                }
                catch (Exception)
                {
                    objAuxObra.Estado_error = 100;
                }
            }

            //validar Nombre Contratista, estado =2
            string nombreContratista = objAuxObra.Contratista;
            if (codigo == null)
            {
                objAuxObra.Estado_error = 20;
            }
            else
            {
                try
                {
                    nombreContratista = objAuxObra.Contratista.Trim();

                    validar = nombreContratista.Length > 0 && nombreContratista.Length <= 50; //para validar el numero de caracteres del campo
                    if (!validar)
                    {
                        objAuxObra.Estado_error = 2;
                        return;
                    }
                }
                catch (Exception)
                {
                    objAuxObra.Estado_error = 100;
                }
            }
 
            //validar Objeto Contrato, estado = 3

            //validar Key Duplicada, estado = 50
            AuxiliarObra objAuxObraDup = new AuxiliarObra();
            objAuxObraDup.NumeroAux = objAuxObra.NumeroAux;
            validar = !objAuxObraDAO.find(objAuxObraDup);
            if (!validar)
            {
                objAuxObra.Estado_error = 50;
                return;
            }
            objAuxObra.Estado_error = 99;
            objAuxObraDAO.create(objAuxObra);


        }

        public void delete(AuxiliarObra objAuxObra)
        {
            bool validar;
            AuxiliarObra objAuxObraDel = new AuxiliarObra();
            objAuxObraDel.NumeroAux = objAuxObra.NumeroAux;
            validar = objAuxObraDAO.find(objAuxObraDel);
            if(!validar)
            {
                objAuxObra.Estado_error = 33;
                return;
            }
            objAuxObra.Estado_error = 99;
            objAuxObraDAO.delete(objAuxObra);
        }

        public bool find(AuxiliarObra objAuxObra)
        {
            return objAuxObraDAO.find(objAuxObra);
        }

        public List<AuxiliarObra> findAll()
        {
            return objAuxObraDAO.findAll();
        }

        public List<AuxiliarObra> findAuxObraNro(AuxiliarObra objAuxObra)
        {
            return objAuxObraDAO.findAuxObraNro(objAuxObra);
        }

        public List<AuxiliarObra> findAuxObraDate(string objFechaInio, string objFechaFin)
        {
            return objAuxObraDAO.findAuxObraDate(objFechaInio, objFechaFin);
        }

        public List<AuxiliarObraDet> findAuxObraNroDet(AuxiliarObraDet objAuxObraDet)
        {
            return objAuxObraDALdet.findAuxObraNroDet(objAuxObraDet);
        }

        public List<AuxiliarObraDet> findAllDet()
        {
            return objAuxObraDALdet.findAllDet();
        }

    }
}
