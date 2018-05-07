using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Odbc;
using model.DEL;

namespace model.DAL
{
    public class AuxObraDALdet : ObligatorioDet<AuxiliarObraDet>
    {
        private Conexion conexionObj;
        private OdbcCommand comandoObj;
        private OdbcDataReader objDR;

        //Constructor
        public AuxObraDALdet()
        {
            conexionObj = Conexion.estadoActual();
        }

        public List<AuxiliarObraDet> findAuxObraNroDet(AuxiliarObraDet objAuxObraDet)
        {
            List<AuxiliarObraDet> listaAuxObraNroDet = new List<AuxiliarObraDet>();

            string strSQL = @"SELECT CONTRA2.NUMERO, CONTRA2.NPLAN, CONTRA2.CONTROL, CONTRA2.CHEQUE AS REFERENCIA, CONTRA2.CONCEP as CONCEPTO, CONTRA2.FECHAP, " 
                          + @"CONTRA2.MULTAS, CONTRA2.RETENCION, CONTRA2.ENTREGADO, CONTRA2.PLANILLADO, CONTRA2.REAJUSTE, CONTRA2.INEC, CONTRA2.FINAN " 
                          + @"FROM CONTRA2 " 
                          + @"WHERE CONTRA2.NUMERO = '" + objAuxObraDet.NumeroAux.ToUpper() + "' " 
                          + @"ORDER BY CONTRA2.NPLAN ";

            try
            {
                comandoObj = new OdbcCommand(strSQL, conexionObj.getCon());
                //comandoObj = new OleDbCommand(strSQL, conexionObj.getCon());
                conexionObj.getCon().Open();
                objDR = comandoObj.ExecuteReader();
                while (objDR.Read())
                {
                    AuxiliarObraDet objAuxObraNroDet = new AuxiliarObraDet();
                    //TABLA CONTRA2
                    objAuxObraNroDet.NumeroAux = objDR[0].ToString();
                    objAuxObraNroDet.NumeroPla = objDR[1].ToString();
                    objAuxObraNroDet.DocControl = objDR[2].ToString();
                    objAuxObraNroDet.DocReferencia = objDR[3].ToString();
                    objAuxObraNroDet.Concepto = objDR[4].ToString().ToUpper();
                    objAuxObraNroDet.FechaPago = string.Format("{0:dd/MM/yyyy}", objDR[5]);
                    objAuxObraNroDet.ValorMulta = Convert.ToDecimal(objDR[6].ToString());
                    objAuxObraNroDet.RetencionPla = Convert.ToDecimal(objDR[7].ToString());
                    objAuxObraNroDet.ValorEntregado = Convert.ToDecimal(objDR[8].ToString());
                    objAuxObraNroDet.ValorPlanilla = Convert.ToDecimal(objDR[9].ToString());
                    objAuxObraNroDet.ValorReajuste = Convert.ToDecimal(objDR[10].ToString());
                    objAuxObraNroDet.ValorInec = Convert.ToDecimal(objDR[11].ToString());
                    objAuxObraNroDet.ValorFinanzas = Convert.ToDecimal(objDR[12].ToString());
                    listaAuxObraNroDet.Add(objAuxObraNroDet);
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
            return (listaAuxObraNroDet);
        }

        public List<AuxiliarObraDet> findAllDet()
        {
            List<AuxiliarObraDet> listaAuxObraDet = new List<AuxiliarObraDet>();

            string strSQL = @"SELECT CONTRA2.NUMERO, CONTRA2.NPLAN, CONTRA2.CONTROL, CONTRA2.CHEQUE AS REFERENCIA, CONTRA2.CONCEP as CONCEPTO, CONTRA2.FECHAP, " +
                            @"CONTRA2.MULTAS, CONTRA2.RETENCION, CONTRA2.ENTREGADO, CONTRA2.PLANILLADO, CONTRA2.REAJUSTE, CONTRA2.INEC, CONTRA2.FINAN " +
                            @"FROM CONTRA2 " +
                            @"ORDER BY CONTRA2.NUMERO, CONTRA2.NPLAN ";

            try
            {
                comandoObj = new OdbcCommand(strSQL, conexionObj.getCon());
                //comandoObj = new OleDbCommand(strSQL, conexionObj.getCon());
                conexionObj.getCon().Open();
                objDR = comandoObj.ExecuteReader();
                while (objDR.Read())
                {
                    AuxiliarObraDet objAuxObraDet = new AuxiliarObraDet();
                    //TABLA CONTRA2
                    objAuxObraDet.NumeroAux = objDR[0].ToString();
                    objAuxObraDet.NumeroPla = objDR[1].ToString();
                    objAuxObraDet.DocControl = objDR[2].ToString();
                    objAuxObraDet.DocReferencia = objDR[3].ToString();
                    objAuxObraDet.Concepto = objDR[4].ToString().ToUpper();
                    objAuxObraDet.FechaPago = string.Format("{0:dd/MM/yyyy}", objDR[5]);
                    objAuxObraDet.ValorMulta = Convert.ToDecimal(objDR[6].ToString());
                    objAuxObraDet.RetencionPla = Convert.ToDecimal(objDR[7].ToString());
                    objAuxObraDet.ValorEntregado = Convert.ToDecimal(objDR[8].ToString());
                    objAuxObraDet.ValorPlanilla = Convert.ToDecimal(objDR[9].ToString());
                    objAuxObraDet.ValorReajuste = Convert.ToDecimal(objDR[10].ToString());
                    objAuxObraDet.ValorInec = Convert.ToDecimal(objDR[11].ToString());
                    objAuxObraDet.ValorFinanzas = Convert.ToDecimal(objDR[12].ToString());
                    listaAuxObraDet.Add(objAuxObraDet);
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
            return (listaAuxObraDet);
        }

    }
}