using System.Collections.Generic;
using Dominio;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Persistencia
{
    public class RepositorioEvaluacion:IRepositorioEvaluacion
    {
        //Atributos
        private readonly AppContext _appContext;

        //Metodos

        //Constructor
        public RepositorioEvaluacion(AppContext appContext)
        {
            _appContext=appContext;
        }
        
        Evaluacion IRepositorioEvaluacion.CrearEvaluacion(Evaluacion evaluacion)
        {
            var evaluacionAdicionada =_appContext.Evaluaciones.Add(evaluacion);
            _appContext.SaveChanges();
            return evaluacionAdicionada.Entity;
        }
        Evaluacion IRepositorioEvaluacion.GetEvaluacion(int idEvaluacion)
        {
            return _appContext.Evaluaciones.Include(m => m.Migrante).FirstOrDefault(m => m.Id==idEvaluacion);
        }
                IEnumerable<Evaluacion> IRepositorioEvaluacion.ListarEvaluaciones()
        {
            return _appContext.Evaluaciones.Include(k => k.Migrante); 
        }
    }    
}