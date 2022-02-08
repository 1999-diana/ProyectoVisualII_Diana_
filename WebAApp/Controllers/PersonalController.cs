using Microsoft.AspNetCore.Mvc;
using Modelo.Entidades;
using ModeloDB;
using System.Collections.Generic;

namespace WebAApp.Controllers
{
    public class PersonalController : Controller
    {
        private readonly AcademiaDB db;
        public PersonalController(AcademiaDB db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Personal> listaEmpleados = db.personales;
            return View(listaEmpleados);
        }
        //creación empleado
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Personal empleado)
        {
            //Grabar Empleado
            db.personales.Add(empleado);
            db.SaveChanges();
            TempData["mensaje"] = $"El empleado {empleado.Nombre} ha sido creado exitosamente";
            return RedirectToAction("Index");
        }


        //edicion empleado
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Personal empleado = db.personales.Find(id);
            return View(empleado);
        }
        [HttpPost]
        public IActionResult Edit(Personal empleado)
        {
            //Grabar Empleado
            db.personales.Update(empleado);
            db.SaveChanges();

            TempData["mensaje"] = $"El empleado {empleado.Nombre} ha sido actualizado exitosamente";
            return RedirectToAction("Index");
        }

        //borrar empleado
        // presenta formulario datos empelado
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Personal empleado = db.personales.Find(id);
            return View(empleado);
        }
        //borra empleado
        [HttpPost]
        public IActionResult Delete(Personal empleado)
        {
            //Grabar Empleado
            db.personales.Remove(empleado);
            db.SaveChanges();

            TempData["mensaje"] = $"El empleado {empleado.Nombre} ha sido eliminado exitosamente";
            return RedirectToAction("Index");
        }
    }
}
