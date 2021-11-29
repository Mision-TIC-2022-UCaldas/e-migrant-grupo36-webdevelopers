using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;


namespace Presentacion.Pages.Autenticacion
{
    public class LogoutModel : PageModel
    {
        public IActionResult OnGet()
        {
            HttpContext.Session.Remove("MiUsuario");
            HttpContext.Session.Remove("MiRol");
            return RedirectToPage("../Index");
        }
    }
}
