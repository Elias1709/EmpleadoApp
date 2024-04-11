using Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Servicios.Interfaces
{
    public interface IEmpleadoServicio
    {
        Task<IEnumerable<EmpleadoDto>> ObtenerTodos();
        Task<EmpleadoDto> Agregar(EmpleadoDto modeloDto);
        Task Actualizar(EmpleadoDto modeloDto);
        Task Remover(int id);
    }
}
