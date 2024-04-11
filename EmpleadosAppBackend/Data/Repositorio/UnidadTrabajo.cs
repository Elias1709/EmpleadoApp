using Data.Interfaces.IRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositorio
{
    public class UnidadTrabajo: IUnidadTrabajo
    {
        private readonly ApplicationDbContext _db;
        public ICargoRepositorio Cargo { get; private set; }
        public IEmpleadoRepositorio Empleado { get; private set; }

        public UnidadTrabajo(ApplicationDbContext db)
        {
            _db = db;
            Cargo = new CargoRepositorio(db);
            Empleado = new EmpleadoRepositorio(db);
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public async Task Guardar()
        {
            await _db.SaveChangesAsync();
        }
    }
}
