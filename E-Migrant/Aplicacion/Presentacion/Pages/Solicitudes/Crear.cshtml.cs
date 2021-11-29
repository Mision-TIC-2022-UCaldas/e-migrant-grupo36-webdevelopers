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
   public class CrearModel : PageModel
    {
        //Objeto para utilizar el repositorio
        private readonly IRepositorioSolicitud _reposolicitud;
        //Objeto para transportar al cshtml
        //Etiquetar como propiedad ppl
        [BindProperty]
        public Solicitud Solicitud{get; set;}
        //Constructor
        public CrearModel (IRepositorioSolicitud reposolicitud)
        {
            this._reposolicitud=reposolicitud;
        }

        //Se debe retornar algo ActionResult OnGet
        public ActionResult OnGet()
        {
            return Page();
        }

        public ActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            bool creado=_reposolicitud.CrearSolicitud(Solicitud);
            if (creado)
            {
                return RedirectToPage("./Index");
            }
            else
            {
                ViewData["Mensaje"]="La solicitud ya se encuentra registrada";
                return Page();
            }
        }
    }
}
