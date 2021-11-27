using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio
{
    public class EntidadColaboradora
    {
        [Key]
        public int Id{get;set;}


        [Required(ErrorMessage="El campo {0}, es obligatorio")]
        [MaxLength(25, ErrorMessage="El campo {0} no puede superar los {1} cartacteres")]
        [MinLength(5, ErrorMessage="El campo {0} debe tener al menos {1} cartacteres")]  
        [RegularExpression("[a-zA-ZñÑáéíóúÁÉÍÓÚ ]*",ErrorMessage="En el campo {0} se permiten solamente letras")]
        [Display (Name="Razón social")]
        public string RazonSocial{get;set;}


        [Required(ErrorMessage="El campo {0}, es obligatorio")]
        [RegularExpression("[0-9]*",ErrorMessage="En el campo {0} se permiten solamente numeros")]
        [Display (Name="NIT")]
        public string Nit {get;set;}


        [MaxLength(40,ErrorMessage="El campo {0} no puede superar los {1} caracteres")]
        [MinLength(5,ErrorMessage="El campo{0} debe tener al menos {1} caracteres")]
        [Display (Name="Dirección actual")]
        public string Direccion{get;set;}

             
        [MaxLength(20,ErrorMessage="No puede superar los {1} caracteres")]
        [MinLength(6,ErrorMessage="El campo{0} debe tener al menos {1} caracteres")]
        [RegularExpression("[a-zA-ZñÑáéíóúÁÉÍÓÚ ]*",ErrorMessage="En el campo {0} se permiten solamente letras")]
        [Display (Name="Ciudad")]
        public string Ciudad {get; set;}


        [MaxLength(40,ErrorMessage="El campo {0} no puede superar los {1} caracteres")]
        [MinLength(5,ErrorMessage="El campo{0} debe tener al menos {1} caracteres")]
        [Display (Name="Correo electrónico")]
        public string CorreoElectronico{get;set;}


        [MaxLength(100,ErrorMessage="El campo {0} no puede superar los {1} caracteres")]
        [MinLength(5,ErrorMessage="El campo{0} debe tener al menos {1} caracteres")]
        [Display (Name="Página Web")]
        public string PaginaWeb{get;set;}


        [Required(ErrorMessage="El campo {0}, es obligatorio")]
        [MaxLength(25, ErrorMessage="El campo {0} no puede superar los {1} cartacteres")]
        [MinLength(4, ErrorMessage="El campo {0} debe tener al menos {1} cartacteres")]  
        [RegularExpression("[a-zA-ZñÑáéíóúÁÉÍÓÚ ]*",ErrorMessage="En el campo {0} se permiten solamente letras")]
        public string Sector {get;set;}


        [Required(ErrorMessage="El campo {0}, es obligatorio")]
        [MaxLength(25, ErrorMessage="El campo {0} no puede superar los {1} cartacteres")]
        [MinLength(4, ErrorMessage="El campo {0} debe tener al menos {1} cartacteres")]  
        [RegularExpression("[a-zA-ZñÑáéíóúÁÉÍÓÚ ]*",ErrorMessage="En el campo {0} se permiten solamente letras")]
        public string TipoServicios {get;set;}

/*

        // propiedad navigacional hacia la tabla Entrenador
        public Entrenador Entrenador {get;set;}
        //llave foranea de Patrocinador
        [Display (Name="Patrocinador")]
        public int PatrocinadorId {get;set;}
        // propiedad navigacional hacia la tabla intermedia TorneoEquipo
        public List<TorneoEquipo> TorneoEquipos {get;set;}
        //propiedad navigacional hacia la tabla deportistas
        public List<Deportista> Deportista {get;set;}

        */
    }
}