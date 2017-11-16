using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Odbc;
using model.DEL;
using System.Web;

namespace model.DAL
{
    public class AuxServicioDAL : ObligatorioServ<AuxiliarServicio>
    {
        private ConexionServicio conexionObj;
        private OdbcCommand comandoObj;
        private OdbcDataReader objDR;

        public AuxServicioDAL()
        {
            conexionObj = ConexionServicio.estadoActual();
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

        public bool find(AuxiliarServicio objAuxServicio)
        {
            //bool findRegistro;

            return false; //findRegistro;
        }

        public List<AuxiliarServicio> findAll()
        {
            List<AuxiliarServicio> listaAuxServicio = new List<AuxiliarServicio>();

            string strSQL = @"SELECT NUMERO_A, year([FECHAC_A]) as ANIO, PENAS__A AS CEDRUC, CONTRA_A as CONTRATISTA, DETAL1_A & ' ' & DETAL2_A AS OBJETO, "
                          + @"PARTID_A AS PARTIDA, MONTOC_A AS MONTO_CTO, FECHAC_A AS FECHAC, PLAZO__A AS PLAZO, FORPAG_A AS FORMA_PAGO "
                          + @"FROM ADQUI1 "
                          + @"ORDER BY NUMERO_A";
            try
            {
                comandoObj = new OdbcCommand(strSQL, conexionObj.getCon());
                conexionObj.getCon().Open();
                OdbcDataReader objDR = comandoObj.ExecuteReader();
                while (objDR.Read())
                {
                    AuxiliarServicio objAuxServicio = new AuxiliarServicio();
                    objAuxServicio.NumeroAux = objDR[0].ToString();
                    objAuxServicio.AnioCto = objDR[1].ToString();
                    objAuxServicio.CedRuc = objDR[2].ToString();
                    objAuxServicio.Contratista = objDR[3].ToString();
                    objAuxServicio.ObjetoCto = objDR[4].ToString().ToUpper();
                    objAuxServicio.Partida = objDR[5].ToString();
                    objAuxServicio.MontoCto = Convert.ToDecimal(objDR[6].ToString());
                    objAuxServicio.FechaCto = string.Format("{0:dd/MM/yyyy}", objDR[7]);
                    objAuxServicio.Plazo = objDR[8].ToString().Trim();
                    objAuxServicio.FormaPago = objDR[9].ToString();
                    listaAuxServicio.Add(objAuxServicio);
                }

            }
            catch (Exception ex)
            {
                //throw;
                ex.Message.ToString();
            }
            finally
            {
                conexionObj.getCon().Close();
                conexionObj.conexionClose();
            }
            return (listaAuxServicio);
        }

        public List<AuxiliarServicio> findAuxServNro(AuxiliarServicio objAuxServicio)
        {
            List<AuxiliarServicio> listaAuxServNro = new List<AuxiliarServicio>();

            string strSQL = @"SELECT NUMERO_A, year([FECHAC_A]) as ANIO, PENAS__A AS CEDRUC, CONTRA_A as CONTRATISTA, DETAL1_A & ' ' & DETAL2_A AS OBJETO, " +
                            @"PARTID_A AS PARTIDA, MONTOC_A AS MONTO_CTO, FECHAC_A AS FECHAC, PLAZO__A AS PLAZO, FORPAG_A AS FORMA_PAGO " +
                            @"FROM ADQUI1 " +
                            @"WHERE NUMERO_A = '" + objAuxServicio.NumeroAux + "'";
            try
            {
                comandoObj = new OdbcCommand(strSQL, conexionObj.getCon());
                conexionObj.getCon().Open();
                objDR = comandoObj.ExecuteReader();
                while (objDR.Read())
                {
                    AuxiliarServicio objAuxServNro = new AuxiliarServicio();
                    objAuxServNro.NumeroAux = objDR[0].ToString();
                    objAuxServNro.AnioCto = objDR[1].ToString();
                    objAuxServNro.CedRuc = objDR[2].ToString();
                    objAuxServNro.Contratista = objDR[3].ToString();
                    objAuxServNro.ObjetoCto = objDR[4].ToString().ToUpper();
                    objAuxServNro.Partida = objDR[5].ToString();
                    objAuxServNro.MontoCto = Convert.ToDecimal(objDR[6].ToString());
                    objAuxServNro.FechaCto = string.Format("{0:dd/MM/yyyy}", objDR[7]);
                    objAuxServNro.Plazo = objDR[8].ToString().Trim();
                    objAuxServNro.FormaPago = objDR[9].ToString();
                    listaAuxServNro.Add(objAuxServNro);
                }

            }
            catch (Exception ex)
            {
                //throw;
                ex.Message.ToString();
            }
            finally
            {
                conexionObj.getCon().Close();
                conexionObj.conexionClose();
            }
            return (listaAuxServNro);
        }

        public List<AuxiliarServicio> findAuxServDate(string objFechaInicio, string objFechaFin)
        {
            List<AuxiliarServicio> listaAuxServDate = new List<AuxiliarServicio>();


            if (objFechaInicio == null || objFechaFin == null)
            {
                conexionObj.getCon().Close();
                conexionObj.conexionClose();
            }
            else
            {
                objFechaInicio = string.Format("{0:MM/dd/yyyy}", objFechaInicio);
                objFechaFin = string.Format("{0:MM/dd/yyyy}", objFechaFin);

                string strSQL = @"SELECT NUMERO_A, year([FECHAC_A]) as ANIO, PENAS__A AS CEDRUC, CONTRA_A as CONTRATISTA, DETAL1_A & ' ' & DETAL2_A AS OBJETO, "
                              + @"PARTID_A AS PARTIDA, MONTOC_A AS MONTO_CTO, FECHAC_A AS FECHAC, PLAZO__A AS PLAZO, FORPAG_A AS FORMA_PAGO "
                              + @"FROM ADQUI1 " 
                              + @"WHERE FECHAC_A >= #" + objFechaInicio + "# AND FECHAC_A <= #" + objFechaFin + "# "
                              + @"ORDER BY NUMERO_A DESC";

                try
                {
                    comandoObj = new OdbcCommand(strSQL, conexionObj.getCon());
                    conexionObj.getCon().Open();
                    OdbcDataReader objDR = comandoObj.ExecuteReader();
                    while (objDR.Read())
                    {
                        AuxiliarServicio objAuxServDate = new AuxiliarServicio();
                        objAuxServDate.NumeroAux = objDR[0].ToString();
                        objAuxServDate.AnioCto = objDR[1].ToString();
                        objAuxServDate.CedRuc = objDR[2].ToString();
                        objAuxServDate.Contratista = objDR[3].ToString();
                        objAuxServDate.ObjetoCto = objDR[4].ToString().ToUpper();
                        objAuxServDate.Partida = objDR[5].ToString();
                        objAuxServDate.MontoCto = Convert.ToDecimal(objDR[6].ToString());
                        objAuxServDate.FechaCto = string.Format("{0:dd/MM/yyyy}", objDR[7]);
                        objAuxServDate.Plazo = objDR[8].ToString().Trim();
                        objAuxServDate.FormaPago = objDR[9].ToString();
                        listaAuxServDate.Add(objAuxServDate);
                    }

                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                }
                finally
                {
                    conexionObj.getCon().Close();
                    conexionObj.conexionClose();
                }
            }
            return (listaAuxServDate);
        }
    }
}
