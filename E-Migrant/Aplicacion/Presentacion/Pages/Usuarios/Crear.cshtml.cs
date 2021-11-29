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
    public class CrearModel : PageModel
    {
        private readonly IRepositorioUsuario repositorioUsuario;

        [BindProperty]
        public Usuario Usuario { get; set; }

        public CrearModel(IRepositorioUsuario repositorioUsuario)
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
                    repositorioUsuario.AddUsuario(Usuario);
                    return RedirectToPage("./List");
           
            }
    }
}
