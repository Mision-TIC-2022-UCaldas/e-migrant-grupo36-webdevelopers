using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio
{
    public class Oferta
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(40, ErrorMessage = "El campo {0} no puede superar los {1} caracteres")]
        [MinLength(4, ErrorMessage = "El campo {0} debe tener al menos {1} caracteres")]
        [RegularExpression("[a-zA-ZñÑáéíóúÁÉÍÓÚ ]*", ErrorMessage = "En el campo {0} se permiten solamente letras")]
        [Display (Name="Nombres")]
        public string Nombre {get;set;}

        //Tipo de dato Int para lograr validar el numero de inmigrantes
        [Required(ErrorMessage="El campo {0}, es obligatorio")]
        [Display (Name="Máximo de migrantes por servicio")]
        public int MaxMigrantes{get;set;}

        //Tipo de dato Date - Con la finalidad de que se pueda escoger año, mes y dia
        [Required(ErrorMessage="El campo {0}, es obligatorio")]
        [DataType(DataType.Date)]
        public DateTime FechaInicio {get;set;}

        //Tipo de dato Date - Con la finalidad de que se pueda escoger año, mes y dia
        [Required(ErrorMessage="El campo {0}, es obligatorio")]
        [DataType(DataType.Date)]
        public DateTime FechaFinal {get;set;}

        [Required(ErrorMessage="El campo {0}, es obligatorio")]
        public string Estado {get;set;}
        
        [Required(ErrorMessage="El campo {0}, es obligatorio")]
        public int ColaboradoraId{get;set;}
    }
}