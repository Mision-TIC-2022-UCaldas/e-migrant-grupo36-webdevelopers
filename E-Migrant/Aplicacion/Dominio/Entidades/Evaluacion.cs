using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio
{
    public class Evaluacion
    {
        [Key]
        public int Id { get; set; }

        //Tipo de dato String para hacer select de Categoria
        // [Required(ErrorMessage="El campo {0} es obligatorio")]
        [Display (Name="Migrante")]
        public Migrante Migrante {get;set;}  

        //Tipo de dato Int para lograr validar el numero de inmigrantes
        [Required(ErrorMessage="El campo {0}, es obligatorio")]
        [Display (Name="Calificacion")]
        public string Calificacion{get;set;}

    }
}