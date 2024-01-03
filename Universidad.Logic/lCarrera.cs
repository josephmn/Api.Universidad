using System.Data.SqlClient;
using Universidad.Data;
using Universidad.Model;
using Universidad.Model.DTO;

namespace Universidad.Logic
{
    public class lCarrera : conexion
    {
        public Result<mCarrera> Listar()
        {
            Result<mCarrera> _response = new Result<mCarrera>();

            using (SqlConnection con = new SqlConnection(cnx))
            {
                try
                {
                    con.Open();
                    dCarrera oCarrera = new dCarrera();
                    _response = oCarrera.Listar(con);
                    con.Close();
                }
                catch (SqlException ex)
                {
                    _response.Descripcion = "Error al listar datos.";
                    _response.Resultado = new List<mCarrera>();
                    _response.ExisteError = true;
                    _response.Errores = new List<string> { ex.Message };
                }
            }
            return _response;
        }

        public Result<mCarrera> Obtener(int id)
        {
            Result<mCarrera> _response = new Result<mCarrera>();

            using (SqlConnection con = new SqlConnection(cnx))
            {
                try
                {
                    if (id == 0)
                    {
                        _response.Descripcion = "El ID debe ser mayor que 0 para obtener una carrera.";
                        _response.ExisteError = true;
                        return _response;
                    }

                    con.Open();
                    dCarrera oCarrera = new dCarrera();
                    _response = oCarrera.Obtener(con, id);
                    con.Close();
                }
                catch (SqlException ex)
                {
                    _response.Descripcion = "Error al listar datos.";
                    _response.Resultado = new List<mCarrera>();
                    _response.ExisteError = true;
                    _response.Errores = new List<string> { ex.Message };
                }
            }
            return _response;
        }

        public Result<mCarrera> Registrar(mCarreraDTO carrera)
        {
            Result<mCarrera> _response = new Result<mCarrera>();

            using (SqlConnection con = new SqlConnection(cnx))
            {
                try
                {
                    if (string.IsNullOrEmpty(carrera.nombre_carrera))
                    {
                        _response.Descripcion = "El nombre debe existir y no puede estar vacío.";
                        _response.ExisteError = true;
                        return _response;
                    }

                    if (string.IsNullOrEmpty(carrera.codigo_carrera))
                    {
                        _response.Descripcion = "El código debe existir y no puede estar vacío.";
                        _response.ExisteError = true;
                        return _response;
                    }

                    con.Open();
                    dCarrera oCarrera = new dCarrera();
                    _response = oCarrera.Registrar(con, carrera);
                    con.Close();
                }
                catch (SqlException ex)
                {
                    _response.Descripcion = "Error al registrar facultad.";
                    _response.ExisteError = true;
                    _response.Errores = new List<string> { ex.Message };
                }
            }
            return _response;
        }

        public Result<mCarrera> Actualizar(int id, mCarreraDTO carrera)
        {
            Result<mCarrera> _response = new Result<mCarrera>();

            using (SqlConnection con = new SqlConnection(cnx))
            {
                try
                {
                    if (id == 0)
                    {
                        _response.Descripcion = "El ID debe ser mayor que 0 para actualizar la facultad.";
                        _response.ExisteError = true;
                        return _response;
                    }

                    if (string.IsNullOrEmpty(carrera.nombre_carrera))
                    {
                        carrera.nombre_carrera = string.Empty;
                        //_response.Descripcion = "El nombre debe existir y no puede estar vacío.";
                        //_response.ExisteError = true;
                        //return _response;
                    }

                    if (string.IsNullOrEmpty(carrera.codigo_carrera))
                    {
                        carrera.codigo_carrera = string.Empty;
                        //_response.Descripcion = "El código debe existir y no puede estar vacío.";
                        //_response.ExisteError = true;
                        //return _response;
                    }

                    if (carrera.estado_carrera < 0 || carrera.estado_carrera > 1)
                    {
                        _response.Descripcion = "Estado no válido, este debe ser: (1) Activo y (0) inactivo.";
                        _response.ExisteError = true;
                        return _response;
                    }

                    con.Open();
                    dCarrera oCarrera = new dCarrera();
                    _response = oCarrera.Actualizar(con, id, carrera);

                    con.Close();
                }
                catch (SqlException ex)
                {
                    _response.Descripcion = "Error al actualizar facultad.";
                    _response.ExisteError = true;
                    _response.Errores = new List<string> { ex.Message };
                }
            }
            return _response;
        }

        public Result<mCarrera> Eliminar(int id)
        {
            Result<mCarrera> _response = new Result<mCarrera>();

            using (SqlConnection con = new SqlConnection(cnx))
            {
                try
                {
                    if (id == 0)
                    {
                        _response.Descripcion = "El ID debe ser mayor que 0 para eliminar una facultad.";
                        _response.ExisteError = true;
                        return _response;
                    }

                    con.Open();
                    dCarrera oCarrera = new dCarrera();
                    _response = oCarrera.Eliminar(con, id);
                    con.Close();
                }
                catch (SqlException ex)
                {
                    _response.Descripcion = "Error al eliminar la facultad.";
                    _response.Resultado = new List<mCarrera>();
                    _response.ExisteError = true;
                    _response.Errores = new List<string> { ex.Message };
                }
            }
            return _response;
        }

        public Result<mCarrera> Recuperar(int id)
        {
            Result<mCarrera> _response = new Result<mCarrera>();

            using (SqlConnection con = new SqlConnection(cnx))
            {
                try
                {
                    if (id == 0)
                    {
                        _response.Descripcion = "El ID debe ser mayor que 0 para recuperar la facultad.";
                        _response.ExisteError = true;
                        return _response;
                    }

                    con.Open();
                    dCarrera oCarrera = new dCarrera();
                    _response = oCarrera.Recuperar(con, id);

                    con.Close();
                }
                catch (SqlException ex)
                {
                    _response.Descripcion = "Error al recuperar la facultad.";
                    _response.ExisteError = true;
                    _response.Errores = new List<string> { ex.Message };
                }
            }
            return _response;
        }
    }
}
