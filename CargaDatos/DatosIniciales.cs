using Modelo.Entidades;
using System;
using System.Collections.Generic;
//using static Modelo.Entidades.Personal;

namespace CargaDatos
{
    public class DatosIniciales
    {
        public enum ListasTipo { 
            Configuracion, Personal, Empresa,Liquidaciones,Decimo_Tercero,Roles,Salario
        }

        public Dictionary<ListasTipo, object> Carga()
        {

            //CONFIGURACION
            #region
            Configuracion config = new Configuracion()
            {
                sueldoMaximo = 425.00f,
                NombreEmpresa = "Empresa Patito",
                Horas_Extras_Maxima = 8.00f,
                Horas_Extras_Minima = 1.00f,
                Salario_Horas_Extras = 2.00f
            };
            List<Configuracion> listaConfiguracion = new List<Configuracion>()
            {
                config
            };
            #endregion
            //PERSONALES
            #region
            Personal Pedro = new Personal()
            {
                Nombre = "Pedro Navaja",
                Cedula = "1706856566",
                Email = "pedro234@g.com",
                Telefono = "0984231388",
                Direccion="Av. Del Maestro",
                EstadoCV= Personal.EstadoCivil.Soltero,
                salario=600.50f,
                tipo=Personal.TipoContrato.Completo,
                fecha_incio = new DateTime(2019, 3, 1),
                fecha_salida = new DateTime(2022, 3, 1)
            };
            List<Personal> listaPersonal = new List<Personal>()
            {
                Pedro
            };
            #endregion
            //EMPRESA
            #region
            Empresa patito = new Empresa()
            {
                Personal= Pedro,
                ruc="1722644299001",
                nombreEmpresa = "Empresa Patito",
                direccion = "El Condado",
                telefono="0984231389",
                provincia="Pichincha"
            };
            List<Empresa> listaEmpresa = new List<Empresa>()
            {
                patito
            };
            #endregion
            //SALARIOS
            #region
            Salario sal1 = new Salario()
            {
                Personal = Pedro,
                SueldoBasico = 500.00f,
                DecimoTercerSueldo = 33.33f,
                DecimoCuartoSueldo = 45.12f,
                Utilidades = 120.00f,
                EstadoSal = Salario.estadoSalario.Pendiente

            };
            List<Salario> listasalario = new List<Salario>()
            {
                sal1
            };
            #endregion
            //DECIMO TERCERO
            #region
            Decimo_Tercero dec13 = new Decimo_Tercero
            {
                Personal = Pedro,
                fecha_inicio = new DateTime(2019, 3, 1),
                fecha_final = new DateTime(2022, 3, 1),
                meses = "12",
                total=33.33f,
                Salario = sal1
            };
            List<Decimo_Tercero> listadecimo_Terceros = new List<Decimo_Tercero>()
            {
                dec13
            };
            #endregion
            //ROLES
            #region
            Roles rol1 = new Roles()
            {
                Personal = Pedro,
                comision = 300.00f,
                aporte_iess = 45.35f,
                anticipo = 21.00f,
                total = 966.85f,
                Salario = sal1
            };
            List<Roles> listaroles = new List<Roles>()
            {
                rol1
            };
            #endregion
            //LIQUIDACION
            #region
            Liquidaciones liq1 = new Liquidaciones()
            {
                Personal = Pedro,
                cesantia = "300.00",
                periodo_pri = "2",
                salario_base="425.00",
                Estadoliq=Liquidaciones.estado.Liquidacion
            };
            List<Liquidaciones> listaliquidacion = new List<Liquidaciones>()
            {
                liq1
            };
            #endregion
            

            // --------------------------------------------
            // Diccionario contiene todas las listas
            // --------------------------------------------
            Dictionary<ListasTipo, object> dicListasDatos = new Dictionary<ListasTipo, object>()
            {
                { ListasTipo.Configuracion, listaConfiguracion},
                { ListasTipo.Personal, listaPersonal},
                { ListasTipo.Empresa, listaEmpresa},
                { ListasTipo.Decimo_Tercero, listadecimo_Terceros},
                { ListasTipo.Roles, listaroles},
                { ListasTipo.Liquidaciones, listaliquidacion},
                { ListasTipo.Salario, listasalario}
            };

            return dicListasDatos;
        
        }
    }
}
