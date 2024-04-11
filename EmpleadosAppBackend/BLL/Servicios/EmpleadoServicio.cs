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
    public class EmpleadoServicio : IEmpleadoServicio
    {
        private readonly IUnidadTrabajo _unidadTrabajo;
        private readonly IMapper _mapper;

        public EmpleadoServicio(IUnidadTrabajo unidadTrabajo, IMapper mapper)
        {
            _unidadTrabajo = unidadTrabajo;
            _mapper = mapper;
        }

        public async Task Actualizar(EmpleadoDto modeloDto)
        {
            try
            {
                var empleadoDb = await _unidadTrabajo.Empleado.ObtenerPrimero(c => c.Id == modeloDto.Id);
                if (empleadoDb == null)
                
                    throw new TaskCanceledException("El empleado no existe");

                empleadoDb.Nombre = modeloDto.Nombre;
                empleadoDb.Apellido = modeloDto.Apellido;
                empleadoDb.NumeroIdentificacion = modeloDto.NumeroIdentificacion;
                empleadoDb.Telefono = modeloDto.Telefono;
                empleadoDb.Email = modeloDto.Email;
                empleadoDb.CargoId = modeloDto.CargoId;
                empleadoDb.Estado = modeloDto.Estado == 1 ? true : false;
                _unidadTrabajo.Empleado.Actualizar(empleadoDb);
                    await _unidadTrabajo.Guardar();
                
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<EmpleadoDto> Agregar(EmpleadoDto modeloDto)
        {
            try
            {
                Empleado empleado = new Empleado 
                {
                    Nombre = modeloDto.Nombre,
                    Apellido = modeloDto.Apellido,
                    NumeroIdentificacion = modeloDto.NumeroIdentificacion,
                    Telefono = modeloDto.Telefono,
                    Email = modeloDto.Email,
                    CargoId = modeloDto.CargoId,
                    Estado = modeloDto.Estado == 1 ? true : false,
                    FechaCreacion = DateTime.Now,
                    FechaActualizacion = DateTime.Now,
                };
                await _unidadTrabajo.Empleado.Agregar(empleado);
                await _unidadTrabajo.Guardar();
                if (empleado.Id == 0)
                    throw new TaskCanceledException("El empleado no se pudo agregar");
                return _mapper.Map<EmpleadoDto>(empleado);
            }
            catch (Exception )
            {
                throw;
            }
        }

        public async Task<IEnumerable<EmpleadoDto>> ObtenerTodos()
        {
            try
            {
                var lista = await _unidadTrabajo.Empleado.ObtenerTodos(incluirPropiedades:"Cargo",
                                  orderBy: c => c.OrderBy(c => c.Nombre ));
                return _mapper.Map<IEnumerable<EmpleadoDto>>(lista);
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
                var empleadoDb = await _unidadTrabajo.Empleado.ObtenerPrimero(c => c.Id == id);
                if (empleadoDb == null)
                
                    throw new TaskCanceledException("El empleado no existe");
                    _unidadTrabajo.Empleado.Remover(empleadoDb);
                    await _unidadTrabajo.Guardar();
                
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
