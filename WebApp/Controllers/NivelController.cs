using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Modelo.Entidades;
using ModeloDB;
using System.Collections.Generic;

namespace WebApp.Controllers
{
    public class NivelController : Controller
    {
        public AcademiaDB db { get; set; }

        public NivelController(AcademiaDB db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Nivel> listaNiveles = db.niveles.
                Include(nivel => nivel.Materia);

            return View(listaNiveles);
        }
    }
}
