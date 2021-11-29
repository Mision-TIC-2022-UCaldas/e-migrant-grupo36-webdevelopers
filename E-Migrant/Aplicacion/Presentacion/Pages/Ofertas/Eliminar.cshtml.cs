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
    public class EliminarModel : PageModel
    {
        private readonly IRepositorioOferta repooferta;
        public EliminarModel(IRepositorioOferta _repooferta)
        {
            this.repooferta=_repooferta;
        }
        [BindProperty]
        public Oferta Oferta{get;set;}

        public ActionResult OnGet(int id)
        {
            Oferta= repooferta.BuscarOferta(id);
            if (Oferta==null)
            {
                return NotFound();
            }
            ViewData["Mensaje"]="esta seguro de eliminar el registro?";
            return Page();
        }

         public ActionResult OnPost()
         {
             /*if(!ModelState.IsValid)
             {
                 return Page();
             }*/
             
             bool funciono=repooferta.EliminarOferta(Oferta.Id);
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
