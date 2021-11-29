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
     public class CrearModel : PageModel
    {
        //Objeto para utilizar el repositorio
        private readonly IRepositorioColaboradora _repocolaboradora;
        //Objeto para transportar al cshtml
        //Etiquetar como propiedad ppl
        [BindProperty]
        public Colaboradora Colaboradora{get; set;}
        //Constructor
        public CrearModel (IRepositorioColaboradora repocolaboradora)
        {
            this._repocolaboradora=repocolaboradora;
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
            bool creado=_repocolaboradora.CrearColaboradora(Colaboradora);
            if (creado)
            {
                return RedirectToPage("./Index");
            }
            else
            {
                ViewData["Mensaje"]="La fecha de finalización debe ser posterior a la fecha de inicio";
                return Page();
            }
        }
    }
}
