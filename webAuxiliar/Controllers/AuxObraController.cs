using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using model.DEL;
using model.BEL;

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

        //[HttpPost]
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

        public ActionResult findAuxObraDate(string txtfechaDesde, string txtFechaHasta)
        {
            AuxiliarObra objAuxObraDate = new AuxiliarObra();

            List<AuxiliarObra> listaAuxObraDate = objAuxObraBEL.findAuxObraDate(txtfechaDesde, txtFechaHasta);
            return View(listaAuxObraDate);

            //return null;
        }

        //[HttpPost]
        //ActionResult
        public JsonResult getAuxObra(string sidx, string sord, int page, int rows, bool _search,
                                     string searchField, string searchOper, string searchString, 
                                     string beginDate, string endDate)
        {

            List<AuxiliarObra> listaAuxObra;

            if (beginDate == "" || endDate == "" )
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

    }
}