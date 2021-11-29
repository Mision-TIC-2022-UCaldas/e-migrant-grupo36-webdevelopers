using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using Dominio;
using Persistencia;

namespace Presentacion.Pages.Ofertas
{
   public class EditarModel : PageModel
    {
        
        private readonly IRepositorioOferta _repooferta;
        public EditarModel(IRepositorioOferta repooferta)
        {
            this._repooferta=repooferta;
        }
        [BindProperty]
        public Oferta Oferta{get;set;}

        public ActionResult OnGet(int id)
        {            
            Oferta= _repooferta.BuscarOferta(id);
            return Page();
        }

         public ActionResult OnPost()
         {
             if(!ModelState.IsValid)
            {
                return Page();
            }
                       
            bool funciono=_repooferta.ActualizarOferta(Oferta);
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
