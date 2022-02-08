using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Modelo.Operaciones;
using ModeloDB;
using System.Linq;

namespace WebApp.Controllers
{
    public class MatriculasController : Controller
    {
        // DbContext
        private readonly AcademiaDB db;

        public MatriculasController(AcademiaDB db)
        {
            this.db = db;
        }

        // Listado de matrículas
        public IActionResult Index()
        {
            var listaMatriculas = db.matriculas
                .Include(matricula => matricula.Carrera)
                .Include(matricula => matricula.Estudiante)
                .Include(matricula => matricula.Periodo)
                ;

            return View(listaMatriculas);
        }

        // Pantalla para la validación de la matrícula
        public IActionResult Validar(int id)
        {
            var matricula = db.matriculas
                .Include(matricula => matricula.Carrera)
                .Include(matricula => matricula.Estudiante)
                .Include(matricula => matricula.Periodo)
                .Include(matricula => matricula.Matricula_Dets)
                    .ThenInclude(matricula_dets => matricula_dets.Calificacion)
                .Include(matricula => matricula.Matricula_Dets)
                    .ThenInclude(matricula_dets => matricula_dets.Curso)
                        .ThenInclude(curso => curso.Materia)
                .Single(matricula => matricula.MatriculaId == id)   // Consulta la mátricula id
                ;

            // Preparar la clase para el cálculo de las calificaciones
            var configuracion = db.configuracion.Single();
            CalcCalificaciones calcCalificaciones = new CalcCalificaciones(configuracion);

            ViewBag.CalcCalificaciones = calcCalificaciones;

            return View(matricula);
        }

    }
}
