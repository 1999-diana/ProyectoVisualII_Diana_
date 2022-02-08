using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modelo.Entidades;
using ModeloDB;
using System.Collections.Generic;

namespace WebAApp.Controllers
{
    public class ConfiguracionController : Controller
    {
        private readonly AcademiaDB db;
        public ConfiguracionController(AcademiaDB db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Configuracion> listaEmpleados = db.configuracion;
            return View(listaEmpleados);
        }
      
    }
}
