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

        public DateTime fechaNoveda {get;set;}

        public int NoDiasActiva;

        public string Explicacion;


    }
}