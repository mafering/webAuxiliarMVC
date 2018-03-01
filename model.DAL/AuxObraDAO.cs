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
    public class AuxObraDAO : Obligatorio<AuxiliarObra>
    {
        private Conexion conexionObj;
        private OdbcCommand comandoObj;
        private OdbcDataReader objDR;

        public AuxObraDAO()
        {
            conexionObj = Conexion.estadoActual();
        }

        public void create(AuxiliarObra objAuxObra)
        {
            string create = @"INSERT INTO CONTRA4 VALUES('" 
                            + objAuxObra.NumeroAux + "', '"
                            + objAuxObra.CedRuc + "', '"
                            + objAuxObra.Contratista + "', '"
                            + objAuxObra.ObjetoCto + "', '"
                            + objAuxObra.Partida + "', '"
                            + objAuxObra.MontoCto + "', '"
                            + objAuxObra.FechaCto + "', '"
                            + objAuxObra.Plazo + "', '"
                            + objAuxObra.CodigoCto + "')";

            try
            {
                comandoObj = new OdbcCommand(create, conexionObj.getCon());
                //comandoObj = new OleDbCommand(create, conexionObj.getCon());
                conexionObj.getCon().Open();
                comandoObj.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conexionObj.getCon().Close();
                conexionObj.conexionClose();
            }
        }

        public void update(AuxiliarObra objAuxObra)
        {
            string update = "UPDATE INTO... VALUES('" + objAuxObra.NumeroAux + "', ";
            try
            {
                comandoObj = new OdbcCommand(update, conexionObj.getCon());
                //comandoObj = new OleDbCommand(update, conexionObj.getCon());
                conexionObj.getCon().Open();
                comandoObj.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conexionObj.getCon().Close();
                conexionObj.conexionClose();
            }
        }

        public void delete(AuxiliarObra objAuxObra)
        {
            string delete = "DELETE INTO... VALUES('" + objAuxObra.NumeroAux + "', ";
            try
            {
                comandoObj = new OdbcCommand(delete, conexionObj.getCon());
                //comandoObj = new OleDbCommand(delete, conexionObj.getCon());
                conexionObj.getCon().Open();
                comandoObj.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conexionObj.getCon().Close();
                conexionObj.conexionClose();
            }
        }

        public bool find(AuxiliarObra objAuxObra)
        {
            bool findRegistro;

            string strSQL = @"SELECT NUMERO, year([FECHAC]) as ANIO, INCREMENTO AS CED_RUC, CONTRATI as CONTRATISTA, DETALLE & ' ' & DETALLE2 AS OBJETO, " +
                            @"PARTIDA, MONTOCONT AS MONTO_CTO, FECHAC, PLAZO, PRORROGA AS COD_CONTRATO " +
                            @"FROM CONTRA4 WHERE NUMERO = '" + objAuxObra.NumeroAux + "'";
            try
            {
                comandoObj = new OdbcCommand(strSQL, conexionObj.getCon());
                //comandoObj = new OleDbCommand(strSQL, conexionObj.getCon());
                conexionObj.getCon().Open();
                objDR = comandoObj.ExecuteReader();
                findRegistro = objDR.Read();
                if (findRegistro)
                {
                    objAuxObra.NumeroAux = objDR[0].ToString();
                    objAuxObra.AnioCto = objDR[1].ToString();
                    objAuxObra.CedRuc = objDR[2].ToString();
                    objAuxObra.Contratista = objDR[3].ToString();
                    objAuxObra.ObjetoCto = objDR[4].ToString().ToUpper();
                    objAuxObra.Partida = objDR[5].ToString();
                    objAuxObra.MontoCto = Convert.ToDecimal(objDR[6].ToString());
                    objAuxObra.FechaCto = string.Format("{0:dd/MM/yyyy}", objDR[7]);
                    objAuxObra.Plazo = objDR[8].ToString().Trim();
                    objAuxObra.CodigoCto = objDR[9].ToString();

                    objAuxObra.Estado_error = 99;
                }
                else
                {
                    objAuxObra.Estado_error = 1;
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conexionObj.getCon().Close();
                conexionObj.conexionClose();
            }
            return findRegistro;

        }

        public List<AuxiliarObra> findAll()
        {
            List<AuxiliarObra> listaAuxObra = new List<AuxiliarObra>();

            //string strSQL = @"SELECT NUMERO, year([FECHAC]) as ANIO, INCREMENTO AS CEDRUCS, CONTRATI as CONTRATISTA, "
            //              + @"DETALLE & ' ' & DETALLE2 AS OBJETO, PARTIDA, MONTOCONT AS MONTO_CTO, FECHAC, PLAZO, PRORROGA AS COD_CONTRATO "
            //              + @"FROM CONTRA4 "
            //              + @"ORDER BY FECHAC DESC";
            string strSQL = @"SELECT C4.NUMERO, Year([C4.FECHAC]) AS ANIO, C4.INCREMENTO AS CEDRUC, C4.CONTRATI AS CONTRATISTA, "
                          + @"C4.DETALLE & ' ' & C4.DETALLE2 AS OBJETO, C4.PARTIDA, C4.MONTOCONT AS MONTO_CTO, C4.FECHAC, C4.PLAZO, C4.PRORROGA AS COD_CONTRATO, "
                          + @"Sum(C2.ENTREGADO) AS ENTREGADO, Sum(C2.RETENCION) AS DEVENGADO, Sum(C2.MULTAS) AS MULTAS, Sum(C2.PLANILLADO) AS PLANILLADO, "
                          + @"Sum(C2.REAJUSTE) AS REAJUSTE, (Sum(C2.PLANILLADO) + Sum(C2.REAJUSTE)) AS INVERTIDO "
                          + @"FROM CONTRA4 AS C4 INNER JOIN CONTRA2 AS C2 ON C4.NUMERO = C2.NUMERO "
                          + @"GROUP BY C4.NUMERO, Year([C4.FECHAC]), C4.INCREMENTO, C4.CONTRATI, C4.DETALLE & ' ' & C4.DETALLE2, C4.PARTIDA, C4.MONTOCONT, C4.FECHAC, C4.PLAZO, C4.PRORROGA ";
                          //+ @"HAVING (C4.FECHAC>=#1/1/2001#) ";
                          //+ @"ORDER BY Year([C4.FECHAC])";
            

            try
            {
                comandoObj = new OdbcCommand(strSQL, conexionObj.getCon());
                conexionObj.getCon().Open();
                OdbcDataReader objDR = comandoObj.ExecuteReader();
                
                while (objDR.Read())
                {
                    AuxiliarObra objAuxObra = new AuxiliarObra();
                    objAuxObra.NumeroAux = objDR[0].ToString();
                    objAuxObra.AnioCto = objDR[1].ToString();
                    objAuxObra.CedRuc = objDR[2].ToString();
                    objAuxObra.Contratista = objDR[3].ToString();
                    objAuxObra.ObjetoCto = objDR[4].ToString().ToUpper();
                    objAuxObra.Partida = objDR[5].ToString();
                    objAuxObra.MontoCto = Convert.ToDecimal(objDR[6].ToString());
                    objAuxObra.FechaCto = string.Format("{0:dd/MM/yyyy}", objDR[7]);
                    objAuxObra.Plazo = objDR[8].ToString().Trim();
                    objAuxObra.CodigoCto = objDR[9].ToString();
                    objAuxObra.sumValEntregado = Convert.ToDecimal(objDR[10].ToString());
                    objAuxObra.sumValDevengado = Convert.ToDecimal(objDR[11].ToString());
                    objAuxObra.sumValMulta = Convert.ToDecimal(objDR[12].ToString());
                    objAuxObra.sumValPlanillado = Convert.ToDecimal(objDR[13].ToString());
                    objAuxObra.sumValReajuste = Convert.ToDecimal(objDR[14].ToString());
                    objAuxObra.TotalInvertido = Convert.ToDecimal(objDR[15].ToString());
                    listaAuxObra.Add(objAuxObra);
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
            return (listaAuxObra);
        }

        public List<AuxiliarObra> findAuxObraNro(AuxiliarObra objAuxObra)
        {
            List<AuxiliarObra> listaAuxObraNro = new List<AuxiliarObra>();

            string strSQL = @"SELECT NUMERO, year([FECHAC]) as ANIO, INCREMENTO AS CED_RUC, CONTRATI as CONTRATISTA, DETALLE & ' ' & DETALLE2 AS OBJETO, " +
                            @"PARTIDA, MONTOCONT AS MONTO_CTO, FECHAC, PLAZO, PRORROGA AS COD_CONTRATO " +
                            @"FROM CONTRA4 WHERE NUMERO = '" + objAuxObra.NumeroAux + "'";
            try
            {
                comandoObj = new OdbcCommand(strSQL, conexionObj.getCon());
                //comandoObj = new OleDbCommand(strSQL, conexionObj.getCon());
                conexionObj.getCon().Open();
                objDR = comandoObj.ExecuteReader();
                while (objDR.Read())
                {
                    AuxiliarObra objAuxObraNro = new AuxiliarObra();
                    objAuxObra.NumeroAux = objDR[0].ToString();
                    objAuxObra.AnioCto = objDR[1].ToString();
                    objAuxObra.CedRuc = objDR[2].ToString();
                    objAuxObra.Contratista = objDR[3].ToString();
                    objAuxObra.ObjetoCto = objDR[4].ToString().ToUpper();
                    objAuxObra.Partida = objDR[5].ToString();
                    objAuxObra.MontoCto = Convert.ToDecimal(objDR[6].ToString());
                    objAuxObra.FechaCto = string.Format("{0:dd/MM/yyyy}", objDR[7]);
                    objAuxObra.Plazo = objDR[8].ToString().Trim();
                    objAuxObra.CodigoCto = objDR[9].ToString();
                    listaAuxObraNro.Add(objAuxObra);
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
            return (listaAuxObraNro);
        }

        public List<AuxiliarObra> findAuxObraDate(string objFechaInicio, string objFechaFin)
        {
            List<AuxiliarObra> listaAuxObra = new List<AuxiliarObra>();


            if (objFechaInicio == null || objFechaFin == null)
            {
                conexionObj.getCon().Close();
                conexionObj.conexionClose();
            }
            else
            {
                objFechaInicio = string.Format("{0:MM/dd/yyyy}", objFechaInicio);
                objFechaFin = string.Format("{0:MM/dd/yyyy}", objFechaFin);

                //string strSQL = @"SELECT NUMERO, year([FECHAC]) as ANIO, INCREMENTO AS CEDRUCS, CONTRATI as CONTRATISTA, "
                //              + @"DETALLE & ' ' & DETALLE2 AS OBJETO, PARTIDA, MONTOCONT AS MONTO_CTO, FECHAC, PLAZO, PRORROGA AS COD_CONTRATO "
                //              + @"FROM CONTRA4 WHERE FECHAC >= #" + objFechaInicio + "# AND FECHAC <= #" + objFechaFin + "# "
                //              + @"ORDER BY NUMERO DESC";


                string strSQL = @"SELECT C4.NUMERO, Year([C4.FECHAC]) AS ANIO, C4.INCREMENTO AS CEDRUC, C4.CONTRATI AS CONTRATISTA, "
                                          + @"C4.DETALLE & ' ' & C4.DETALLE2 AS OBJETO, C4.PARTIDA, C4.MONTOCONT AS MONTO_CTO, C4.FECHAC, C4.PLAZO, C4.PRORROGA AS COD_CONTRATO, "
                                          + @"Sum(C2.ENTREGADO) AS ENTREGADO, Sum(C2.RETENCION) AS DEVENGADO, Sum(C2.MULTAS) AS MULTAS, Sum(C2.PLANILLADO) AS PLANILLADO, "
                                          + @"Sum(C2.REAJUSTE) AS REAJUSTE, (Sum(C2.PLANILLADO) + Sum(C2.REAJUSTE)) AS INVERTIDO "
                                          + @"FROM CONTRA4 AS C4 INNER JOIN CONTRA2 AS C2 ON C4.NUMERO = C2.NUMERO "
                                          + @"GROUP BY C4.NUMERO, Year([C4.FECHAC]), C4.INCREMENTO, C4.CONTRATI, C4.DETALLE & ' ' & C4.DETALLE2, C4.PARTIDA, C4.MONTOCONT, C4.FECHAC, C4.PLAZO, C4.PRORROGA "
                                          + @"HAVING (C4.FECHAC >= #" + objFechaInicio + "# AND C4.FECHAC <= #" + objFechaFin + "#)";

                try
                {
                    comandoObj = new OdbcCommand(strSQL, conexionObj.getCon());
                    conexionObj.getCon().Open();
                    OdbcDataReader objDR = comandoObj.ExecuteReader();
                    while (objDR.Read())
                    {
                        AuxiliarObra objAuxObraDate = new AuxiliarObra();
                        objAuxObraDate.NumeroAux = objDR[0].ToString();
                        objAuxObraDate.AnioCto = objDR[1].ToString();
                        objAuxObraDate.CedRuc = objDR[2].ToString();
                        objAuxObraDate.Contratista = objDR[3].ToString();
                        objAuxObraDate.ObjetoCto = objDR[4].ToString().ToUpper();
                        objAuxObraDate.Partida = objDR[5].ToString();
                        objAuxObraDate.MontoCto = Convert.ToDecimal(objDR[6].ToString());
                        objAuxObraDate.FechaCto = string.Format("{0:dd/MM/yyyy}", objDR[7]);
                        objAuxObraDate.Plazo = objDR[8].ToString().Trim();
                        objAuxObraDate.CodigoCto = objDR[9].ToString();
                        objAuxObraDate.sumValEntregado = Convert.ToDecimal(objDR[10].ToString());
                        objAuxObraDate.sumValDevengado = Convert.ToDecimal(objDR[11].ToString());
                        objAuxObraDate.sumValMulta = Convert.ToDecimal(objDR[12].ToString());
                        objAuxObraDate.sumValPlanillado = Convert.ToDecimal(objDR[13].ToString());
                        objAuxObraDate.sumValReajuste = Convert.ToDecimal(objDR[14].ToString());
                        objAuxObraDate.TotalInvertido = Convert.ToDecimal(objDR[15].ToString());
                        listaAuxObra.Add(objAuxObraDate);
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
            return (listaAuxObra);
        }
    }
 }
