using Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Operaciones
{
    public class CalcCalificaciones
    {
        public float peso1 { get; set; }
        public float peso2 { get; set; }
        public float peso3 { get; set; }
        public float notaMinima { get; set; }

        public CalcCalificaciones(Configuracion configuracion)
        {
            this.peso1 = configuracion.Salario_Horas_Extras;
            this.peso2 = configuracion.Horas_Extras_Minima;
            this.peso3 = configuracion.Horas_Extras_Maxima;
            this.notaMinima = configuracion.sueldoMaximo;
        }

        public float NotaFinal(Salario calificacion)
        {
            float respuesta;

            respuesta =
                calificacion.DecimoTercerSueldo * peso1 +
                calificacion.DecimoCuartoSueldo * peso2 +
                calificacion.Utilidades * peso3;

            respuesta = (float) Math.Round((double) respuesta, 2);

            return respuesta;
        }

        public bool Aprobado(Salario calificacion)
        {
            return NotaFinal(calificacion) >= notaMinima;
        }
    }
}
