using BLL.Servicios.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs;
using System.Net;

namespace API.Controllers
{
    [Authorize(Policy = "AdminRol")]
    public class EmpleadoController : BaseApiController
    {
        private readonly IEmpleadoServicio _empleadooServicio;
        private ApiResponse _response;

        public EmpleadoController(IEmpleadoServicio empleadooServicio)
        {
            _empleadooServicio = empleadooServicio;
            _response = new();
            
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                _response.Resultado = await _empleadooServicio.ObtenerTodos();
                _response.IsExitoso = true;
                _response.StatusCode = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                _response.IsExitoso = false;
                _response.Mensaje = ex.Message;
                _response.StatusCode = HttpStatusCode.BadRequest;
            }
            return Ok(_response);
        }

        [HttpPost]
        public async Task <IActionResult> Crear(EmpleadoDto modeloDto)
        {
            try
            {
                await _empleadooServicio.Agregar(modeloDto);
                _response.IsExitoso = true;
                _response.StatusCode = HttpStatusCode.Created;
            }
            catch (Exception ex)
            {

                _response.IsExitoso = false;
                _response.Mensaje = ex.Message;
                _response.StatusCode = HttpStatusCode.BadRequest;
            }
            return Ok(_response);
        }

        [HttpPut]
        public async Task <IActionResult> Editar(EmpleadoDto modeloDto)
        {
            try
            {
                await _empleadooServicio.Actualizar(modeloDto);
                _response.IsExitoso = true;
                _response.StatusCode = HttpStatusCode.NoContent;
            }
            catch (Exception ex)
            {

                _response.IsExitoso= false;
                _response.Mensaje= ex.Message;
                _response.StatusCode = HttpStatusCode.BadRequest;
            }
            return Ok(_response);   
        }

        [HttpDelete("{id:int}")]
        public async Task <IActionResult> Eliminar(int id)
        {
            try
            {
                await _empleadooServicio.Remover(id);
                _response.IsExitoso = true;
                _response.StatusCode= HttpStatusCode.NoContent;
            }
            catch (Exception ex)
            {

                _response.IsExitoso = false;
                _response.Mensaje = ex.Message;
                _response.StatusCode = HttpStatusCode.BadRequest;
            }
            return Ok(_response);
        }
    }
}
