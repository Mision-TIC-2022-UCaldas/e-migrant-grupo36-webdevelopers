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
   public class EditarModel : PageModel
    {
        
        private readonly IRepositorioColaboradora _repocolaboradora;
        public EditarModel(IRepositorioColaboradora repocolaboradora)
        {
            this._repocolaboradora=repocolaboradora;
        }
        [BindProperty]
        public Colaboradora Colaboradora{get;set;}

        public ActionResult OnGet(int id)
        {            
            Colaboradora= _repocolaboradora.BuscarColaboradora(id);
            return Page();
        }

         public ActionResult OnPost()
         {
             if(!ModelState.IsValid)
            {
                return Page();
            }
                       
            bool funciono=_repocolaboradora.ActualizarColaboradora(Colaboradora);
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
