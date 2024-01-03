using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Universidad.Logic;
using Universidad.Model;
using Universidad.Model.DTO;

namespace Api.Universidad.Controllers
{
    [Route("v1/Carrera")]
    [ApiController]
    public class CarreraController : Controller
    {
        [HttpGet("Listar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "Obtiene la lista de carreras", Description = "Obtiene la lista de carreras disponibles con estado (1) Activos.")]
        public ActionResult<Result<mCarrera>> Lista()
        {
            Result<mCarrera> _response = new Result<mCarrera>();
            lCarrera _logic = new lCarrera();

            try
            {
                _response = _logic.Listar();
                _response.Resultado = _response.Resultado == null ? new List<mCarrera>() : _response.Resultado;
            }
            catch (Exception ex)
            {
                _response = new Result<mCarrera>
                {
                    Descripcion = "Error al listar información",
                    ExisteError = true,
                    Errores = new List<string>() { ex.Message },
                };

            }

            return Ok(_response);
        }

        [HttpGet("Obtener/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "Obtiene una carrera por su ID", Description = "Obtiene la carrera disponible y activa.")]
        public ActionResult<Result<mFacultad>> Obtener(int id)
        {
            Result<mCarrera> _response = new Result<mCarrera>();
            lCarrera _logic = new lCarrera();

            try
            {
                _response = _logic.Obtener(id);
                _response.Resultado = _response.Resultado == null ? new List<mCarrera>() : _response.Resultado;
            }
            catch (Exception ex)
            {
                _response = new Result<mCarrera>
                {
                    Descripcion = "Error al obtener información",
                    ExisteError = true,
                    Errores = new List<string>() { ex.Message },
                };

            }

            return Ok(_response);
        }

        [HttpPost("Registrar")]
        [ProducesResponseType(StatusCodes.Status201Created)] // Código de estado 201 para indicar la creación exitosa
        [ProducesResponseType(StatusCodes.Status400BadRequest)] // Código de estado 400 para indicar una solicitud incorrecta
        [SwaggerOperation(Summary = "Registrar una carrera", Description = "Método para registrar una nueva carrera.")]
        public ActionResult<Result<mCarrera>> Registrar([FromBody] mCarreraDTO carrera)
        {
            Result<mCarrera> _response = new Result<mCarrera>();
            lCarrera _logic = new lCarrera();

            try
            {
                _response = _logic.Registrar(carrera);
                return StatusCode(StatusCodes.Status201Created, _response);
            }
            catch (Exception ex)
            {
                _response = new Result<mCarrera>
                {
                    Descripcion = "Error al intentar registrar",
                    ExisteError = true,
                    Errores = new List<string>() { ex.Message },
                };

                return StatusCode(StatusCodes.Status400BadRequest, _response);
            }
        }

        [HttpPut("Actualizar/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)] // Código de estado 200 para indicar una actualización exitosa
        [ProducesResponseType(StatusCodes.Status400BadRequest)] // Código de estado 400 para indicar una solicitud incorrecta
        [SwaggerOperation(Summary = "Actualizar una carrera", Description = "Método para actualizar una carrera.")]
        public ActionResult<Result<mCarrera>> Actualizar(int id, [FromBody] mCarreraDTO carrera)
        {
            Result<mCarrera> _response = new Result<mCarrera>();
            lCarrera _logic = new lCarrera();

            try
            {
                _response = _logic.Actualizar(id, carrera);

                if (_response.ExisteError)
                {
                    // Manejar el caso en el que la actualización no fue exitosa
                    return StatusCode(StatusCodes.Status400BadRequest, _response);
                }

                // Actualización exitosa
                return StatusCode(StatusCodes.Status200OK, _response);
            }
            catch (Exception ex)
            {
                _response = new Result<mCarrera>
                {
                    Descripcion = "Error al intentar actualizar",
                    ExisteError = true,
                    Errores = new List<string>() { ex.Message },
                };

                return StatusCode(StatusCodes.Status400BadRequest, _response);
            }
        }

        [HttpDelete("Eliminar/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "Eliminar una carrera", Description = "Método para eliminar una nueva carrera, aquí solo se inactivan (0).")]
        public ActionResult<Result<mCarrera>> Eliminar(int id)
        {
            Result<mCarrera> _response = new Result<mCarrera>();
            lCarrera _logic = new lCarrera();

            try
            {
                _response = _logic.Eliminar(id);
                _response.Resultado = _response.Resultado == null ? new List<mCarrera>() : _response.Resultado;
            }
            catch (Exception ex)
            {
                _response = new Result<mCarrera>
                {
                    Descripcion = "Error al eliminar información",
                    ExisteError = true,
                    Errores = new List<string>() { ex.Message },
                };

            }

            return Ok(_response);
        }

        [HttpPut("Recuperar/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "Recuperar una carrera eliminada", Description = "Método para recuperar una carrera, aquí solo se ingresa el código autogenerado (identity)")]
        public ActionResult<Result<mCarrera>> Recuperar(int id)
        {
            Result<mCarrera> _response = new Result<mCarrera>();
            lCarrera _logic = new lCarrera();

            try
            {
                _response = _logic.Recuperar(id);
                _response.Resultado = _response.Resultado == null ? new List<mCarrera>() : _response.Resultado;
            }
            catch (Exception ex)
            {
                _response = new Result<mCarrera>
                {
                    Descripcion = "Error al recuperar información",
                    ExisteError = true,
                    Errores = new List<string>() { ex.Message },
                };

            }

            return Ok(_response);
        }
    }
}
