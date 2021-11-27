// importacion de librerias y referencias
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Dominio
{
    public class Medida
    {
        /*
        public Medida(int id, float estatura, float peso, float imc, int personaId)
        {
            this.Id = id;
            this.Estatura = estatura;
            this.Peso = peso;
            this.Imc = imc;
            this.PersonaId = personaId;

        } */

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]

        public float Estatura { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]


        public float Peso { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]

        public float Imc { get; set; }


        // llave foranea con la tabla Persona
        public Persona IdPersona { get; set; }

    }
}