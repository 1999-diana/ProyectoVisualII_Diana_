using Microsoft.EntityFrameworkCore;
using Modelo.Entidades;
using Modelo.Operaciones;
using ModeloDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procesos
{
    public class ProAprobaciones
    {
        /*public AcademiaDB db { get; set; }

        public ProAprobaciones(AcademiaDB db)
        {
            this.db = db;
        }

        public bool Aprobo(Personal estudiante, Materia materia)
        {
            // Consultar el Estudiante, matrículas, detalles, calificaciones, cursos y materias
            var tmpEstudiante = db.estudiantes
                .Include(est => est.Matriculas)
                    .ThenInclude(matr => matr.Matricula_Dets)
                        .ThenInclude(dets => dets.Calificacion)
                .Include(est => est.Matriculas)
                    .ThenInclude(matr => matr.Matricula_Dets)
                        .ThenInclude(dets => dets.Curso)
                            .ThenInclude(curso => curso.Materia)
                .Single(est => est.EstudianteId == estudiante.EstudianteId);

            // Si no tiene matrículas, no aprobó la materia
            if (tmpEstudiante.Matriculas == null) return false;

            // Preparar clase para el cálc de las calificaciones
            var configuracion = db.configuracion.Single();
            var calc = new CalcCalificaciones(configuracion);

            // Busco la materia
            foreach (var matr in tmpEstudiante.Matriculas)
            {
                foreach(var det in matr.Matricula_Dets)
                {
                    if(det.Curso.Materia.MateriaId == materia.MateriaId)
                    {
                        // Si no tiene calificaciones entonces no aprobó la materia
                        if (det.Calificacion == null) return false;

                        if( calc.Aprobado(det.Calificacion))
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }*/

    }
}
