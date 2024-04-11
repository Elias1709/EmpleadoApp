using Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Servicios.Interfaces
{
    public interface ICargoServicio
    {
        Task<IEnumerable<CargoDto>> ObtenerTodos();
        Task<IEnumerable<CargoDto>> ObtenerActivos();
        Task<CargoDto> Agregar(CargoDto modeloDto);
        Task Actualizar(CargoDto modeloDto);
        Task Remover(int id);
    }
}
