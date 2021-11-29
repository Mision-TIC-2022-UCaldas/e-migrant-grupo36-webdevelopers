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
    public class EliminarModel : PageModel
    {
        private readonly IRepositorioColaboradora repocolaboradora;
        public EliminarModel(IRepositorioColaboradora _repocolaboradora)
        {
            this.repocolaboradora=_repocolaboradora;
        }
        [BindProperty]
        public Colaboradora Colaboradora{get;set;}

        public ActionResult OnGet(int id)
        {
            Colaboradora= repocolaboradora.BuscarColaboradora(id);
            if (Colaboradora==null)
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
             
             bool funciono=repocolaboradora.EliminarColaboradora(Colaboradora.Id);
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
