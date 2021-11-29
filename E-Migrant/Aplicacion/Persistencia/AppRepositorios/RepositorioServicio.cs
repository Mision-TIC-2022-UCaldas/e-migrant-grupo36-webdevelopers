using System.Collections.Generic;
using Dominio;
using System.Linq;

namespace Persistencia
{
    public class RepositorioServicio:IRepositorioServicio
    {
        // Atributos
        private readonly AppContext _appContext;

        //Metodos
        //Constructor
        public RepositorioServicio(AppContext appContext)
        {
            _appContext=appContext;
        }
        //implementar todos los metodos de la interfaz IRepositorioMunicipio

        public bool CrearServicio(Servicio obj)
        {
           bool creado=false;
           bool ex= Existe(obj);
           if(!ex)
           {
                try
                {
                    _appContext.Servicios.Add(obj);
                    _appContext.SaveChanges();
                    creado=true;
                }
                catch (System.Exception)
                {
                     return creado;
                   
                }
           }          
           return creado;
        }
      

        bool IRepositorioServicio.ActualizarServicio(Servicio servicio)
        {
            bool actualizado=false;
            var ser=_appContext.Servicios.Find(servicio.Id);
            if (ser!=null)
            {
                try
                {
                    ser.Nombre=servicio.Nombre;
                    ser.MaxMigrantes=servicio.MaxMigrantes;
                    ser.FechaInicio=servicio.FechaInicio;
                    ser.FechaFinal=servicio.FechaFinal;
                    ser.Estado=servicio.Estado;
                    ser.ColaboradoraId=servicio.ColaboradoraId;
                    
                    
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

       /* public bool ActualizarServicio (Servicio obj)
        {
            bool actualizado=false;            
            var ser=_appContext.Servicios.Find(obj.Id);
            if(ser !=null)
            {
                
                try
                {
                    //_appContext.Entry(municipio).State= Microsoft.EntityFrameworkCore.EntityState.Modified;
                    ser.Nombre=obj.Nombre;
                    ser.MaxMigrantes=obj.MaxMigrantes;
                    ser.FechaInicio=obj.FechaInicio;
                    ser.FechaFinal=obj.FechaFinal;
                    ser.Estado=obj.Estado;
                    ser.EntidadId=obj.EntidadId;
                    _appContext.SaveChanges();
                    actualizado=true;
                }
                catch (System.Exception)
                {
                    return actualizado;   
                    //throw;
                }
                
            }
            return actualizado;
        }  */

        public bool EliminarServicio(int id)
        {
            bool eliminado= false;
            var servicio=_appContext.Servicios.Find(id);
            if(servicio!=null)
            {
                try
                {
                     _appContext.Servicios.Remove(servicio);
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
        public Servicio BuscarServicio(int id)
        {
            Servicio servicio= _appContext.Servicios.Find(id);
            return servicio;
        }

        public IEnumerable<Servicio> ListarServicios()
        {
            return _appContext.Servicios;
        }

      /*  public List<Torneo> ListarTorneos1()
        {
            return _appContext.Torneos.ToList();
        } */

        bool Existe(Servicio obj)
        {
            bool ex=false;
            var tor=_appContext.Servicios.FirstOrDefault(t=> t.Nombre==obj.Nombre);
            if(tor!=null)
            {
                ex=true;
            }
            return ex;
        }

    }
}