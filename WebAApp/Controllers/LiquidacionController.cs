using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Modelo.Entidades;
using ModeloDB;
using System.Collections.Generic;
using System.Linq;

namespace WebAApp.Controllers
{
    public class LiquidacionController : Controller
    {
        private readonly AcademiaDB db;
        public LiquidacionController(AcademiaDB db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Liquidaciones> listaLiquidaciones = db.liquidaciones.Include(b => b.Personal).ToList();
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
        public IActionResult Create(Liquidaciones empleado)
        {
            //Grabar Empleado
            db.liquidaciones.Add(empleado);
            db.SaveChanges();
            TempData["mensaje"] = $"La liquidacion del  {empleado.salario_base}  ha sido creado exitosamente";
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
            Liquidaciones biometrico = db.liquidaciones.Find(id);
            return View(biometrico);
        }
        [HttpPost]
        public IActionResult Edit(Liquidaciones empleado)
        {
            //Grabar Empleado
            db.liquidaciones.Update(empleado);
            db.SaveChanges();

            TempData["mensaje"] = $"La liquidacion del  {empleado.salario_base}  ha sido actualizado exitosamente";
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
            Liquidaciones biometrico = db.liquidaciones.Find(id);
            return View(biometrico);
        }
        //borra empleado
        [HttpPost]
        public IActionResult Delete(Liquidaciones empleado)
        {
            //Grabar Empleado
            db.liquidaciones.Remove(empleado);
            db.SaveChanges();

            TempData["mensaje"] = $"La liquidacion del  {empleado.salario_base}  ha sido eliminado exitosamente";
            return RedirectToAction("Index");
        }
    }
}
