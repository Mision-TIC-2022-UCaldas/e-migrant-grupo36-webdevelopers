using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using Dominio;
using Persistencia;

namespace Presentacion.Pages.Novedades
{
    public class EditarModel : PageModel
    {
        
        private readonly IRepositorioNovedad _reponovedad;
        public EditarModel(IRepositorioNovedad reponovedad)
        {
            this._reponovedad=reponovedad;
        }
        [BindProperty]
        public Novedad Novedad{get;set;}

        public ActionResult OnGet(int id)
        {            
            Novedad= _reponovedad.BuscarNovedad(id);
            return Page();
        }

         public ActionResult OnPost()
         {
             if(!ModelState.IsValid)
            {
                return Page();
            }
                       
            bool funciono=_reponovedad.ActualizarNovedad(Novedad);
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
