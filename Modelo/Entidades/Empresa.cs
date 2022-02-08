using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Entidades
{
    public class Empresa
    {
        public int EmpresaId { get; set; }
        //Relacion uno a uno con Personal
        public int? PersonalId { get; set; }
        public Personal Personal { get; set; }
        public string ruc { get; set; }
        public string nombreEmpresa { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string provincia { get; set; }
    }
}
