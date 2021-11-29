using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using Dominio;
using Persistencia;

namespace Presentacion.Pages.Colaboradoras
{
    public class IndexModel : PageModel
    {
          //Crear un objeto para hacer uso de los repositorios
        private readonly IRepositorioColaboradora _repocolaboradora;
        // modelo u objeto para transportar hacia MIndex.cshtml
        public IEnumerable<Colaboradora> Colaboradoras {get;set;}

        // constructor
        public IndexModel(IRepositorioColaboradora repocolaboradora)
        {
            this._repocolaboradora=repocolaboradora;
        }

        public void OnGet()
        {
            Colaboradoras=_repocolaboradora.ListarColaboradoras();
        }
    }
}
