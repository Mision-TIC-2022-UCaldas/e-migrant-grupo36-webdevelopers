using System.Collections.Generic;
using Dominio;
using System.Linq;

namespace Persistencia
{
    public class RepositorioColaboradora:IRepositorioColaboradora
    {
        //Atributos
        private readonly AppContext _appContext;

        //Metodos

        //Constructor
        public RepositorioColaboradora(AppContext appContext)
        {
            _appContext=appContext;
        }
        //Implementar todos los metodos de la interfaz IRepositorioDeportista
        bool IRepositorioColaboradora.CrearColaboradora(Colaboradora colaboradora)
        {
            bool creado=false;
            try
            {
                _appContext.Colaboradoras.Add(colaboradora);
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
        bool IRepositorioColaboradora.ActualizarColaboradora(Colaboradora colaboradora)
        {
            bool actualizado=false;
            var col=_appContext.Colaboradoras.Find(colaboradora.Id);
            if (col!=null)
            {
                try
                {
                    col.RazonSocial=colaboradora.RazonSocial;
                    col.Nit=colaboradora.Nit;
                    col.Direccion=colaboradora.Direccion;
                    col.Ciudad=colaboradora.Ciudad;
                    col.CorreoElectronico=colaboradora.CorreoElectronico;
                    col.PaginaWeb=colaboradora.PaginaWeb;
                    col.Sector=colaboradora.Sector;
                    col.TipoServicios=colaboradora.TipoServicios;
                    
                    
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
        bool IRepositorioColaboradora.EliminarColaboradora(int idColaboradora)
        {
            bool eliminado=false;
            var colaboradora=_appContext.Colaboradoras.Find(idColaboradora);
            if (colaboradora!=null)
            {
                try
                {
                    _appContext.Colaboradoras.Remove(colaboradora);
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
        Colaboradora IRepositorioColaboradora.BuscarColaboradora(int idColaboradora)
        {
            Colaboradora colaboradora=_appContext.Colaboradoras.Find(idColaboradora);
            return colaboradora;
        }

        IEnumerable<Colaboradora> IRepositorioColaboradora.ListarColaboradoras()
        {
            return _appContext.Colaboradoras; 
        }

        
    }    
}