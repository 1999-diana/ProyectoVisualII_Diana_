using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Entidades
{
    public class Roles
    {
        public int RolesId { get; set; }
        //Relacion con personal 
        public int? PersonalId { get; set; }
        public Personal Personal { get; set; }
        public float comision { get; set; }
        public float aporte_iess { get; set; }
        public float anticipo { get; set; }
        public float total { get; set; }
        //RELACION CON SALARIO 
        public int? SalarioID { get; set; }
        public Salario Salario { get; set; }
    }
}
