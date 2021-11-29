using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio.Entidades;
using Persistencia;

namespace Presentacion.Pages.Usuarios
{
    public class DetailModel : PageModel
    {
        private readonly IRepositorioUsuario repositorioUsuario;
        public Usuario Usuario { get; set; }

        public DetailModel(IRepositorioUsuario repositorioUsuario)
        {
            this.repositorioUsuario = repositorioUsuario;
        }

        public IActionResult OnGet(string correo)
        {
            Usuario = repositorioUsuario.GetUsuario(correo);
            if (Usuario == null)
            {
                return RedirectToPage("./NotFound");
            }
            else
            {
                return Page();

            }
        }
    }
}
