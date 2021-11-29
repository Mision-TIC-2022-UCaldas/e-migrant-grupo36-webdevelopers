using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using Dominio;
using Persistencia;

namespace Presentacion.Pages.Solicitudes
{
    public class IndexModel : PageModel
    {
          //Crear un objeto para hacer uso de los repositorios
        private readonly IRepositorioSolicitud _reposolicitud;
        // modelo u objeto para transportar hacia MIndex.cshtml
        public IEnumerable<Solicitud> Solicitudes {get;set;}

        // constructor
        public IndexModel(IRepositorioSolicitud reposolicitud)
        {
            this._reposolicitud=reposolicitud;
        }

        public void OnGet()
        {
            Solicitudes=_reposolicitud.ListarSolicitudes();
        }
    }
}
