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
    public class DetallesModel : PageModel
    {
        private readonly IRepositorioSolicitud _reposolicitud;
        public DetallesModel(IRepositorioSolicitud reposolicitud)
        {
            this._reposolicitud=reposolicitud;
        }
        [BindProperty]
        public Solicitud Solicitud{get;set;}

        public ActionResult OnGet(int id)
        {
            Solicitud= _reposolicitud.BuscarSolicitud(id);
            if (Solicitud==null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
