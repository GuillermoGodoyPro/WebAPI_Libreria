using ADO_MVC_NetFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ADO_MVC_NetFramework.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            AdmArticulo objAdm = new AdmArticulo();
            return View(objAdm.TraerTodos());
        }
        public ActionResult Alta()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Alta(FormCollection coleccion)
        {
            AdmArticulo objAdm = new AdmArticulo();
            Articulo articulo = new Articulo
            {
                Codigo = int.Parse(coleccion["codigo"]),
                Descripcion = coleccion["descripcion"],
                Precio = float.Parse(coleccion["precio"].ToString())
            };
            objAdm.Alta(articulo);
            return RedirectToAction("Index");
        }

        public ActionResult Baja(int pCodigo)
        {
            AdmArticulo objAdm = new AdmArticulo();
            objAdm.Borrar(pCodigo);

            return RedirectToAction("Index");
        }
        /*[HttpPost]
        public ActionResult Baja(int pCodigo, FormCollection coleccion)
        {
            return RedirectToAction("Index");
        }
        */

        public ActionResult Modificacion(int pCodigo)
        {
            AdmArticulo objAdm = new AdmArticulo();
            Articulo articulo = objAdm.TraerArticulo(pCodigo);

            return View(articulo);
        }

        [HttpPost]
        public ActionResult Modificacion(FormCollection coleccion)
        {
            AdmArticulo objAdm = new AdmArticulo();
            Articulo articulo = new Articulo
            {
                Codigo = int.Parse(coleccion["codigo"]),
                Descripcion = coleccion["descripcion"],
                Precio = float.Parse(coleccion["precio"].ToString())
            };
            objAdm.ModificarArticulo(articulo);
            return RedirectToAction("Index");
        }



    }
}