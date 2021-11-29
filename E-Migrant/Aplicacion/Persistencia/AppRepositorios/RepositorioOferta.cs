using System.Collections.Generic;
using Dominio;
using System.Linq;

namespace Persistencia
{
    public class RepositorioOferta:IRepositorioOferta
    {
        //Atributos
        private readonly AppContext _appContext;

        //Metodos

        //Constructor
        public RepositorioOferta(AppContext appContext)
        {
            _appContext=appContext;
        }
        //Implementar todos los metodos de la interfaz IRepositorioDeportista
        bool IRepositorioOferta.CrearOferta(Oferta oferta)
        {
            bool creado=false;
            try
            {
                _appContext.Ofertas.Add(oferta);
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
        bool IRepositorioOferta.ActualizarOferta(Oferta oferta)
        {
            bool actualizado=false;
            var ofe=_appContext.Ofertas.Find(oferta.Id);
            if (ofe!=null)
            {
                try
                {
                    ofe.Nombre=oferta.Nombre;
                    ofe.MaxMigrantes=oferta.MaxMigrantes;
                    ofe.FechaInicio=oferta.FechaInicio;
                    ofe.FechaFinal=oferta.FechaFinal;
                    ofe.Estado=oferta.Estado;
                   
                    
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
        bool IRepositorioOferta.EliminarOferta(int idOferta)
        {
            bool eliminado=false;
            var oferta=_appContext.Ofertas.Find(idOferta);
            if (oferta!=null)
            {
                try
                {
                    _appContext.Ofertas.Remove(oferta);
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
        Oferta IRepositorioOferta.BuscarOferta(int idOferta)
        {
            Oferta oferta=_appContext.Ofertas.Find(idOferta);
            return oferta;
        }

        IEnumerable<Oferta> IRepositorioOferta.ListarOfertas()
        {
            return _appContext.Ofertas; 
        }

        
    }    
}