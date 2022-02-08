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
    public class EmpresaController : Controller
    {
        private readonly AcademiaDB db;
        public EmpresaController(AcademiaDB db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Empresa> listaEmpresas = db.empresas.Include(b=>b.Personal).ToList();
            return View(listaEmpresas);
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
        public IActionResult Create(Empresa empleado)
        {
            //Grabar Empleado
            db.empresas.Add(empleado);
            db.SaveChanges();
            TempData["mensaje"] = $"la {empleado.nombreEmpresa}  ha sido sido  creada exitosamente";
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
            Empresa biometrico = db.empresas.Find(id);
            return View(biometrico);
        }
        [HttpPost]
        public IActionResult Edit(Empresa empleado)
        {
            //Grabar Empleado
            db.empresas.Update(empleado);
            db.SaveChanges();

            TempData["mensaje"] = $"La  {empleado.nombreEmpresa} ha sido actualizado exitosamente";
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
            Empresa biometrico = db.empresas.Find(id);
            return View(biometrico);
        }
        //borra empleado
        [HttpPost]
        public IActionResult Delete(Empresa empleado)
        {
            //Grabar Empleado
            db.empresas.Remove(empleado);
            db.SaveChanges();

            TempData["mensaje"] = $"La {empleado.nombreEmpresa} ha sido eliminado exitosamente";
            return RedirectToAction("Index");
        }
    }
}
