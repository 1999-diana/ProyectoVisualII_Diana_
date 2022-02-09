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
        public AcademiaDB db { get; set; }

        public ProAprobaciones(AcademiaDB db)
        {
            this.db = db;
        }

        public bool Aprobo(Personal estudiante, Materia materia){

             Salario salario;
            using (var db = new EmpresaContext())
            {
                salario = db.salarios
                    .Include(matr => matr.Empleado)
                    .Single(matr =>
                        matr.Empleado.NombreEmpleado == strEmpleado &&
                        matr.Estado == "Pendiente"
                    );
            }
            return SalarioAprobada(salario.SalarioId);
        }

        // Registro de una salario
        static public Salario CreaSalario(
            EmpresaContext context, string estado,
            string empNombre, string cargoNombre,
            DateTime periodoFechaInicio, string[] empresasNombres)//float sueldobasico,
        {
            // 1.- Consulta del empleado
            Empleado empleado = context.empleados
                .Single(est => est.NombreEmpleado == empNombre);
            
            // 2.- Consulta del tiempo de inicio de trabajo del empleado
            TiempoTrabajoEmpleado tiempo = context.tiempotrabajoempleados
                .Single(tiempo => tiempo.FechaInicioTrabajo == periodoFechaInicio);
            //conculta el cargo
            Cargo cargo= context.cargos
                .Single(tiempo => tiempo.NombreCargo == cargoNombre);
            // 3.- consulta de salarios del empleado
            //Salario salarios = context.salarios
            //   .Single(tiempo => tiempo.SueldoBasico == sueldobasico);

            // 4.- Cabecera del salario
            Salario salario = new Salario()
            {
                Empleado = empleado,
                Estado = estado,
                
                
                //SueldoBasico = sueldobasico
            };
            // 5.- Detalles del salario
            salario.Salario_Dets = new List<Salario_Det>();
            foreach (var empresaNombre in empresasNombres)
            {
                Empresa empresa = context.empresas
                    .Single(cur => cur.RUC == empNombre);
               Salario_Det salario_Det = new Salario_Det()
                {
                    Salario = salario,
                    Empresa = empresa
                };
                salario.Salario_Dets.Add(salario_Det);
            }

            return salario;
 
        }

        public bool Aprobado(string strEmpleado, float decimotercer, float decimocuarto, float utilidades)
        {
            throw new NotImplementedException();
        }

        public bool Aprobado(string strEmpleado, float decimotercer, float decimocuarto)
        {
            throw new NotImplementedException();
        }

        // Registrar el salario de un empleado
        static public void RegistrarSalarios(
            Salario salario, Dictionary<string, Salario> dicSalarioEmpleado)
        {
            // Buscar la empresa para asignar los salarios
            foreach (var det in salario.Salario_Dets)
            {
                det.Salario = dicSalarioEmpleado[det.Salario.Estado];
            }
        }
        public static bool SalarioAprobada(int salarioID)
        {
            bool aprobada = true;
            using (var db = new EmpresaContext())
            {
                // Consulta a la configuración
                var configuracion = db.configuraciones.Single();
                // Consulta de las matrículas pendientes
                var matricula = db.salarios
                    .Include(matr => matr.Empleado)
                    .Include(matr => matr.Salario_Dets)
                        .ThenInclude(det => det.Empresa)
                            .ThenInclude(cur => cur.Cargo)
                                        .ThenInclude(pre => pre.CargoId)
                    .Single(salario => salario.SalarioId == salarioID && salario.Estado == "Pendiente");

                //// Revisa los prerequisitos
                //foreach (var det in matricula.Matricula_Dets)
                //{
                //    var materia = det.Curso.Materia;
                //    // Si la materia no tiene malla, entonces OK
                //    if (materia.Malla is null) continue;
                //    // Si la lista de prerequisitos está vacia entonces OK.
                //    if (materia.Malla.PreRequisitos.Count == 0) continue;
                //    // Verificación de prerequisitos
                //    foreach (var prerequisito in materia.Malla.PreRequisitos)
                //    {
                //        var materiaPreReq = prerequisito.Materia;
                //        // El estudiante habrá aprobado la materiaPreReq?
                //        if (!MateriaAprobada(matricula.Estudiante, materiaPreReq, configuracion))
                //        {
                //            aprobada = false;
                //        }
                //    }
                //}
            }
            return aprobada;
        }

        public static bool SalarioAprobada(Empleado empleado, Cargo cargo, Configuracion configuracion)
        {
            bool aprobada = false;
            float horasmax = configuracion.HorasExtrasMaximas;
            float horasmin = configuracion.HorasExtrasMinimas;
            float salHoras = configuracion.SalrioHorasExtras;
            float salMax = configuracion.SalarioMaximo;
            // Consultar las matrículas del estudiante en estado Aprobadas
            using (var db = new EmpresaContext())
            {
                var listaSalarios = db.salarios
                    .Include(matr => matr.Salario_Dets)
                    .Include(matr => matr.Salario_Dets.Where(det => det.Empresa.EmpresaId == cargo.CargoId))
                        .ThenInclude(det => det.Empresa)
                            .ThenInclude(cur => cur.Cargo)
                    .Where(matr =>
                        matr.EmpleadoId == empleado.EmpleadoId &&
                        matr.Estado == "Aprobada"
                    )
                    .ToList();
                //foreach (var salario in listaSalarios)
                //{
                //    foreach (var det in salario.Salario_Dets)
                //    {
                //        var materiaPreReq = det.Empresa.Cargo;
                //        if (det.Salario.Aprueba(peso1, peso2, peso3, notaMin)) aprobada = true;
                //    }
                //}
            }
            return aprobada;
        }
        //float sueldobasico, SalarioMinima;
        public bool Aprobado(string strEmpleado, Salario salari, float sueldobasico, float SalarioMinima)
        {
            return salari.Apruebaaldecimo(sueldobasico, SalarioMinima);
        }

    }
}
