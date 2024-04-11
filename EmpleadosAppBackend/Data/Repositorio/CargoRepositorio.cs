using Data.Interfaces.IRepositorio;
using Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositorio
{
    public class CargoRepositorio : Repositorio<Cargo>, ICargoRepositorio
    {
        private readonly ApplicationDbContext _db;

        public CargoRepositorio(ApplicationDbContext db) : base(db) 
        {
            _db = db;
        }

        public void Actualizar(Cargo cargo)
        {
            var cargoDb = _db.Cargos.FirstOrDefault(e => e.IdCargo == cargo.IdCargo);
            if (cargoDb != null)
            {
                cargoDb.Nombre = cargo.Nombre;
                cargoDb.Estado = cargo.Estado;
                cargoDb.FechaActualizacion = DateTime.Now;
                _db.SaveChanges();
            }
        }
    }
}
