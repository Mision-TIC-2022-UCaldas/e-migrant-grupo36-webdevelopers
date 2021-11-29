using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio
{
    public class Solicitud
    {
        [Key]
        public int Id { get; set; }

        //Tipo de dato String para hacer select de Categoria
        [Required(ErrorMessage="El campo {0} es obligatorio")]
        [Display (Name="Categoría")]
        public string Categoria {get;set;}  

        //Tipo de dato Int para lograr validar el numero de inmigrantes
        [Required(ErrorMessage="El campo {0}, es obligatorio")]
        [Display (Name="Descripción")]
        public string Descripcion{get;set;}

        //Tipo de dato String para hacer select de Prioridad
        [Required(ErrorMessage="El campo {0} es obligatorio")]
        [Display (Name="Prioridad")]
        public string Prioridad {get;set;}
    }
}