using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using model.DEL;
using model.BEL;
using Website.Utils;

//AuxiliarWeb
namespace webAuxiliar.Controllers
{
    public class AuxObraController : Controller
    {
        //inicializar
        private AuxObraBEL objAuxObraBEL;

        public AuxObraController()
        {
            objAuxObraBEL = new AuxObraBEL();
        }

        // GET: AuxObra
        public ActionResult Inicio()
        {
            List<AuxiliarObra> listaAuxObra = objAuxObraBEL.findAll();
            return View(listaAuxObra);
            //return null;
        }

        [HttpGet]
        public ActionResult findAuxObraNro(string txtAuxNro)
        {

            if (txtAuxNro == "")
            {
                txtAuxNro = "-1";
            }

            AuxiliarObra objAuxObraNro = new AuxiliarObra();
            objAuxObraNro.NumeroAux = txtAuxNro;
            List<AuxiliarObra> AuxiliarObra = objAuxObraBEL.findAuxObraNro(objAuxObraNro);
            return View(AuxiliarObra);
        }

        [HttpGet]
        public ActionResult findAuxObraDate(string txtfechaDesde, string txtFechaHasta)
        {
            //AuxiliarObra objAuxObraDate = new AuxiliarObra();
            List<AuxiliarObra> listaAuxObraDate = objAuxObraBEL.findAuxObraDate(txtfechaDesde, txtFechaHasta);

            Utils.GlobalVarAux.fechaDesde = txtfechaDesde;
            Utils.GlobalVarAux.fechaHasta = txtFechaHasta;

            return View(listaAuxObraDate);

            //return null;
        }


        [HttpGet]
        public JsonResult getAuxObra(string sidx, string sord, int page, int rows, bool _search,
                                     string searchField, string searchOper, string searchString,
                                     string beginDate, string endDate)
        {

            List<AuxiliarObra> listaAuxObra;

            if (beginDate == "" || endDate == "")
            {

                listaAuxObra = objAuxObraBEL.findAll();
            }
            else
            {
                listaAuxObra = objAuxObraBEL.findAuxObraDate(beginDate, endDate);
            }

            sord = (sord == null) ? "" : sord;
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;

            if (_search)
            {
                switch (searchField)
                {
                    case "by_numeroAux":
                        listaAuxObra = listaAuxObra.Where(t => t.NumeroAux.Contains(searchString)).ToList();
                        break;
                    case "by_contratista":
                        listaAuxObra = listaAuxObra.Where(t => t.Contratista.ToUpper().Contains(searchString.ToUpper())).ToList();
                        break;
                    case "by_objetoCto":
                        listaAuxObra = listaAuxObra.Where(t => t.ObjetoCto.Contains(searchString.ToUpper())).ToList();
                        break;
                }
            }

            int totalRecords = listaAuxObra.Count();
            var totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);

            if (sord.ToUpper() == "DESC")
            {
                listaAuxObra = listaAuxObra.OrderByDescending(x => x.NumeroAux).ToList();
                listaAuxObra = listaAuxObra.Skip(pageIndex * pageSize).Take(pageSize).ToList();
            }
            else
            {
                listaAuxObra = listaAuxObra.OrderBy(x => x.NumeroAux).ToList();
                listaAuxObra = listaAuxObra.Skip(pageIndex * pageSize).Take(pageSize).ToList();
            }
            var jsonData = new
            {
                total = totalPages,
                page,
                records = totalRecords,
                rows = listaAuxObra
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult getAuxObraDet(string sidx, string sord, int page, int rows, bool _search,
                                        string searchField, string searchOper, string searchString, string auxObraID)
        {
            AuxiliarObraDet objAuxObraNroDet = new AuxiliarObraDet();
            objAuxObraNroDet.NumeroAux = auxObraID;
            List<AuxiliarObraDet> listaAuxObraDet;
            listaAuxObraDet = objAuxObraBEL.findAuxObraNroDet(objAuxObraNroDet);

            sord = (sord == null) ? "" : sord;
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;


            int totalRecords = listaAuxObraDet.Count();
            var totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);
            var jsonData = new
            {
                total = totalPages,
                page,
                records = totalRecords,
                rows = listaAuxObraDet
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }


        // EXPORT TO EXCEL: INICIO
        [HttpGet]
        [ExportResultToExcel(exportedFileName: "AuxiliarObra.xlsx", tempDataKey: "AuxData")]
        public ActionResult ExportToExcelDate()
        {
            using (GridView grid = new GridView())
            {
                //grid.DataSource = from p in objAuxObraBEL.findAll()
                grid.DataSource = from p in objAuxObraBEL.findAuxObraDate(Utils.GlobalVarAux.fechaDesde, Utils.GlobalVarAux.fechaHasta)
                                  select new
                                  {
                                      Periodo = p.AnioCto,
                                      AuxNro = p.NumeroAux,
                                      Contratista = p.Contratista,
                                      CedRuc = p.CedRuc,
                                      Codigo = p.CodigoCto,
                                      Objeto = p.ObjetoCto,
                                      Fecha = p.FechaCto,
                                      Monto = p.MontoCto,
                                      Partida = p.Partida,
                                      Plazo = p.Plazo
                                  };
                grid.DataBind();
                TempData["AuxData"] = grid;
                
            }
            return View("findAuxObraDate");
        }
        // EXPORT TO EXCEL: FIN



        // ADD: AuxObra

        public ActionResult Create()
        {
            return View();
        }


        // DEL: AuxObra

        // UPD: AuxObra




    }
}