using System.Collections.Generic;
using Dominio;
using System.Linq;

namespace Persistencia
{
    public class RepositorioNovedad:IRepositorioNovedad
    {
        //Atributos
        private readonly AppContext _appContext;

        //Metodos

        //Constructor
        public RepositorioNovedad(AppContext appContext)
        {
            _appContext=appContext;
        }
        //Implementar todos los metodos de la interfaz IRepositorioDeportista
        bool IRepositorioNovedad.CrearNovedad(Novedad Novedad)
        {
            bool creado=false;
            try
            {
                _appContext.Novedades.Add(Novedad);
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
        bool IRepositorioNovedad.ActualizarNovedad(Novedad Novedad)
        {
            bool actualizado=false;
            var nov=_appContext.Novedades.Find(Novedad.Id);
            if (nov!=null)
            {
                try
                {
                    nov.FechaNovedad=Novedad.FechaNovedad;
                    nov.NumDiasActivo=Novedad.NumDiasActivo;
                    nov.TextoExplicacion=Novedad.TextoExplicacion;
                    nov.Estado=Novedad.Estado;
                       
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
        bool IRepositorioNovedad.EliminarNovedad(int idNovedad)
        {
            bool eliminado=false;
            var novedad=_appContext.Novedades.Find(idNovedad);
            if (novedad!=null)
            {
                try
                {
                    _appContext.Novedades.Remove(novedad);
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
        Novedad IRepositorioNovedad.BuscarNovedad(int idNovedad)
        {
            Novedad novedad=_appContext.Novedades.Find(idNovedad);
            return novedad;
        }
        IEnumerable<Novedad> IRepositorioNovedad.ListarNovedades()
        {
            return _appContext.Novedades; 
        }      
    }    
}