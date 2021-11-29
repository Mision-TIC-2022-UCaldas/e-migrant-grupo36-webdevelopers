using System.Collections.Generic;
using Dominio;

namespace Persistencia
{
    public interface IRepositorioNovedad    {
        IEnumerable<Novedad> ListarNovedades();
        bool CrearNovedad(Novedad Novedad);
        bool ActualizarNovedad(Novedad Novedad);
        bool EliminarNovedad(int idNovedad);
        Novedad BuscarNovedad (int idNovedad);
        
    }

}