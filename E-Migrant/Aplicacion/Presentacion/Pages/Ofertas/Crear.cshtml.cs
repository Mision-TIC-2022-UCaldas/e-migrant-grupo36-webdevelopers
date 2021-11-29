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
   public class CrearModel : PageModel
    {
        //Objeto para utilizar el repositorio
        private readonly IRepositorioOferta _repooferta;
        //Objeto para transportar al cshtml
        //Etiquetar como propiedad ppl
        [BindProperty]
        public Oferta Oferta{get; set;}
        //Constructor
        public CrearModel (IRepositorioOferta repooferta)
        {
            this._repooferta=repooferta;
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
            bool creado=_repooferta.CrearOferta(Oferta);
            if (creado)
            {
                return RedirectToPage("./Index");
            }
            else
            {
                ViewData["Mensaje"]="La oferta ya se encuentra registrada";
                return Page();
            }
        }
    }
}
