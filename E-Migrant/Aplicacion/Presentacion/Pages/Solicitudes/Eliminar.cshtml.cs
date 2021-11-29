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
    public class EliminarModel : PageModel
    {
        private readonly IRepositorioSolicitud reposolicitud;
        public EliminarModel(IRepositorioSolicitud _reposolicitud)
        {
            this.reposolicitud=_reposolicitud;
        }
        [BindProperty]
        public Solicitud Solicitud{get;set;}

        public ActionResult OnGet(int id)
        {
            Solicitud= reposolicitud.BuscarSolicitud(id);
            if (Solicitud==null)
            {
                return NotFound();
            }
            ViewData["Mensaje"]="esta seguro de eliminar el registro?";
            return Page();
        }

         public ActionResult OnPost()
         {
             bool funciono=reposolicitud.EliminarSolicitud(Solicitud.Id);
             if(funciono)
             {
                return RedirectToPage("./Index");
             }
             else
             {
                ViewData["Error"]="No es posible eliminar registros que tienen integridad referencial";
                return Page();
             }
             
             
         }
    }
}
