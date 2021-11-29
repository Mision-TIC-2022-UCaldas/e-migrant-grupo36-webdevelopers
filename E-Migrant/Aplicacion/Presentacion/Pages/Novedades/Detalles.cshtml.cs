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
    public class DetallesModel : PageModel
    {
        private readonly IRepositorioNovedad _reponovedad;
        public DetallesModel(IRepositorioNovedad reponovedad)
        {
            this._reponovedad=reponovedad;
        }
        [BindProperty]
        public Novedad Novedad{get;set;}

        public ActionResult OnGet(int id)
        {
            Novedad= _reponovedad.BuscarNovedad(id);
            if (Novedad==null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
