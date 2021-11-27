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
    public class EditarModel : PageModel
    {
        
        private readonly IRepositorioMigrante _repomigrante;
        public EditarModel(IRepositorioMigrante repomigrante)
        {
            this._repomigrante=repomigrante;
        }
        [BindProperty]
        public Migrante Migrante{get;set;}

        public ActionResult OnGet(int id)
        {            
            Migrante= _repomigrante.BuscarMigrante(id);
            return Page();
        }

         public ActionResult OnPost()
         {
             if(!ModelState.IsValid)
            {
                return Page();
            }
                       
            bool funciono=_repomigrante.ActualizarMigrante(Migrante);
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
