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
   public class CrearModel : PageModel
    {
        private readonly IRepositorioNovedad _reponovedad;
 
        [BindProperty]
        public Novedad Novedad{get; set;}
        public CrearModel (IRepositorioNovedad reponovedad)
        {
            this._reponovedad=reponovedad;
        }
 
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
            bool creado=_reponovedad.CrearNovedad(Novedad);
            if (creado)
            {
                return RedirectToPage("./Index");
            }
            else
            {
                ViewData["Mensaje"]="La Novedad ya se encuentra registrada";
                return Page();
            }
        }
    }
}