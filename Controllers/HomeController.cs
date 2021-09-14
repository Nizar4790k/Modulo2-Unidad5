using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tarea5.Models;

namespace Tarea5.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

           List <Empleado> listaEmpleados = new List<Empleado>();

            return View(listaEmpleados);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Codigo,Nombre,FechaIngreso,SueldoNeto")] Empleado empleado)
        {
           

            return RedirectToAction("Index");
        }


        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Delete()
        {
            return View();
        }

       

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}