using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Tarea5.Models
{
    public class Empleado
    {
        [Key]
        public int Codigo { get; set; }
        [Required]
        public string Nombre {get; set; }
        [Required]
        public DateTime FechaIngreso { get; set; }
        [Required]
        public double SueldoNeto { get; set; }



    }
}