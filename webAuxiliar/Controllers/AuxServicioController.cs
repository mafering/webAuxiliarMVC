using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using model.BEL;
using model.DEL;

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
                        listaAuxServicio = listaAuxServicio.Where(t => t.Contratista.ToUpper().Contains(searchString)).ToList();
                        break;
                    case "by_objetoCto":
                        listaAuxServicio = listaAuxServicio.Where(t => t.ObjetoCto.Contains(searchString)).ToList();
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

    }
}