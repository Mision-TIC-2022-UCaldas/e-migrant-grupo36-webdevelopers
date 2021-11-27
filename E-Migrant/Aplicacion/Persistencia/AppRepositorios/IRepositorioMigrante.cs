using System.Collections.Generic;
using Dominio;

namespace Persistencia
{
    public interface IRepositorioMigrante    {
        IEnumerable<Migrante> ListarMigrantes();
        bool CrearMigrante(Migrante Migrante);
        bool ActualizarMigrante(Migrante Migrante);
        bool EliminarMigrante(int idMigrante);
        Migrante BuscarMigrante (int idMigrante);
        
    }

}