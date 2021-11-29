using System.Collections.Generic;
using Dominio;
using Microsoft.EntityFrameworkCore;

namespace Persistencia
{
    public interface IRepositorioEvaluacion    {
        IEnumerable<Evaluacion> ListarEvaluaciones();
        // bool CrearEvaluacion(Evaluacion Evaluacion);
        Evaluacion CrearEvaluacion(Evaluacion Evaluacion);
        Evaluacion GetEvaluacion(int idEvaluacion);
        
    }

}