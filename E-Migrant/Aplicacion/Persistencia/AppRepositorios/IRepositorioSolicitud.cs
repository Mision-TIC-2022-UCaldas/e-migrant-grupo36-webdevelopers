using System.Collections.Generic;
using Dominio;

namespace Persistencia
{
    public interface IRepositorioSolicitud    {
        IEnumerable<Solicitud> ListarSolicitudes();
        bool CrearSolicitud(Solicitud Solicitud);
        bool ActualizarSolicitud(Solicitud Solicitud);
        bool EliminarSolicitud(int idSolicitud);
        Solicitud BuscarSolicitud (int idSolicitud);
        
    }

}