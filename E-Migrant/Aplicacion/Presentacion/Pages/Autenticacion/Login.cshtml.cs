using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Persistencia;
using Dominio.Entidades;

namespace Presentacion.Pages.Autenticacion
{
    public class LoginModel : PageModel
    {
        private Persistencia.AppContext _appContext;
        

        [BindProperty]
        public string Username {get;set;}
        
        [BindProperty]
        [EmailAddress]
        public string Mail{get;set;}
        
        [BindProperty]
        public string Password{get;set;}

        [BindProperty]
        public string MensajeUsername{get;set;}
        
        [BindProperty]
        public string MensajePassword{get;set;}

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            _appContext = new Persistencia.AppContext();
            var p = _appContext.Usuarios.FirstOrDefault( p => p.Correo == Mail);
            var a = _appContext.Usuarios.FirstOrDefault( a => a.User == Username);


            if(Username != null || Mail != null || Password!=null)
            {
                
                if(p == null)
                {
                    MensajePassword = "Correo no registrado";
                }

                else if(a== null)
                {
                    MensajePassword = "Usuario o contraseña incorrectos";
                }
                else if(!p.Contrasena.Equals(Password))
                {
                    MensajePassword = "Contraseña incorrecta";
                }

                else
                {
                    HttpContext.Session.SetString("MiMail", Mail);
                    HttpContext.Session.SetString("MiUsuario", Username);
                    HttpContext.Session.SetString("MiRol", p.Rol);
                    HttpContext.Session.SetString("MiId", p.Id.ToString());
                    return RedirectToPage("../Index");

                }
            }
            else
            {
                MensajePassword = "Rellena todo los campos.";
            }

            return Page();

        }
    }
}
