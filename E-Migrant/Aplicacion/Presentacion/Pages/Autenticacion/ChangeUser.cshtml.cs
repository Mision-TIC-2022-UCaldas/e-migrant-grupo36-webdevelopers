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
using Dominio;
using Persistencia;

namespace Presentacion.Pages.Autenticacion
{
    public class ChangeUserModel : PageModel
    {
        private Persistencia.AppContext _appContext;

        [BindProperty]
        
    
        public string Password{get;set;}

        [BindProperty]
        [EmailAddress]
    
        public string Mail{get;set;}
        
        [BindProperty]
        public string NewUsuario{get;set;}

        [BindProperty]
        public string NewUsuarioConfirm {get;set;}

        [BindProperty]
        public string Mensaje{get;set;}
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            _appContext = new Persistencia.AppContext();


            if(NewUsuario != null || Password!=null || NewUsuarioConfirm!=null || Mail != null)
            {
                
                var p = _appContext.Usuarios.FirstOrDefault( p => p.Correo == Mail);
                if (p == null)
                {
                    Mensaje = "Correo no registrado";
                }

                else if (!p.Contrasena.Equals(Password))
                {
                    Mensaje = "Contraseña incorrecta";

                }

                else if (!NewUsuario.Equals(NewUsuarioConfirm))
                {
                    //Console.WriteLine("Contraseña incorrecta");
                    Mensaje = "Los Caracteres no coinciden";
                }
                
                else
                {
                    HttpContext.Session.SetString("MiContrasena", Password);
                    HttpContext.Session.SetString("MiUsuario", NewUsuario);
                    HttpContext.Session.SetString("MiRol", p.Rol);
                    p.User= NewUsuario;
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