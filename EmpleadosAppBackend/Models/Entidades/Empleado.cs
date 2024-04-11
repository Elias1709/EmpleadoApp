using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entidades
{
    public class Empleado
    {
        [Key]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "El campo nombre es requerido")]
        [StringLength(80, MinimumLength =2, ErrorMessage = "El campo nombre debe tener un minimo de 2 y un maximo de 80 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo apellido es requerido")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "El campo apellido debe tener un minimo de 2 y un maximo de 50 caracteres")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "El campo Identificacion es requerido")]
        public string NumeroIdentificacion { get; set; }

        public string Telefono { get; set; }

        public string Email { get; set; }

        [Required(ErrorMessage = "El campo cargo es requerido")]
        public int CargoId { get; set; }

        [ForeignKey("CargoId")]
        public Cargo Cargo { get; set; }

        public bool Estado {  get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaActualizacion { get; set; }


    }
}
