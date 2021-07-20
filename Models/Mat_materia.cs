using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RegistroAlumnos.Models
{
    public class Mat_materia
    {
        public int mat_id{ get; set; }
        [Required]
        [StringLength(100)]
        public string mat_nombre { get; set; }
    }
}