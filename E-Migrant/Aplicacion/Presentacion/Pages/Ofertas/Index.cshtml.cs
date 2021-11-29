using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using Dominio;
using Persistencia;

namespace Presentacion.Pages.Ofertas
{
    public class IndexModel : PageModel
    {
          //Crear un objeto para hacer uso de los repositorios
        private readonly IRepositorioOferta _repooferta;
        // modelo u objeto para transportar hacia MIndex.cshtml
        public IEnumerable<Oferta> Ofertas {get;set;}

        // constructor
        public IndexModel(IRepositorioOferta repooferta)
        {
            this._repooferta=repooferta;
        }

        public void OnGet()
        {
            Ofertas=_repooferta.ListarOfertas();
        }
    }
}
