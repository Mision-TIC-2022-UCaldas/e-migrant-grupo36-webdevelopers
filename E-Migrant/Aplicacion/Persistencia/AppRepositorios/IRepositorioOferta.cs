using System.Collections.Generic;
using Dominio;

namespace Persistencia
{
    public interface IRepositorioOferta    {
        IEnumerable<Oferta> ListarOfertas();
        bool CrearOferta(Oferta Oferta);
        bool ActualizarOferta(Oferta Oferta);
        bool EliminarOferta(int idOferta);
        Oferta BuscarOferta (int idOferta);
        
    }

}