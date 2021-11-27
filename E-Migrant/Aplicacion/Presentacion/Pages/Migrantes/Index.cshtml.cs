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
    public class IndexModel : PageModel
    {
          //Crear un objeto para hacer uso de los repositorios
        private readonly IRepositorioMigrante _repomigrante;
        // modelo u objeto para transportar hacia MIndex.cshtml
        public IEnumerable<Migrante> Migrantes {get;set;}

        // constructor
        public IndexModel(IRepositorioMigrante repomigrante)
        {
            this._repomigrante=repomigrante;
        }

        public void OnGet()
        {
            Migrantes=_repomigrante.ListarMigrantes();
        }
    }
}
