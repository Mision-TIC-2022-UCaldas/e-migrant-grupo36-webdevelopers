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
    public class EditarModel : PageModel
    {
        
        private readonly IRepositorioSolicitud _reposolicitud;
        public EditarModel(IRepositorioSolicitud reposolicitud)
        {
            this._reposolicitud=reposolicitud;
        }
        [BindProperty]
        public Solicitud Solicitud{get;set;}

        public ActionResult OnGet(int id)
        {            
            Solicitud= _reposolicitud.BuscarSolicitud(id);
            return Page();
        }

         public ActionResult OnPost()
         {
             if(!ModelState.IsValid)
            {
                return Page();
            }
                       
            bool funciono=_reposolicitud.ActualizarSolicitud(Solicitud);
            if(funciono)
            {
                return RedirectToPage("./Index");
            }
            else
            {
                ViewData["Mensaje"]="se ha presentado un error...";
                return Page();
            }             
            
         }
    }
}
