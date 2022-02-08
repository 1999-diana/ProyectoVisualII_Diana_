using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Entidades
{
    public class Personal
    {
        // Atributos
        public enum EstadoCivil { Soltero, Casado, Divorciado, Viudo}
        public enum TipoContrato { Completo, Indefinido, Prueba, Proyecto}
        public int PersonalId { get; set; }
        public string Nombre { get; set; }
        public string Cedula { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public EstadoCivil EstadoCV { get; set; }
        public float salario { get; set; }
        public TipoContrato tipo { get; set; }
        public DateTime fecha_incio { get; set; }
        public DateTime fecha_salida { get; set; }

        //RELACION UNO A UNO CON LIQUIDACIONES
        public Liquidaciones liquidacion { get; set; }

        //RELACION UNO A UNO CON EMPRESA
        public Empresa empresa { get; set; }

        //RELACION UNO A MUCHOS DE DECIMO TERCERO 
        public List<Decimo_Tercero> Decimos_Terceros { get; set; }

        //RELACION UNO A MUCHOS DE ROLES
        public List<Roles> Roles { get; set; }

        //RELACION UNO A MUCHOS DE SALARIO
        public List<Salario> Salarios { get; set; }


    }
}
