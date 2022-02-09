using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Modelo.Entidades;
using MySqlConnector;
using System;

namespace ModeloDB
{
    public class AcademiaDB : DbContext
    {
        public AcademiaDB()
        {

        }

        public AcademiaDB(DbContextOptions options)
            :base(options)
        {
            
        }

        // Se asegura el borrado y la creación de la base de datos
        public void PreparaDB()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        // Declaración de las entidades del modelo
        public DbSet<Personal> personales { get; set; }
        public DbSet<Empresa> empresas { get; set; }
        public DbSet<Decimo_Tercero> decimo_Terceros { get; set; }
        public DbSet<Liquidaciones> liquidaciones { get; set; }
        public DbSet<Roles> roles { get; set; }
        public DbSet<Salario> salarios { get; set; }
        public DbSet<Configuracion> configuracion { get; set; }

        // Configuración de la conección
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // Si no se ha configurado la conección la configura con SqlServer
            if (!options.IsConfigured) 
            {
                /*string conPG = " Host = localhost;" +
                           " Database = nomina1.1;" +
                           " Username = postgres;" +
                           " Password = 17001";
                options.UseNpgsql(conPG);*/
                options.UseMySQL("server=localhost;database=Proyecto;user=root;password=1234");
               //options.UseSqlServer("Server=DESKTOP-OAT5MPN; Initial Catalog=NominaProyecto1; trusted_connection=true;");
                //.LogTo(Console.WriteLine, LogLevel.Information);  // Para activar el modo debug
            }
        }

        // Configurar el modelo de clases
        protected override void OnModelCreating(ModelBuilder model)
        {
            //TABLA DE CONFIFURACION
            model.Entity<Configuracion>()
               .HasKey(configuracion => configuracion.NombreEmpresa);

            //REALACION DE UNO A MUCHOS CON DECIMO TERCERO
            model.Entity<Decimo_Tercero>()
                .HasOne(tercero => tercero.Personal)
                .WithMany(personal => personal.Decimos_Terceros)
                .HasForeignKey(tercero => tercero.PersonalId);
            //RELACION DE UNA A MUCHOS CON ROLES
            model.Entity<Roles>()
               .HasOne(roles => roles.Personal)
               .WithMany(personal => personal.Roles)
               .HasForeignKey(roles => roles.PersonalId);
            //RELACION DE UNA A MUCHOS CON SALARIO
            model.Entity<Salario>()
               .HasOne(roles => roles.Personal)
               .WithMany(personal => personal.Salarios)
               .HasForeignKey(roles => roles.PersonalId);
            //RELACION DE UNO A UNO CON EMPRESA
            model.Entity<Empresa>()
               .HasOne(malla => malla.Personal)
               .WithOne(materia => materia.empresa)
               .HasForeignKey<Empresa>(malla => malla.PersonalId);
            //RELACION DE UNO A UNO CON Roles
            model.Entity<Roles>()
               .HasOne(malla => malla.Salario)
               .WithOne(materia => materia.roles)
               .HasForeignKey<Roles>(malla => malla.SalarioID);
            //RELACION DE UNO A UNO CON DECIMO TERCERO
            model.Entity<Decimo_Tercero>()
               .HasOne(malla => malla.Salario)
               .WithOne(materia => materia.decterceros)
               .HasForeignKey<Decimo_Tercero>(malla => malla.SalarioID);
            //RELACION DE UNO A UNO CON LIQUIDACION
            model.Entity<Liquidaciones>()
               .HasOne(malla => malla.Personal)
               .WithOne(materia => materia.liquidacion)
               .HasForeignKey<Liquidaciones>(malla => malla.PersonalId);
            
        }
    }
}
