using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Universidad.Logic;
using Universidad.Model;
using Universidad.Model.DTO;

namespace Api.Universidad.Controllers
{

    [Route("v1/Facultad")]
    [ApiController]
    public class FacultadController : Controller
    {
        [HttpGet("Listar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "Obtiene la lista de facultades", Description = "Obtiene la lista de facultades disponibles con estado (1) Activos.")]
        public ActionResult<Result<mFacultad>> Lista()
        {
            Result<mFacultad> _response = new Result<mFacultad>();
            lFacultad _logic = new lFacultad();

            try
            {
                _response = _logic.Listar();
                _response.Resultado = _response.Resultado == null ? new List<mFacultad>() : _response.Resultado;
            }
            catch (Exception ex)
            {
                _response = new Result<mFacultad>
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
        [SwaggerOperation(Summary = "Obtiene una facultad por su ID", Description = "Obtiene la facultad disponible y activa.")]
        public ActionResult<Result<mFacultad>> Obtener(int id)
        {
            Result<mFacultad> _response = new Result<mFacultad>();
            lFacultad _logic = new lFacultad();

            try
            {
                _response = _logic.Obtener(id);
                _response.Resultado = _response.Resultado == null ? new List<mFacultad>() : _response.Resultado;
            }
            catch (Exception ex)
            {
                _response = new Result<mFacultad>
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
        [SwaggerOperation(Summary = "Registrar una facultad", Description = "Método para registrar una nueva facultad.")]
        public ActionResult<Result<mFacultad>> Registrar([FromBody] mFacultadDTO facultad)
        {
            Result<mFacultad> _response = new Result<mFacultad>();
            lFacultad _logic = new lFacultad();

            try
            {
                _response = _logic.Registrar(facultad);
                return StatusCode(StatusCodes.Status201Created, _response);
            }
            catch (Exception ex)
            {
                _response = new Result<mFacultad>
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
        [SwaggerOperation(Summary = "Actualizar una facultad", Description = "Método para actualizar una facultad.")]
        public ActionResult<Result<mFacultad>> Actualizar(int id, [FromBody] mFacultadDTO facultad)
        {
            Result<mFacultad> _response = new Result<mFacultad>();
            lFacultad _logic = new lFacultad();

            try
            {
                _response = _logic.Actualizar(id, facultad);

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
                _response = new Result<mFacultad>
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
        [SwaggerOperation(Summary = "Eliminar una facultad", Description = "Método para eliminar una nueva facultad, aquí solo se inactivan (0).")]
        public ActionResult<Result<mFacultad>> Eliminar(int id)
        {
            Result<mFacultad> _response = new Result<mFacultad>();
            lFacultad _logic = new lFacultad();

            try
            {
                _response = _logic.Eliminar(id);
                _response.Resultado = _response.Resultado == null ? new List<mFacultad>() : _response.Resultado;
            }
            catch (Exception ex)
            {
                _response = new Result<mFacultad>
                {
                    Descripcion = "Error al eliminar información",
                    ExisteError = true,
                    Errores = new List<string>() { ex.Message },
                };

            }

            return Ok(_response);
        }

        [HttpPut("Eliminar/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)] // Código de estado 200 para indicar una actualización exitosa
        [ProducesResponseType(StatusCodes.Status400BadRequest)] // Código de estado 400 para indicar una solicitud incorrecta
        [SwaggerOperation(Summary = "Eliminar una facultad y puede mover las carreras a otra facultad", Description = "Método para eliminar una facultad, estas se mueven las carreras a otra facultad.")]
        public ActionResult<Result<mFacultad>> Eliminar(int id, [FromBody] mCarreraMoverDTO carrera)
        {
            Result<mFacultad> _response = new Result<mFacultad>();
            lFacultad _logic = new lFacultad();

            try
            {
                _response = _logic.Eliminar(id, carrera);

                if (_response.ExisteError)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, _response);
                }

                return StatusCode(StatusCodes.Status200OK, _response);
            }
            catch (Exception ex)
            {
                _response = new Result<mFacultad>
                {
                    Descripcion = "Error al intentar eliminar",
                    ExisteError = true,
                    Errores = new List<string>() { ex.Message },
                };

                return StatusCode(StatusCodes.Status400BadRequest, _response);
            }
        }

        [HttpPut("Recuperar/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "Recuperar una facultad eliminada", Description = "Método para recuperar una facultad, aquí solo se ingresa el código autogenerado (identity)")]
        public ActionResult<Result<mFacultad>> Recuperar(int id)
        {
            Result<mFacultad> _response = new Result<mFacultad>();
            lFacultad _logic = new lFacultad();

            try
            {
                _response = _logic.Recuperar(id);
                _response.Resultado = _response.Resultado == null ? new List<mFacultad>() : _response.Resultado;
            }
            catch (Exception ex)
            {
                _response = new Result<mFacultad>
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
