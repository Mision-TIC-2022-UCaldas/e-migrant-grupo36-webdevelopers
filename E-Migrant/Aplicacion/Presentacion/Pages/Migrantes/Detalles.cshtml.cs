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
    public class DetallesModel : PageModel
    {
        private readonly IRepositorioMigrante _repomigrante;
        public DetallesModel(IRepositorioMigrante repomigrante)
        {
            this._repomigrante=repomigrante;
        }
        [BindProperty]
        public Migrante Migrante{get;set;}

        public ActionResult OnGet(int id)
        {
            Migrante= _repomigrante.BuscarMigrante(id);
            if (Migrante==null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
