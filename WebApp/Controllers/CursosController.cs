using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Modelo.Entidades;
using ModeloDB;
using System.Collections.Generic;
using System.Linq;

namespace WebApp.Controllers
{
    public class CursosController : Controller
    {
        readonly AcademiaDB db;

        public CursosController(AcademiaDB db)
        {
            this.db = db;
        }

        // Obtiene la lista de cursos y lo envía a la vista
        public IActionResult Index()
        {
            IEnumerable<Curso> listaCursos = 
                db.cursos
                    .Include(curso => curso.Carrera)
                    .Include(curso => curso.Materia)
                    .Include(curso => curso.Periodo);

            return View(listaCursos);
        }

        //  Presenta el formulario vacio listo para crear una entidad
        [HttpGet]
        public IActionResult Create()
        {
            // Lista de carreras
            var listaCarreras = db.carreras
                .Select(carrera => new
                {
                    CarreraId = carrera.CarreraId,
                    Nombre = carrera.Nombre
                }).ToList();
            // Lista de materias
            var listaMaterias = db.materias
                .Select(materias => new
                {
                    MateriaId = materias.MateriaId,
                    Nombre = materias.Nombre
                }).ToList();
            // Lista de períodos
            var listaPeriodos= db.periodos
                .Select(periodo => new
                {
                    PeriodoId = periodo.PeriodoId,
                    Nombre = periodo.Nombre,
                    Anio = periodo.Anio
                }).ToList();

            // Prepara las listas
            var selectListaCarreras = new SelectList(listaCarreras, "CarreraId", "Nombre");
            var selectListaPeriodos = new SelectList(listaPeriodos, "PeriodoId", "Nombre", null, "Anio");
            var selectListaMaterias = new SelectList(listaMaterias, "MateriaId", "Nombre");

            // Ingreso a ViewBag
            ViewBag.selectListCarreras = selectListaCarreras;
            ViewBag.selectListPeriodos = selectListaPeriodos;
            ViewBag.selectListMaterias = selectListaMaterias;

            return View();
        }

        //  Guarda un curso
        [HttpPost]
        public IActionResult Create(Curso curso)
        {
            db.cursos.Add(curso);
            db.SaveChanges();

            TempData["mensaje"] = $"El curso {curso.Nombre} se ha creado correctamente";

            return RedirectToAction("Index");
        }
    }
}
