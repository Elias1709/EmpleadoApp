using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs
{
    public class CargoDto
    {
        
        public int IdCargo { get; set; }

        [Required(ErrorMessage ="El campo Nombre es Requerido")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "El nombre debe tener minimo 2 y maximo 50 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo Estado es Requerido")]
        public int Estado { get; set; }
    }
}
