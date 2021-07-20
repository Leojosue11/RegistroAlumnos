using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RegistroAlumnos.Models
{
    public class Grd_grado
    {
        public int grd_id { get; set; }
        [Required]
        [StringLength(100)]
        public string grd_nombre { get; set; }
    }
}