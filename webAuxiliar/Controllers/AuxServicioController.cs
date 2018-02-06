using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using model.DEL;
using model.BEL;
using Website.Utils;

namespace webAuxiliar.Controllers
{
    public class AuxServicioController : Controller
    {
        //inicializar
        private AuxServicioBEL objAuxServicioBEL;
        public AuxServicioController()
        {
            objAuxServicioBEL = new AuxServicioBEL();
        }
            

        // GET: AuxServicio
        public ActionResult Inicio()
        {
            List<AuxiliarServicio> listaAuxServicio = objAuxServicioBEL.findAll();
            return View(listaAuxServicio);
        }

        public ActionResult findAuxServDate(string txtfechaDesde, string txtFechaHasta)
        {
            AuxiliarServicio objAuxServDate = new AuxiliarServicio();
            List<AuxiliarServicio> listaAuxServDate = objAuxServicioBEL.findAuxServDate(txtfechaDesde, txtFechaHasta); 
            return View(listaAuxServDate);
        }

        public JsonResult getAuxServicio(string sidx, string sord, int page, int rows, bool _search,
                                         string searchField, string searchOper, string searchString,
                                         string beginDate, string endDate)
        {

            List<AuxiliarServicio> listaAuxServicio;

            if (beginDate == "" || endDate == "")
            {

                listaAuxServicio = objAuxServicioBEL.findAll();
            }
            else
            {
                listaAuxServicio = objAuxServicioBEL.findAuxServDate(beginDate, endDate);
            }

            sord = (sord == null) ? "" : sord;
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;

            if (_search)
            {
                switch (searchField)
                {
                    case "by_numeroAux":
                        listaAuxServicio = listaAuxServicio.Where(t => t.NumeroAux.Contains(searchString)).ToList();
                        break;
                    case "by_contratista":
                        listaAuxServicio = listaAuxServicio.Where(t => t.Contratista.ToUpper().Contains(searchString.ToUpper())).ToList();
                        break;
                    case "by_objetoCto":
                        listaAuxServicio = listaAuxServicio.Where(t => t.ObjetoCto.Contains(searchString.ToUpper())).ToList();
                        break;
                }
            }

            int totalRecords = listaAuxServicio.Count();
            var totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);

            if (sord.ToUpper() == "DESC")
            {
                listaAuxServicio = listaAuxServicio.OrderByDescending(x => x.NumeroAux).ToList();
                listaAuxServicio = listaAuxServicio.Skip(pageIndex * pageSize).Take(pageSize).ToList();
            }
            else
            {
                listaAuxServicio = listaAuxServicio.OrderBy(x => x.NumeroAux).ToList();
                listaAuxServicio = listaAuxServicio.Skip(pageIndex * pageSize).Take(pageSize).ToList();
            }
            var jsonData = new
            {
                total = totalPages,
                page,
                records = totalRecords,
                rows = listaAuxServicio
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        public JsonResult getAuxServicioDet(string sidx, string sord, int page, int rows, string auxServicioID)
        {
            AuxiliarServicioDet objAuxServiNroDet = new AuxiliarServicioDet();
            objAuxServiNroDet.NumeroAux = auxServicioID;
            List<AuxiliarServicioDet> listaAuxServicioDet;
            listaAuxServicioDet = objAuxServicioBEL.findAuxServNroDet(objAuxServiNroDet);

            sord = (sord == null) ? "" : sord;
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;

            int totalRecords = listaAuxServicioDet.Count();
            var totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);

            var jsonData = new
            {
                total = totalPages,
                page,
                records = totalRecords,
                rows = listaAuxServicioDet
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        // EXPORT TO EXCEL: INICIO
        [HttpGet]
        [ExportResultToExcel(exportedFileName: "AuxiliarServ.xlsx", tempDataKey: "AuxData")]
        public ActionResult ExportToExcelDate()
        {
            using (GridView grid = new GridView())
            {
                //grid.DataSource = from p in objAuxObraBEL.findAll()
                grid.DataSource = from p in objAuxServicioBEL.findAuxServDate(Utils.GlobalVarAux.fechaDesde, Utils.GlobalVarAux.fechaHasta)
                                  select new
                                  {
                                      Periodo = p.AnioCto,
                                      AuxNro = p.NumeroAux,
                                      Contratista = p.Contratista,
                                      CedRuc = p.CedRuc,
                                      Objeto = p.ObjetoCto,
                                      Fecha = p.FechaCto,
                                      Monto = p.MontoCto,
                                      Partida = p.Partida,
                                      Plazo = p.Plazo,
                                      FormaPago = p.FormaPago  
                                  };
                grid.DataBind();
                TempData["AuxData"] = grid;

            }
            return View("findAuxServDate");
        }
        // EXPORT TO EXCEL: FIN

    }
}