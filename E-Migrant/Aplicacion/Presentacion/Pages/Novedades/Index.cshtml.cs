using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
 
using Dominio;
using Persistencia;
 
namespace Presentacion.Pages.Novedades
{
    public class IndexModel : PageModel
    {
          //Crear un objeto para hacer uso de los repositorios
        private readonly IRepositorioNovedad _reponovedad;
        // modelo u objeto para transportar hacia MIndex.cshtml
        public IEnumerable<Novedad> Novedades {get;set;}
 
        // constructor
        public IndexModel(IRepositorioNovedad reponovedad)
        {
            this._reponovedad=reponovedad;
        }
 
        public void OnGet()
        {
            Novedades=_reponovedad.ListarNovedades();
        }
    }
}
