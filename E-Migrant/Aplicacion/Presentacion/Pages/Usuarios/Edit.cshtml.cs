using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Persistencia;
using Dominio.Entidades;

namespace Presentacion.Pages.Usuarios
{
    public class EditModel : PageModel
    {
        private readonly IRepositorioUsuario repositorioUsuario;

        [BindProperty]
        public Usuario Usuario {get; set;}

        public EditModel(IRepositorioUsuario repositorioUsuario)
        {
            this.repositorioUsuario = repositorioUsuario;
        }

        public IActionResult OnGet(int? usuarioId)
        {
            if(usuarioId.HasValue)
            {
                Usuario = repositorioUsuario.GetUsuarioID(usuarioId.Value);
            }
            else
            {
                Usuario = new Usuario();
            }
            
            if(Usuario==null)
            {
                return RedirectToPage("./NotFound");
            }
            else
            return Page();
        }

        public IActionResult OnPost()
        {
            
            if(!ModelState.IsValid)
            {
                return Page();
            }

            if(Usuario.Id > 0)
            {
                Usuario = repositorioUsuario.UpdateUsuario(Usuario);
            }
            else
            {
                Usuario = repositorioUsuario.AddUsuario(Usuario);
            }
            return RedirectToPage("./List");
        }
    }
}
