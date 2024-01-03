using System.Data.SqlClient;
using Universidad.Data;
using Universidad.Model;
using Universidad.Model.DTO;

namespace Universidad.Logic
{
    public class lFacultad : conexion
    {
        public Result<mFacultad> Listar()
        {
            Result<mFacultad> _response = new Result<mFacultad>();

            using (SqlConnection con = new SqlConnection(cnx))
            {
                try
                {
                    con.Open();
                    dFacultad oFacultad = new dFacultad();
                    _response = oFacultad.Listar(con);
                    con.Close();
                }
                catch (SqlException ex)
                {
                    _response.Descripcion = "Error al listar datos.";
                    _response.Resultado = new List<mFacultad>();
                    _response.ExisteError = true;
                    _response.Errores = new List<string> { ex.Message };
                }
            }
            return _response;
        }

        public Result<mFacultad> Obtener(int id)
        {
            Result<mFacultad> _response = new Result<mFacultad>();

            using (SqlConnection con = new SqlConnection(cnx))
            {
                try
                {
                    if (id == 0)
                    {
                        _response.Descripcion = "El ID debe ser mayor que 0 para obtener una facultad.";
                        _response.ExisteError = true;
                        return _response;
                    }

                    con.Open();
                    dFacultad oFacultad = new dFacultad();
                    _response = oFacultad.Obtener(con, id);
                    con.Close();
                }
                catch (SqlException ex)
                {
                    _response.Descripcion = "Error al listar datos.";
                    _response.Resultado = new List<mFacultad>();
                    _response.ExisteError = true;
                    _response.Errores = new List<string> { ex.Message };
                }
            }
            return _response;
        }

        public Result<mFacultad> Registrar(mFacultadDTO facultad)
        {
            Result<mFacultad> _response = new Result<mFacultad>();

            using (SqlConnection con = new SqlConnection(cnx))
            {
                try
                {
                    if (string.IsNullOrEmpty(facultad.nombre_facultad))
                    {
                        _response.Descripcion = "El nombre debe existir y no puede estar vacío.";
                        _response.ExisteError = true;
                        return _response;
                    }

                    if (string.IsNullOrEmpty(facultad.codigo_facultad))
                    {
                        _response.Descripcion = "El código debe existir y no puede estar vacío.";
                        _response.ExisteError = true;
                        return _response;
                    }

                    con.Open();
                    dFacultad oFacultad = new dFacultad();
                    _response = oFacultad.Registrar(con, facultad);
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

        public Result<mFacultad> Actualizar(int id, mFacultadDTO facultad)
        {
            Result<mFacultad> _response = new Result<mFacultad>();

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

                    if (string.IsNullOrEmpty(facultad.nombre_facultad))
                    {
                        facultad.nombre_facultad = string.Empty;
                        //_response.Descripcion = "El nombre debe existir y no puede estar vacío.";
                        //_response.ExisteError = true;
                        //return _response;
                    }

                    if (string.IsNullOrEmpty(facultad.codigo_facultad))
                    {
                        facultad.codigo_facultad= string.Empty;
                        //_response.Descripcion = "El código debe existir y no puede estar vacío.";
                        //_response.ExisteError = true;
                        //return _response;
                    }

                    if (facultad.estado_facultad < 0 || facultad.estado_facultad > 1)
                    {
                        _response.Descripcion = "Estado no válido, este debe ser: (1) Activo y (0) inactivo.";
                        _response.ExisteError = true;
                        return _response;
                    }

                    con.Open();
                    dFacultad oFacultad = new dFacultad();
                    _response = oFacultad.Actualizar(con, id, facultad);

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

        public Result<mFacultad> Eliminar(int id)
        {
            Result<mFacultad> _response = new Result<mFacultad>();

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
                    dFacultad oFacultad = new dFacultad();
                    _response = oFacultad.Eliminar(con, id);
                    con.Close();
                }
                catch (SqlException ex)
                {
                    _response.Descripcion = "Error al eliminar la facultad.";
                    _response.Resultado = new List<mFacultad>();
                    _response.ExisteError = true;
                    _response.Errores = new List<string> { ex.Message };
                }
            }
            return _response;
        }

        public Result<mFacultad> Eliminar(int id, mCarreraMoverDTO carrera)
        {
            Result<mFacultad> _response = new Result<mFacultad>();

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

                    if (carrera.facultad <= 0)
                    {
                        _response.Descripcion = "Facultad no válido, este debe ser mayor a 0.";
                        _response.ExisteError = true;
                        return _response;
                    }

                    con.Open();
                    dFacultad oFacultad = new dFacultad();
                    _response = oFacultad.Eliminar(con, id, carrera);
                    con.Close();
                }
                catch (SqlException ex)
                {
                    _response.Descripcion = "Error al eliminar la facultad.";
                    _response.Resultado = new List<mFacultad>();
                    _response.ExisteError = true;
                    _response.Errores = new List<string> { ex.Message };
                }
            }
            return _response;
        }

        public Result<mFacultad> Recuperar(int id)
        {
            Result<mFacultad> _response = new Result<mFacultad>();

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
                    dFacultad oFacultad = new dFacultad();
                    _response = oFacultad.Recuperar(con, id);

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
