using AutoMapper;
using BLL.Servicios.Interfaces;
using Data.Interfaces.IRepositorio;
using Models.DTOs;
using Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Servicios
{
    public class CargoServicio : ICargoServicio
    {
        private readonly IUnidadTrabajo _unidadTrabajo;
        private readonly IMapper _mapper;

        public CargoServicio(IUnidadTrabajo unidadTrabajo, IMapper mapper)
        {
            _unidadTrabajo = unidadTrabajo;
            _mapper = mapper;
        }

        public async Task Actualizar(CargoDto modeloDto)
        {
            try
            {
                var cargoDb = await _unidadTrabajo.Cargo.ObtenerPrimero(c => c.IdCargo == modeloDto.IdCargo);
                if (cargoDb == null)
                
                    throw new TaskCanceledException("El cargo no existe");

                    cargoDb.Nombre = modeloDto.Nombre;
                    cargoDb.Estado = modeloDto.Estado == 1 ? true : false;
                    _unidadTrabajo.Cargo.Actualizar(cargoDb);
                    await _unidadTrabajo.Guardar();
                
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<CargoDto> Agregar(CargoDto modeloDto)
        {
            try
            {
                Cargo cargo = new Cargo
                {
                    Nombre = modeloDto.Nombre,
                    Estado = modeloDto.Estado == 1 ? true : false,
                    FechaCreacion = DateTime.Now,
                    FechaActualizacion = DateTime.Now,
                };
                await _unidadTrabajo.Cargo.Agregar(cargo);
                await _unidadTrabajo.Guardar();
                if (cargo.IdCargo == 0)
                    throw new TaskCanceledException("El cargo no se pudo crear");
                return _mapper.Map<CargoDto>(cargo);
            }
            catch (Exception )
            {
                throw;
            }
        }

        public async Task<IEnumerable<CargoDto>> ObtenerTodos()
        {
            try
            {
                var lista = await _unidadTrabajo.Cargo.ObtenerTodos(
                                  orderBy: c => c.OrderBy(c => c.Nombre ));
                return _mapper.Map<IEnumerable<CargoDto>>(lista);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<CargoDto>> ObtenerActivos()
        {
            try
            {
                var lista = await _unidadTrabajo.Cargo.ObtenerTodos(x => x.Estado == true,
                                  orderBy: c => c.OrderBy(c => c.Nombre));
                return _mapper.Map<IEnumerable<CargoDto>>(lista);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task Remover(int id)
        {
            try
            {
                var cargoDb = await _unidadTrabajo.Cargo.ObtenerPrimero(c => c.IdCargo == id);
                if (cargoDb == null)
                
                    throw new TaskCanceledException("El cargo no existe");
                    _unidadTrabajo.Cargo.Remover(cargoDb);
                    await _unidadTrabajo.Guardar();
                
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
