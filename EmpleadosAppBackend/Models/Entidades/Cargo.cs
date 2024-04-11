using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entidades
{
    public class Cargo
    {
        [Key]
        public int IdCargo { get; set; }

        [Required]
        [StringLength(50, MinimumLength =2, ErrorMessage ="El nombre debe tener minimo 2 y maximo 50 caracteres")]
        public string Nombre { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaActualizacion { get; set; }

    }
}
