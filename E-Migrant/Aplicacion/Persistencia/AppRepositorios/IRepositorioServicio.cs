using System.Collections.Generic;
using Dominio;

namespace Persistencia
{
    public interface IRepositorioServicio
    {
        IEnumerable<Servicio> ListarServicios();
        bool CrearServicio(Servicio obj);
        bool ActualizarServicio (Servicio obj);
        bool EliminarServicio(int id);
        Servicio BuscarServicio(int id);
        //List<Servicio> ListarServicios1();
    }
}