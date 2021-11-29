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
    public class EliminarModel : PageModel
    {
        private readonly IRepositorioUsuario repositorioUsuario;
        public Usuario Usuario { get; set; }
        public EliminarModel(IRepositorioUsuario repositorioUsuario)
        {
            this.repositorioUsuario = repositorioUsuario;
        }
        public IActionResult OnGet(int idUsuario)
        {
            Usuario=repositorioUsuario.DeleteUsuario(idUsuario);
            return Page();
            
        }
    }
}