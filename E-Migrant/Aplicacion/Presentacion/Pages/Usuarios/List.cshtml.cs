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
    public class ListModel : PageModel
    {
        private readonly IRepositorioUsuario repositorioUsuario;
        public IEnumerable<Usuario> Usuarios{get; set;}
        public ListModel(IRepositorioUsuario repositorioUsuario)
        {
            this.repositorioUsuario = repositorioUsuario;
        }
        
        public void OnGet()
        {
            Usuarios = repositorioUsuario.GetAllUsuarios();

            Page();
        }
    }
}