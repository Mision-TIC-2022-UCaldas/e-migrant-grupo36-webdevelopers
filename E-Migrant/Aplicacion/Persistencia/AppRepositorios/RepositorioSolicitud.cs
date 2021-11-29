using System.Collections.Generic;
using Dominio;
using System.Linq;

namespace Persistencia
{
    public class RepositorioSolicitud:IRepositorioSolicitud
    {
        //Atributos
        private readonly AppContext _appContext;

        //Metodos

        //Constructor
        public RepositorioSolicitud(AppContext appContext)
        {
            _appContext=appContext;
        }
        //Implementar todos los metodos de la interfaz IRepositorioDeportista
        bool IRepositorioSolicitud.CrearSolicitud(Solicitud solicitud)
        {
            bool creado=false;
            try
            {
                _appContext.Solicitudes.Add(solicitud);
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
        bool IRepositorioSolicitud.ActualizarSolicitud(Solicitud solicitud)
        {
            bool actualizado=false;
            var soli=_appContext.Solicitudes.Find(solicitud.Id);
            if (soli!=null)
            {
                try
                {
                    soli.Categoria=solicitud.Categoria;
                    soli.Descripcion=solicitud.Descripcion;
                    soli.Prioridad=solicitud.Prioridad;
                       
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
        bool IRepositorioSolicitud.EliminarSolicitud(int idSolicitud)
        {
            bool eliminado=false;
            var solicitud=_appContext.Solicitudes.Find(idSolicitud);
            if (solicitud!=null)
            {
                try
                {
                    _appContext.Solicitudes.Remove(solicitud);
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
        Solicitud IRepositorioSolicitud.BuscarSolicitud(int idSolicitud)
        {
            Solicitud solicitud=_appContext.Solicitudes.Find(idSolicitud);
            return solicitud;
        }

        IEnumerable<Solicitud> IRepositorioSolicitud.ListarSolicitudes()
        {
            return _appContext.Solicitudes; 
        }

        
    }    
}