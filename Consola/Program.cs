using Procesos;
using System;
using System.Linq;

namespace Consola
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Grabar grabar = new Grabar();
            grabar.DatosIni();
            using (var db = AcademiaDBBuilder.Crear())
            {
                var tmpEstudiante = db.personales
                         .Single(estudiante => estudiante.Nombre == "Pedro Navaja");

                Console.WriteLine(
                            "El estudiante " + tmpEstudiante.Nombre);
            }
                /* using(var db = AcademiaDBBuilder.Crear())
                 {
                     var tmpMateria = db.materias
                         .Where(materia => 
                         materia.Nombre == "E-Learning" ||                       // NO
                         materia.Nombre == "Lógica de Programación" ||           // SI
                         materia.Nombre == "Diseño Web" ||                       // NO
                         materia.Nombre == "Administración de Bases de Datos" || // SI
                         materia.Nombre == "Video Marketing"                     // NO
                     );

                     var tmpEstudiante = db.estudiantes
                         .Single(estudiante => estudiante.Nombre== "Pedro Navaja");

                     ProAprobaciones proaprobaciones = new ProAprobaciones(db);

                     foreach(var mat in tmpMateria)
                     {
                         var resultado = proaprobaciones.Aprobo(tmpEstudiante, mat);

                         Console.WriteLine(
                             "El estudiante " + tmpEstudiante.Nombre +
                             (resultado ? " SI " : " NO ") +
                             " aprobó la materia de: " + mat.Nombre
                         );
                     }                
                 }*/
            }
    }
}
