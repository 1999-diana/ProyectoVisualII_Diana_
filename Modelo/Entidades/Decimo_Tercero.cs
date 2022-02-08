using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Entidades
{
    public class Decimo_Tercero
    {
        public int Decimo_TerceroId { get; set; }
        //Relacion con personal 
        public int? PersonalId { get; set; }
        public Personal Personal { get; set; }
        public DateTime fecha_inicio { get; set; }
        public DateTime fecha_final { get; set; }
        public string meses { get; set; }
        public float total { get; set; }
        //RELACION CON SALARIO 
        public int? SalarioID { get; set; }
        public Salario Salario { get; set; }
    }
}
