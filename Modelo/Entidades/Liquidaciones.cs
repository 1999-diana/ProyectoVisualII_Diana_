using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Entidades
{
    public class Liquidaciones
    {
        public enum estado { Liquidacion, Liquidado }
        public int LiquidacionesId { get; set; }
        //Relacion uno a uno con Personal
        public int? PersonalId { get; set; }
        public Personal Personal { get; set; }
        public string cesantia { get; set; }
        public string periodo_pri { get; set; }
        public string salario_base { get; set; }
        public estado Estadoliq { get; set; }

    }
}
