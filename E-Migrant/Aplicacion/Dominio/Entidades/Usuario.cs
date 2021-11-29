using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Dominio.Entidades
{
    public class Usuario
    {
        [Key]
        public int Id {get;set;}

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string User{get;set;}

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Contrasena{get;set;}

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Rol{get;set;}

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [EmailAddress]
        public string Correo{get;set;}

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public bool Entro;
        
    }
}