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
    public class ChangePasswordModel : PageModel
    {
        private Persistencia.AppContext _appContext;
        
                
        [BindProperty]
        public string Mail{get;set;}
        
        [BindProperty]
        public string NewPassword{get;set;}

        [BindProperty]
        public string NewPasswordConfirm {get;set;}

        [BindProperty]
        public string Mensaje{get;set;}
        

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            _appContext = new Persistencia.AppContext();


            if(NewPassword != null || Mail != null || NewPasswordConfirm!=null)
            {
                //var Mail = HttpContext.Session.SetString("MiMail", Mail);
               
                //var Mail = HttpContext.Session.SetString("MiMail", Mail);
                var p = _appContext.Usuarios.FirstOrDefault( p => p.Correo == Mail);
                if (p == null)
                {
                    Mensaje = "Correo no regist";
                }

                else if (!NewPassword.Equals(NewPasswordConfirm))
                {
                    //Console.WriteLine("Contraseña incorrecta");
                    Mensaje = "Contraseñas no coinciden";
                }
                
                else
                {
                    HttpContext.Session.SetString("MiMail", Mail);
                    HttpContext.Session.SetString("MiUsuario", p.User);

                    HttpContext.Session.SetString("MiRol", p.Rol);
                    p.Contrasena = NewPassword;
                    _appContext.SaveChanges();
                    return RedirectToPage("../Index");
                }
            }
            else
            {
                Mensaje = "Rellena todo los campos.";
            }


            return Page();
        }
    }
}
