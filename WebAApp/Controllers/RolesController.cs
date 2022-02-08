using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Modelo.Entidades;
using ModeloDB;
using System.Collections.Generic;
using System.Linq;

namespace WebAApp.Controllers
{
    public class RolesController : Controller
    {
        private readonly AcademiaDB db;
        public RolesController(AcademiaDB db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Roles> listaLiquidaciones = db.roles.Include(b => b.Personal).ToList();
            return View(listaLiquidaciones);
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
        public IActionResult Create(Roles empleado)
        {
            //Grabar Empleado
            db.roles.Add(empleado);
            db.SaveChanges();
            TempData["mensaje"] = $"El rol de la  {empleado.comision}  ha sido creado exitosamente";
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
           Roles biometrico = db.roles.Find(id);
            return View(biometrico);
        }
        [HttpPost]
        public IActionResult Edit(Roles empleado)
        {
            //Grabar Empleado
            db.roles.Update(empleado);
            db.SaveChanges();

            TempData["mensaje"] = $"El rol de la  {empleado.comision}   ha sido actualizado exitosamente";
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
            Roles biometrico = db.roles.Find(id);
            return View(biometrico);
        }
        //borra empleado
        [HttpPost]
        public IActionResult Delete(Roles empleado)
        {
            //Grabar Empleado
            db.roles.Remove(empleado);
            db.SaveChanges();

            TempData["mensaje"] = $"El rol de la  {empleado.comision}   ha sido eliminado exitosamente";
            return RedirectToAction("Index");
        }
    }
}
