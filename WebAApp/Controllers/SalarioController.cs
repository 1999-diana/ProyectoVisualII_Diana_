using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Modelo.Operaciones;
using ModeloDB;
using System.Linq;

namespace WebAApp.Controllers
{
    public class SalarioController : Controller
    {  // DbContext
        private readonly AcademiaDB db;

        public SalarioController(AcademiaDB db)
        {
            this.db = db;
        }

        // Listado de matrículas
        public IActionResult Index()
        {
            var listaMatriculas = db.salarios
                .Include(matricula => matricula.decterceros)
                .Include(matricula => matricula.Personal)
                .Include(matricula => matricula.roles)
              
                ;

            return View(listaMatriculas);
        }

        // Pantalla para la validación de la matrícula
        public IActionResult Validar(int id)
        {
            var matricula = db.salarios
                .Include(matricula => matricula.decterceros)
                .Include(matricula => matricula.Personal)
                .Include(matricula => matricula.roles)
               
                .Single(matricula => matricula.SalarioId == id)   // Consulta la mátricula id
                ;

            // Preparar la clase para el cálculo de las calificaciones
            var configuracion = db.configuracion.Single();
            CalcCalificaciones calcCalificaciones = new CalcCalificaciones(configuracion);

            ViewBag.CalcCalificaciones = calcCalificaciones;

            return View(matricula);
        }
    }
}
