// importacion de librerias y referencias
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Dominio
{
    public class Persona
    {
       /*   
        public Persona(int id, string nombres, string documento, string apellidos, string genero, string rH, string ePS, DateTime fechaNacimiento, string disciplina, string direccion, string telefono, string capacidadEspecial, int medidaId)
        {
            this.Id = id;
            this.Nombres = nombres;
            this.Documento = documento;
            this.Apellidos = apellidos;
            this.Genero = genero;
            this.RH = rH;
            this.EPS = ePS;
            this.FechaNacimiento = fechaNacimiento;
            this.Disciplina = disciplina;
            this.Direccion = direccion;
            this.Telefono = telefono;
            this.CapacidadEspecial = capacidadEspecial;
            this.MedidaId = medidaId;

        } */

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(40, ErrorMessage = "El campo {0} no puede superar los {1} caracteres")]
        [MinLength(4, ErrorMessage = "El campo {0} debe tener al menos {1} caracteres")]
        [RegularExpression("[a-zA-ZñÑáéíóúÁÉÍÓÚ ]*", ErrorMessage = "En el campo {0} se permiten solamente letras")]

        public string Nombres { get; set; }

        /*
        [Required(ErrorMessage="El campo {0} es obligatorio")]
        [MaxLength(40,ErrorMessage="El campo {0} no puede superar los {1} caracteres")]
        [MinLength(4,ErrorMessage="El campo {0} debe tener al menos {1} caracteres")]
        [RegularExpression("[0-9 ]*", ErrorMessage="En el campo {0} sólo se permiten números") ]

        public string Documento {get;set;}

        */

        /*
        [Required(ErrorMessage="El campo {0} es obligatorio")]
        [MaxLength(20,ErrorMessage="El campo {0} no puede superar los {1} caracteres")]
        [MinLength(4,ErrorMessage="El campo {0} debe tener al menos {1} caracteres")]
        [RegularExpression("[a-zA-ZñÑáéíóúÁÉÍÓÚ ]*",ErrorMessage="En el campo {0} se permiten solamente letras")]
    
        public string Apellidos{get;set;}
        [Required(ErrorMessage="El campo {0} es obligatorio")]
        [MaxLength(40,ErrorMessage="El campo {0} no puede superar los {1} caracteres")]
        [MinLength(4,ErrorMessage="El campo {0} debe tener al menos {1} caracteres")]
        [RegularExpression("[a-zA-ZñÑáéíóúÁÉÍÓÚ ]*",ErrorMessage="En el campo {0} se permiten solamente letras")]
        public string Genero{get;set;}
        [Required(ErrorMessage="El campo {0} es obligatorio")]
        [MaxLength(20,ErrorMessage="El campo {0} no puede superar los {1} caracteres")]
        [MinLength(4,ErrorMessage="El campo {0} debe tener al menos {1} caracteres")]        
        [RegularExpression("[a-zA-ZñÑáéíóúÁÉÍÓÚ ]*",ErrorMessage="En el campo {0} se permiten solamente letras")]
        public string RH{get;set;}
        [Required(ErrorMessage="El campo {0} es obligatorio")]
        [MaxLength(40,ErrorMessage="El campo {0} no puede superar los {1} caracteres")]
        [MinLength(4,ErrorMessage="El campo {0} debe tener al menos {1} caracteres")]
        [RegularExpression("[a-zA-ZñÑáéíóúÁÉÍÓÚ ]*",ErrorMessage="En el campo {0} se permiten solamente letras")]
        public string EPS{get;set;}
        [Required(ErrorMessage="El campo {0} es obligatorio")]
        [DataType(DataType.Date)]
        [Display (Name="Fecha de Nacimiento")]
        public DateTime FechaNacimiento {get;set;}
        [Required(ErrorMessage="El campo {0} es obligatorio")]
        [MaxLength(40,ErrorMessage="El campo {0} no puede superar los {1} caracteres")]
        [MinLength(4,ErrorMessage="El campo {0} debe tener al menos {1} caracteres")]
        [RegularExpression("[a-zA-ZñÑáéíóúÁÉÍÓÚ ]*",ErrorMessage="En el campo {0} se permiten solamente letras")]
        public string Disciplina{get;set;}
        [MaxLength(40,ErrorMessage="El campo {0} no puede superar los {1} caracteres")]
        [MinLength(5,ErrorMessage="El campo{0} debe tener al menos {1} caracteres")]
        public string Direccion{get;set;}
        [MaxLength(20,ErrorMessage="No puede superar los {1} caracteres")]
        [MinLength(6,ErrorMessage="El campo{0} debe tener al menos {1} caracteres")]
        [RegularExpression("[0-9]*", ErrorMessage="En el campo {0} sólo se permiten números") ]
        public string Telefono{get;set;}
        [MaxLength(20,ErrorMessage="No puede superar los {1} caracteres")]
        [MinLength(6,ErrorMessage="El campo{0} debe tener al menos {1} caracteres")]
        [RegularExpression("[a-zA-ZñÑáéíóúÁÉÍÓÚ ]*",ErrorMessage="En el campo {0} se permiten solamente letras")]
        [Display (Name="Capacidad Especial")]
        public string CapacidadEspecial {get; set;}
        */
        // llave foranea con la tabla Medida
       

    }
}