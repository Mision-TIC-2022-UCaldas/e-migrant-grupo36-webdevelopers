using System.Collections.Generic;
using Dominio;

namespace Persistencia
{
    public interface IRepositorioColaboradora
    {
        IEnumerable<Colaboradora> ListarColaboradoras();
        //List<Colaboradora> ListarColaboradoras1();
        bool CrearColaboradora(Colaboradora obj);
        bool ActualizarColaboradora (Colaboradora obj);
        bool EliminarColaboradora(int id);
        Colaboradora BuscarColaboradora(int id);
    }
}