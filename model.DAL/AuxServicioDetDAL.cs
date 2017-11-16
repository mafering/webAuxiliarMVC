using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Odbc;
using model.DEL;

namespace model.DAL
{
    public class AuxServicioDetDAL : ObligatorioServDet<AuxiliarServicioDet>
    {
        private Conexion conexionObj;
        private OdbcCommand comandoObj;
        private OdbcDataReader objDR;

        //Constructor
        public AuxServicioDetDAL()
        {
            conexionObj = Conexion.estadoActual();
        }

        public List<AuxiliarServicioDet> findAuxServNroDet(AuxiliarServicioDet objAuxServicioDet)
        {
            List<AuxiliarServicioDet> listaAuxServiNroDet = new List<AuxiliarServicioDet>();

            string strSQL = @"SELECT ADQUI2.NUMERO_B, ADQUI2.NPLANI_B, ADQUI2.CHEQUE_B, ADQUI2.CONCEP_B, ADQUI2.FECHAP_B, ADQUI2.RETENC_B, ADQUI2.ENTREG_B, "
                          + @"ADQUI2.PLANIL_B, ADQUI2.MULTAS_B, ADQUI2.FINAN__B "
                          + @"FROM ADQUI2 "
                          + @"WHERE ADQUI2.NUMERO_B = '" + objAuxServicioDet.NumeroAux + "'" 
                          + @"ORDER BY ADQUI2.NUMERO_B, ADQUI2.NPLANI_B ";
            try
            {
                comandoObj = new OdbcCommand(strSQL, conexionObj.getCon());
                //comandoObj = new OleDbCommand(strSQL, conexionObj.getCon());
                conexionObj.getCon().Open();
                objDR = comandoObj.ExecuteReader();
                while (objDR.Read())
                {
                    AuxiliarServicioDet objAuxServiNroDet = new AuxiliarServicioDet();
                    //TABLA ADQUI2
                    objAuxServiNroDet.NumeroAux = objDR[0].ToString();
                    objAuxServiNroDet.NumeroPla = objDR[1].ToString();
                    objAuxServiNroDet.DocReferencia = objDR[2].ToString();
                    objAuxServiNroDet.Concepto = objDR[3].ToString().ToUpper();
                    objAuxServiNroDet.FechaPago = string.Format("{0:dd/MM/yyyy}", objDR[4]);
                    objAuxServiNroDet.RetencionPla = Convert.ToDecimal(objDR[5].ToString());
                    objAuxServiNroDet.ValorEntregado = Convert.ToDecimal(objDR[6].ToString());
                    objAuxServiNroDet.ValorPlanilla = Convert.ToDecimal(objDR[7].ToString());
                    objAuxServiNroDet.ValorMulta = Convert.ToDecimal(objDR[8].ToString());
                    objAuxServiNroDet.ValorFinanzas = Convert.ToDecimal(objDR[9].ToString());
                    listaAuxServiNroDet.Add(objAuxServiNroDet);
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
            return (listaAuxServiNroDet);
        }

        public List<AuxiliarServicioDet> findAllServDet()
        {
            List<AuxiliarServicioDet> listaAuxServicioDet = new List<AuxiliarServicioDet>();

            string strSQL = @"SELECT ADQUI2.NUMERO_B, ADQUI2.NPLANI_B, ADQUI2.CHEQUE_B, ADQUI2.CONCEP_B, ADQUI2.FECHAP_B, ADQUI2.RETENC_B, ADQUI2.ENTREG_B, "
                          + @"ADQUI2.PLANIL_B, ADQUI2.MULTAS_B, ADQUI2.FINAN__B "
                          + @"FROM ADQUI2 "
                          + @"ORDER BY ADQUI2.NUMERO_B, ADQUI2.NPLANI_B ";

            try
            {
                comandoObj = new OdbcCommand(strSQL, conexionObj.getCon());
                //comandoObj = new OleDbCommand(strSQL, conexionObj.getCon());
                conexionObj.getCon().Open();
                objDR = comandoObj.ExecuteReader();
                while (objDR.Read())
                {
                    AuxiliarServicioDet objAuxServicioDet = new AuxiliarServicioDet();
                    //TABLA ADQUI2
                    objAuxServicioDet.NumeroAux = objDR[0].ToString();
                    objAuxServicioDet.NumeroPla = objDR[1].ToString();
                    objAuxServicioDet.DocReferencia = objDR[2].ToString();
                    objAuxServicioDet.Concepto = objDR[3].ToString().ToUpper();
                    objAuxServicioDet.FechaPago = string.Format("{0:dd/MM/yyyy}", objDR[4]);
                    objAuxServicioDet.RetencionPla = Convert.ToDecimal(objDR[5].ToString());
                    objAuxServicioDet.ValorEntregado = Convert.ToDecimal(objDR[6].ToString());
                    objAuxServicioDet.ValorPlanilla = Convert.ToDecimal(objDR[7].ToString());
                    objAuxServicioDet.ValorMulta = Convert.ToDecimal(objDR[8].ToString());
                    objAuxServicioDet.ValorFinanzas = Convert.ToDecimal(objDR[9].ToString());
                    listaAuxServicioDet.Add(objAuxServicioDet);
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
            return (listaAuxServicioDet);
        }
    }
}
