using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using Dominio;
using Persistencia;

namespace Presentacion.Pages.Colaboradoras
{
     public class DetallesModel : PageModel
    {
        private readonly IRepositorioColaboradora _repocolaboradora;
        public DetallesModel(IRepositorioColaboradora repocolaboradora)
        {
            this._repocolaboradora=repocolaboradora;
        }
        [BindProperty]
        public Colaboradora Colaboradora{get;set;}

        public ActionResult OnGet(int id)
        {
            Colaboradora= _repocolaboradora.BuscarColaboradora(id);
            if (Colaboradora==null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
