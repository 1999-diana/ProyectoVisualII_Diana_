using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Modelo.Entidades;
using ModeloDB;
using System.Collections.Generic;
using System.Linq;

namespace WebAApp.Controllers
{
    public class DecimoController : Controller
    {
        private readonly AcademiaDB db;
        public DecimoController(AcademiaDB db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Decimo_Tercero> listaDecimos = db.decimo_Terceros.Include(b => b.Personal).ToList();
            return View(listaDecimos);
        }
        //creación empleado
        [HttpGet]
        public IActionResult Create()
        {
            //lista empleados
            var listaEmpleados = db.personales
                .Select(empleado => new
                {
                    PersonalId = empleado.PersonalId,
                    Nombre = empleado.Nombre
                }).ToList();
            //preparar listas
            var selectListaEmpleados = new SelectList(listaEmpleados, "PersonalId", "Nombre");

            //Ingreso Viebag
            ViewBag.selectListEmpleados = selectListaEmpleados;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Decimo_Tercero empleado)
        {
            //Grabar Empleado
            db.decimo_Terceros.Add(empleado);
            db.SaveChanges();
            TempData["mensaje"] = $"El decimo de la  {empleado.fecha_inicio} creado exitosamente";
            return RedirectToAction("Index");
        }


        //edicion empleado
        [HttpGet]
        public IActionResult Edit(int id)
        {
            //lista empleados
            var listaEmpleados = db.personales
                .Select(empleado => new
                {
                    PersonalId = empleado.PersonalId,
                    Nombre = empleado.Nombre
                }).ToList();
            //preparar listas
            var selectListaEmpleados = new SelectList(listaEmpleados, "PersonalId", "Nombre");

            //Ingreso Viebag
            ViewBag.selectListEmpleados = selectListaEmpleados;
            Decimo_Tercero biometrico = db.decimo_Terceros.Find(id);
            return View(biometrico);
        }
        [HttpPost]
        public IActionResult Edit(Decimo_Tercero empleado)
        {
            //Grabar Empleado
            db.decimo_Terceros.Update(empleado);
            db.SaveChanges();

            TempData["mensaje"] = $"El decimo de la  {empleado.fecha_inicio}  ha sido actualizado exitosamente";
            return RedirectToAction("Index");
        }

        //borrar empleado
        // presenta formulario datos empelado
        [HttpGet]
        public IActionResult Delete(int id)
        {
            //lista empleados
            var listaEmpleados = db.personales
                .Select(empleado => new
                {
                    PersonalId = empleado.PersonalId,
                    Nombre = empleado.Nombre
                }).ToList();
            //preparar listas
            var selectListaEmpleados = new SelectList(listaEmpleados, "PersonalId", "Nombre");

            //Ingreso Viebag
            ViewBag.selectListEmpleados = selectListaEmpleados;
            Decimo_Tercero biometrico = db.decimo_Terceros.Find(id);
            return View(biometrico);
        }
        //borra empleado
        [HttpPost]
        public IActionResult Delete(Decimo_Tercero empleado)
        {
            //Grabar Empleado
            db.decimo_Terceros.Remove(empleado);
            db.SaveChanges();

            TempData["mensaje"] = $"El decimo de la  {empleado.fecha_inicio}  ha sido eliminado exitosamente";
            return RedirectToAction("Index");
        }
    }
}
