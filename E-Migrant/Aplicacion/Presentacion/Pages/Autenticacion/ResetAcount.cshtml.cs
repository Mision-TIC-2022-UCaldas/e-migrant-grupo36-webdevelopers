using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;

using Dominio.Entidades;
using Persistencia;
namespace Presentacion.Pages.Autenticacion
{
    public class ResetAcountModel : PageModel
    {
        private Persistencia.AppContext _appContext;
        
                
        [BindProperty]
        public string Mail{get;set;}
        

        [BindProperty]
        public string Mensaje{get;set;}
        

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            _appContext = new Persistencia.AppContext();


            if(Mail != null)
            {
                //var Mail = HttpContext.Session.SetString("MiMail", Mail);
               
                //var Mail = HttpContext.Session.SetString("MiMail", Mail);
                var p = _appContext.Usuarios.FirstOrDefault( p => p.Correo == Mail);
                if (p == null)
                {
                    Mensaje = "Correo no registrado";
                }
                
                else
                {
                    HttpContext.Session.SetString("MiMail", Mail);
                    p.Contrasena = "12345$";
                    p.User="admin";
                    HttpContext.Session.SetString("MiUsuario", p.User);
                    HttpContext.Session.SetString("MiRol", p.Rol);
                    _appContext.SaveChanges();
                    return RedirectToPage("../Index");
                }
            }
            else
            {
                Mensaje = "Este es un campo obligatorio.";
            }


            return Page();
        }
    }
}
