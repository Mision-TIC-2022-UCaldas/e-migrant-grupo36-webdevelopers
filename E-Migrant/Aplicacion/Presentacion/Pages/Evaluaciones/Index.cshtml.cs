using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using Dominio;
using Persistencia;

namespace Presentacion.Pages.Evaluaciones
{
    public class IndexModel : PageModel
    {
          //Crear un objeto para hacer uso de los repositorios
        private readonly IRepositorioEvaluacion _repoevaluacion;
        // modelo u objeto para transportar hacia MIndex.cshtml
        public IEnumerable<Evaluacion> Evaluaciones {get;set;}

        // constructor
        public IndexModel(IRepositorioEvaluacion repoevaluacion)
        {
            this._repoevaluacion=repoevaluacion;
        }

        public void OnGet()
        {
            Evaluaciones=_repoevaluacion.ListarEvaluaciones();
        }
    }
}
