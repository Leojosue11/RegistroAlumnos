using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RegistroAlumnos.Models
{
    public class Alm_alumno
    {
        public int alm_id { get; set; }
        [Required]
        [StringLength(100)]
        public string alm_codigo { get; set; }
        [Required]
        [StringLength(300)]
        public string alm_nombre { get; set; }
        [Required]
        public int alm_edad { get; set; }
        [Required]
        [StringLength(100)]
        public string alm_sexo { get; set; }
        [Required]
        public int alm_id_grd { get; set; }
        
        [StringLength(300)]
        public string alm_observacion { get; set; }
    }
}