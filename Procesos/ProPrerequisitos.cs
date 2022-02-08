
using Microsoft.EntityFrameworkCore;
using Modelo.Entidades;
using ModeloDB;
using System.Collections.Generic;
using System.Linq;

namespace Procesos
{
    public class ProPrerequisitos
    {
        //readonly AcademiaDB db;

       /* public ProPrerequisitos(AcademiaDB db)
        {
            this.db = db;
        }

        public List<Materia> Prerequisitos(Materia materia) 
        {
            var prerequisitos = new List<Materia>();

            // Consultar la materia
            var tmpMateria = db.materias
                .Include(mat => mat.Malla)
                .Single(mat => mat.MateriaId == materia.MateriaId );

            // Si no tiene malla, entonces no tiene prerequisitos
            if (tmpMateria.Malla == null) return null;

            // Consultar los prerequisitos
            var tmpPreReq = db.prerequisitos
                .Include(pre => pre.Materia)
                .Where(pre => pre.MallaId == tmpMateria.Malla.MallaId);

            // Si no tiene prerequisitos, retorna null
            if (tmpPreReq == null) return null;

            // Preparo la lista de materias
            foreach(var pre in tmpPreReq)
            {
                // Llamada recursiva
                var sublistaMaterias = Prerequisitos(pre.Materia);
                if (sublistaMaterias == null) // nodo leap
                {
                    prerequisitos.Add(pre.Materia);
                }
                else
                {
                    prerequisitos.Add(pre.Materia);
                    foreach (var subMateria in sublistaMaterias)
                    {
                        prerequisitos.Add(subMateria);
                    }
                }
            }                
            return prerequisitos;
        }*/
    }
}
