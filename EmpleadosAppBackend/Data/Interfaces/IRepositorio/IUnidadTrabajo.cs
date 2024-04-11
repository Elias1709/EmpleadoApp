using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces.IRepositorio
{
    public interface IUnidadTrabajo: IDisposable
    {
        ICargoRepositorio Cargo { get; }
        IEmpleadoRepositorio Empleado { get; }
        Task Guardar();
    }
}
