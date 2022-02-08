using CargaDatos;
using Modelo.Entidades;
using ModeloDB;
using System.Collections.Generic;
using static CargaDatos.DatosIniciales;

namespace Consola
{
    public class Grabar
    {
        public void DatosIni()
        {
            DatosIniciales datos = new DatosIniciales();
            var listas = datos.Carga();

            // Extraer del diccionario las listas
            var listaConfiguracion = (List<Configuracion>)listas[ListasTipo.Configuracion];
            var listaPersonal = (List<Personal>)listas[ListasTipo.Personal];
            var listaEmpresa = (List<Empresa>)listas[ListasTipo.Empresa];
            var lista13 = (List<Decimo_Tercero>)listas[ListasTipo.Decimo_Tercero];
            var listaroles = (List<Roles>)listas[ListasTipo.Roles];
            var listaliquidacion = (List<Liquidaciones>)listas[ListasTipo.Liquidaciones];
            var listasalarios = (List<Salario>)listas[ListasTipo.Salario];

            using (AcademiaDB db = AcademiaDBBuilder.Crear())
            {
                // Se asegura que se borre y vuelva a crear la base de datos
                db.PreparaDB(); 
                // Agrega los listados                
                db.configuracion.AddRange(listaConfiguracion);
                db.personales.AddRange(listaPersonal);
                db.empresas.AddRange(listaEmpresa);
                db.decimo_Terceros.AddRange(lista13);
                db.roles.AddRange(listaroles);
                db.liquidaciones.AddRange(listaliquidacion);
                db.salarios.AddRange(listasalarios);
                // Guarda todos los datos
                db.SaveChanges();
            }            
        }        
    }
}
