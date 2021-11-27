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
    public class CrearModel : PageModel
    {
        //Objeto para utilizar el repositorio
        private readonly IRepositorioMigrante _repomigrante;
        //Objeto para transportar al cshtml
        //Etiquetar como propiedad ppl
        [BindProperty]
        public Migrante Migrante{get; set;}
        //Constructor
        public CrearModel (IRepositorioMigrante repomigrante)
        {
            this._repomigrante=repomigrante;
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
            bool creado=_repomigrante.CrearMigrante(Migrante);
            if (creado)
            {
                return RedirectToPage("./Index");
            }
            else
            {
                ViewData["Mensaje"]="El migrante ya se encuentra registrado";
                return Page();
            }
        }
    }
}
