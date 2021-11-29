using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio
{
    public class Novedad
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage="El campo {0}, es obligatorio")]
        [Display (Name="Fecha de Novedad")]
        [DataType(DataType.Date)]
        public DateTime FechaNovedad {get;set;} 

        [Required(ErrorMessage="El campo {0}, es obligatorio")]
        [Display (Name="Numero de dias Activo")]
        public string NumDiasActivo{get;set;}

        [Required(ErrorMessage="El campo {0} es obligatorio")]
        [Display (Name="Texto Explicacion")]
        public string TextoExplicacion {get;set;}

        [Required(ErrorMessage="El campo {0} es obligatorio")]
        [Display (Name="Estado")]
        public string Estado {get;set;}
    }
}