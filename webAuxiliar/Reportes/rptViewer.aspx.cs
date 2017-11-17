using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using model.DEL;
using model.BEL;
using System.Data;
using System.Text;

namespace webAuxiliar.Reportes
{
    public partial class rptViewer : System.Web.UI.Page
    {
        private AuxObraBEL objAuxObraBEL = new AuxObraBEL();
        private AuxObraBEL objAuxObraBELdet = new AuxObraBEL();
        private AuxServicioBEL objAuxServicioBEL = new AuxServicioBEL();
        private AuxServicioBEL objAuxServiDetBEL = new AuxServicioBEL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string searchText = string.Empty;
                if (Request.QueryString["rptAuxObra"] != null)
                {
                    searchText = Request.QueryString["rptAuxObra"].ToString();

                    AuxiliarObra objAuxObraNro = new AuxiliarObra();
                    objAuxObraNro.NumeroAux = searchText;
                    List<AuxiliarObra> listaAuxObra;
                    listaAuxObra = objAuxObraBEL.findAuxObraNro(objAuxObraNro);

                    //listaAuxObra = _context.Customers.Where(t => t.FirstName.Contains(searchText) || t.LastName.Contains(searchText)).OrderBy(a => a.CustomerID).ToList();
                    //listaAuxObra = listaAuxObra.Where(t => t.NumeroAux.Contains(searchText)).ToList();

                    rvDataViewer.LocalReport.ReportPath = Server.MapPath("~/Reportes/RDLC/rptAuxObra.rdlc");
                    rvDataViewer.LocalReport.DataSources.Clear();
                    ReportDataSource rdc1 = new ReportDataSource("dsAuxObraCabecera", listaAuxObra);
                    rvDataViewer.LocalReport.DataSources.Add(rdc1);

                    //AuxiliarObraDet objAuxObraNroDet = new AuxiliarObraDet();
                    //objAuxObraNroDet.NumeroAux = searchText;
                    //List<AuxiliarObraDet> listaAuxObraDet;
                    //listaAuxObraDet = objAuxObraBELdet.findAuxObraNroDet(objAuxObraNroDet);
                    //ReportDataSource rdc2 = new ReportDataSource("dsAuxObraDetalle", listaAuxObraDet);
                    //rvDataViewer.LocalReport.DataSources.Add(rdc2);

                    rvDataViewer.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(sRptAuxObraDetalle);
                }
                else if (Request.QueryString["rptAuxServicio"] != null)
                {
                    searchText = Request.QueryString["rptAuxServicio"].ToString();

                    AuxiliarServicio objAuxServNro = new AuxiliarServicio();
                    objAuxServNro.NumeroAux = searchText;
                    List<AuxiliarServicio> listaAuxServicio;
                    listaAuxServicio = objAuxServicioBEL.findAuxServNro(objAuxServNro);

                    rvDataViewer.LocalReport.ReportPath = Server.MapPath("~/Reportes/RDLC/rptAuxServicio.rdlc");
                    rvDataViewer.LocalReport.DataSources.Clear();
                    ReportDataSource rdc1 = new ReportDataSource("dsAuxServicio", listaAuxServicio);
                    rvDataViewer.LocalReport.DataSources.Add(rdc1);

                    rvDataViewer.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(sRptAuxServicioDetalle);
                }

                rvDataViewer.LocalReport.Refresh();
                rvDataViewer.DataBind();
            }
        }

        public void sRptAuxObraDetalle(object sender, SubreportProcessingEventArgs e)
        {
            string auxobraID = e.Parameters["NumeroAux"].Values[0].ToString();

            AuxiliarObraDet objAuxObraNroDet = new AuxiliarObraDet();
            objAuxObraNroDet.NumeroAux = auxobraID;
            List<AuxiliarObraDet> listaAuxObraDet;
            listaAuxObraDet = objAuxObraBELdet.findAuxObraNroDet(objAuxObraNroDet);
            e.DataSources.Add(new ReportDataSource("dsAuxObraDetalle", listaAuxObraDet));
        }

        public void sRptAuxServicioDetalle(object sender, SubreportProcessingEventArgs e)
        {
            string auxServicioID = e.Parameters["NumeroAux"].Values[0].ToString();

            AuxiliarServicioDet objAuxServiNroDet = new AuxiliarServicioDet();
            objAuxServiNroDet.NumeroAux = auxServicioID;
            List<AuxiliarServicioDet> listaAuxServicioDet;  
            listaAuxServicioDet = objAuxServiDetBEL.findAuxServNroDet(objAuxServiNroDet);
            e.DataSources.Add(new ReportDataSource("dsAuxServicioPago", listaAuxServicioDet));
        }

        static DataTable ConvertListToDataTable(List<AuxiliarObra> listaAuxObra)
        {
            // New table.
            DataTable table = new DataTable();
            table.Columns.Add("NumeroAux");
            table.Columns.Add("AnioCto");
            table.Columns.Add("CedRuc");
            table.Columns.Add("Contratista");
            table.Columns.Add("ObjetoCto");
            table.Columns.Add("Partida");
            table.Columns.Add("MontoCto");
            table.Columns.Add("FechaCto");
            table.Columns.Add("Plazo");
            table.Columns.Add("CodigoCto");
            for (int i = 0; i < listaAuxObra.Count; i++)
                table.Rows.Add(listaAuxObra[i].NumeroAux,
                               listaAuxObra[i].AnioCto,
                               listaAuxObra[i].CedRuc,
                               listaAuxObra[i].Contratista,
                               listaAuxObra[i].ObjetoCto,
                               listaAuxObra[i].Partida,
                               listaAuxObra[i].MontoCto,
                               listaAuxObra[i].FechaCto,
                               listaAuxObra[i].Plazo,
                               listaAuxObra[i].CodigoCto);

            return table;
        }

    }
}
