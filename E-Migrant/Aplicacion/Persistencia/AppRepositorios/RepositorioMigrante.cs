using System.Collections.Generic;
using Dominio;
using System.Linq;

namespace Persistencia
{
    public class RepositorioMigrante:IRepositorioMigrante
    {
        //Atributos
        private readonly AppContext _appContext;

        //Metodos

        //Constructor
        public RepositorioMigrante(AppContext appContext)
        {
            _appContext=appContext;
        }
        //Implementar todos los metodos de la interfaz IRepositorioDeportista
        bool IRepositorioMigrante.CrearMigrante(Migrante migrante)
        {
            bool creado=false;
            try
            {
                _appContext.Migrantes.Add(migrante);
                _appContext.SaveChanges();
                creado=true;
            }
            catch (System.Exception)
            {
                return creado;
                //throw;
            }
            return creado;

        }
        bool IRepositorioMigrante.ActualizarMigrante(Migrante migrante)
        {
            bool actualizado=false;
            var mig=_appContext.Migrantes.Find(migrante.Id);
            if (mig!=null)
            {
                try
                {
                    mig.Nombres=migrante.Nombres;
                    mig.Apellidos=migrante.Apellidos;
                    mig.TipoDocumento=migrante.TipoDocumento;
                    mig.Documento=migrante.Documento;
                    mig.PaisOrigen=migrante.PaisOrigen;
                    mig.FechaNacimiento=migrante.FechaNacimiento;
                    mig.Telefono=migrante.Telefono;
                    mig.DireccionActual=migrante.DireccionActual;
                    mig.Ciudad=migrante.Ciudad;
                    
                    _appContext.SaveChanges();
                    actualizado=true;
                }
                catch
                {
                    return actualizado;
                }
            }
            return actualizado;

        }
        bool IRepositorioMigrante.EliminarMigrante(int idMigrante)
        {
            bool eliminado=false;
            var migrante=_appContext.Migrantes.Find(idMigrante);
            if (migrante!=null)
            {
                try
                {
                    _appContext.Migrantes.Remove(migrante);
                    _appContext.SaveChanges();
                    eliminado=true;
                }
                catch (System.Exception)
                {
                    return eliminado;
                }

            }
            return eliminado;

        }
        Migrante IRepositorioMigrante.BuscarMigrante(int idMigrante)
        {
            Migrante migrante=_appContext.Migrantes.Find(idMigrante);
            return migrante;
        }

        IEnumerable<Migrante> IRepositorioMigrante.ListarMigrantes()
        {
            return _appContext.Migrantes; 
        }

        
    }    
}