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
    public class JoinInModel : PageModel
    {
        private readonly IRepositorioUsuario repositorioUsuario;

        [BindProperty]
        public Usuario Usuario { get; set; }


        public JoinInModel(IRepositorioUsuario repositorioUsuario)
        {
            this.repositorioUsuario = repositorioUsuario;
        }

        public IActionResult OnGet()
        {
            if(!ModelState.IsValid){
                return Page();
                }
                Usuario = new Usuario();
                if(Usuario == null){
                    return RedirectToPage("../Error");
                }else{
                    return Page();
                }
            }

            public IActionResult OnPost()
            {       
                HttpContext.Session.SetString("MiMail", Usuario.Correo);
                HttpContext.Session.SetString("MiUsuario", Usuario.User);
                HttpContext.Session.SetString("MiRol", Usuario.Rol);
                HttpContext.Session.SetString("MiId", Usuario.Id.ToString());
                repositorioUsuario.ResgistrarUsuario(Usuario);
                return RedirectToPage("../Index");
           
            }
    }
}
