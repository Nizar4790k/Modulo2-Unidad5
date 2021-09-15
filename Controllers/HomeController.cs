using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Tarea5.Models;

namespace Tarea5.Controllers
{
    public class HomeController : Controller
    {

        private static List<Empleado> listaEmpleados;
        private static int codigo=1;

        public ActionResult Index()
        {

            if (Session["listaEmpleados"] != null)
            {
                listaEmpleados = Session["listaEmpleados"] as List<Empleado>;
            }
            else
            {
                listaEmpleados = new List<Empleado>();
                Session["listaEmpleados"] = listaEmpleados;
                
            }


            return View(listaEmpleados);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Codigo,Nombre,FechaIngreso,SueldoNeto")] Empleado empleado)
        {

            

            if (ModelState.IsValid)
            {
                empleado.Codigo = codigo;
                codigo++;
                listaEmpleados = Session["listaEmpleados"] as List<Empleado>;
                listaEmpleados.Add(empleado);
                Session["listaEmpleados"] = listaEmpleados;
                return RedirectToAction("Index");
            }

            return View(empleado);

            
        }


        // GET: Home/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }

          
                var empleado = HomeController.listaEmpleados.Where(emp => emp.Codigo == id).First();

                if (empleado == null)
                {
                    return HttpNotFound();
                }
                return View(empleado);
            
            
            return View(empleado);
        }

        public ActionResult Create()
        {
            return View();
        }

       


        // GET: Cita/Edit/5
        public ActionResult Edit(int ?id) {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }


            var empleado = HomeController.listaEmpleados.Where(emp => emp.Codigo == id).First();

            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);


           


        }

        // POST Empleado/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Codigo,Nombre,FechaIngreso,SueldoNeto")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {

                var empleadosConsultados = HomeController.listaEmpleados.Where(emp => emp.Codigo == empleado.Codigo);
                 
                foreach(Empleado emp in empleadosConsultados)
                {
                    emp.Nombre = empleado.Nombre;
                    emp.SueldoNeto = empleado.SueldoNeto;
                    emp.FechaIngreso = empleado.FechaIngreso;
                }

                return RedirectToAction("Index");
            }

            return View(empleado);
        }


        // GET: Empleado/Edit/5
        public ActionResult Delete(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }


            var empleado = HomeController.listaEmpleados.Where(emp => emp.Codigo == id).First();
            

            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);



        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            HomeController.listaEmpleados.RemoveAll(empleado => empleado.Codigo == id);


           return RedirectToAction("Index");
          
           
        }


    }
}