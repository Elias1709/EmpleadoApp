using Data.Interfaces.IRepositorio;
using Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositorio
{
    public class EmpleadoRepositorio : Repositorio<Empleado>, IEmpleadoRepositorio
    {
        private readonly ApplicationDbContext _db;

        public EmpleadoRepositorio(ApplicationDbContext db) : base(db) 
        {
            _db = db;
        }

        public void Actualizar(Empleado empleado)
        {
            var empleadoDb = _db.Empleados.FirstOrDefault(e => e.Id == empleado.Id);
            if (empleadoDb != null)
            {
                empleadoDb.Nombre = empleado.Nombre;
                empleadoDb.Apellido = empleado.Apellido;
                empleadoDb.NumeroIdentificacion = empleado.NumeroIdentificacion;
                empleadoDb.Telefono = empleado.Telefono;
                empleadoDb.Email = empleado.Email;
                empleadoDb.CargoId = empleado.CargoId;
                empleadoDb.FechaActualizacion = DateTime.Now;
                _db.SaveChanges();
            }
        }
    }
}
