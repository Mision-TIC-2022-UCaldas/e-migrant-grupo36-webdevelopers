using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using Dominio;
using Persistencia;

namespace Presentacion.Pages.Migrantes
{
    public class EliminarModel : PageModel
    {
        private readonly IRepositorioMigrante repomigrante;
        public EliminarModel(IRepositorioMigrante _repomigrante)
        {
            this.repomigrante=_repomigrante;
        }
        [BindProperty]
        public Migrante Migrante{get;set;}

        public ActionResult OnGet(int id)
        {
            Migrante= repomigrante.BuscarMigrante(id);
            if (Migrante==null)
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
             
             bool funciono=repomigrante.EliminarMigrante(Migrante.Id);
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
