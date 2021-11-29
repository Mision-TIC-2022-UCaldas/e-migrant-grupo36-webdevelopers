using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Persistencia;
using Dominio;

namespace Presentacion.Pages.Evaluaciones
{
   public class CrearModel : PageModel
    {
        private readonly IRepositorioEvaluacion repoEvaluacion;
         private readonly Persistencia.AppContext _appContext;

         public SelectList listaMigrantes{get; set;}
         
        [BindProperty]
        public Evaluacion Evalu{get; set;}
        [BindProperty]
        public int MigranteId{get; set;}
        //Constructor
        public CrearModel (IRepositorioEvaluacion repoevaluacion,Persistencia.AppContext appContext)
        {
            this.repoEvaluacion=repoevaluacion;
            _appContext =appContext;
        }

        //Se debe retornar algo ActionResult OnGet
        public IActionResult OnGet(int? evaluacionId)
        {
            var listaMigrantesDB = _appContext.Migrantes;
            listaMigrantes = new SelectList(listaMigrantesDB, nameof(Migrante.Id), nameof(Migrante.Nombres)); 

            if(evaluacionId.HasValue)
            {
                var evaluacionQuery = _appContext.Evaluaciones.Include(m => m.Migrante).FirstOrDefault(m => m.Id==evaluacionId);
                MigranteId = evaluacionQuery.Migrante.Id;
                Evalu = repoEvaluacion.GetEvaluacion(evaluacionId.Value);
            }
            else
            {
                Evalu = new Evaluacion();
            }
            
            if(Evalu==null)
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
            
            var listaMigrantesDB = _appContext.Migrantes;
            listaMigrantes = new SelectList(listaMigrantesDB, nameof(Migrante.Id), nameof(Migrante.Nombres));
            Migrante migran = _appContext.Migrantes.FirstOrDefault(d => d.Id == MigranteId);
            Evalu.Migrante = migran; 
            
            Evalu = repoEvaluacion.CrearEvaluacion(Evalu);
            return RedirectToPage("./Index");
        }
    }
}
