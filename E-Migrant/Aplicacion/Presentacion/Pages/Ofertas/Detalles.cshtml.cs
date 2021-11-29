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
    public class DetallesModel : PageModel
    {
        private readonly IRepositorioOferta _repooferta;
        public DetallesModel(IRepositorioOferta repooferta)
        {
            this._repooferta=repooferta;
        }
        [BindProperty]
        public Oferta Oferta{get;set;}

        public ActionResult OnGet(int id)
        {
            Oferta= _repooferta.BuscarOferta(id);
            if (Oferta==null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
