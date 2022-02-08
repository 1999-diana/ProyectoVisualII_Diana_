using Microsoft.EntityFrameworkCore;
using ModeloDB;
using System.Configuration;

namespace Consola
{
    public class AcademiaDBBuilder
    {
        const string DBTipo = "DBTipo";
        enum DBTipoConn { SqlServer, Postgres, Memoria }
        static AcademiaDB db ;

        public static AcademiaDB Crear()
        {
            // Lee la configuración acerca de qué base usar del archivo App.config
            string dbtipo;
            string conn;
            
            dbtipo = ConfigurationManager.AppSettings[DBTipo];

            if (dbtipo == null)
            {
                dbtipo = "Memoria";
                conn = "NominaProyecto1";
            } 
            else
            {
                conn = ConfigurationManager.ConnectionStrings[dbtipo].ConnectionString;
            }
            
            // Construye la conección acorde con el tipo
            DbContextOptions<AcademiaDB> contextOptions;
            switch (dbtipo)
            {
                case nameof(DBTipoConn.SqlServer) :
                    contextOptions = new DbContextOptionsBuilder<AcademiaDB>()
                        .UseSqlServer(conn)
                        .Options;
                    break;
                case nameof(DBTipoConn.Postgres):
                    contextOptions = new DbContextOptionsBuilder<AcademiaDB>()
                        .UseNpgsql(conn)
                        .Options;
                    break;
                default: // Por defecto usa la memoria como base de datos
                    contextOptions = new DbContextOptionsBuilder<AcademiaDB>()
                        .UseInMemoryDatabase(conn)
                        .Options;
                    break;
            }

            db = new AcademiaDB(contextOptions);

            return db;
        }        
    }
}
