using System.Data;
using System.Data.SqlClient;
using Universidad.Model;
using Universidad.Model.DTO;

namespace Universidad.Data
{
    public class dCarrera
    {
        public Result<mCarrera> Listar(SqlConnection con)
        {
            Result<mCarrera> _respuesta = new Result<mCarrera>();
            List<mCarrera> _lFacultad = new List<mCarrera>();

            try
            {
                SqlCommand cmd = new SqlCommand("asp_listar_carrera", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr != null)
                {
                    mCarrera? obECarrera = null;
                    while (dr.Read())
                    {
                        obECarrera = new mCarrera();
                        obECarrera.id = Convert.ToInt32(dr["id"]);
                        obECarrera.facultad = Convert.ToInt32(dr["facultad"]);
                        obECarrera.nombre_carrera = dr["nombre_carrera"].ToString();
                        obECarrera.codigo_carrera = dr["codigo_carrera"].ToString();
                        obECarrera.estado_carrera = Convert.ToInt32(dr["estado_carrera"]);
                        obECarrera.creado_tmstp = dr["creado_tmstp"] == DBNull.Value ? null : Convert.ToDateTime(dr["creado_tmstp"]);
                        obECarrera.actualizado_tmstp = dr["actualizado_tmstp"] == DBNull.Value ? null : Convert.ToDateTime(dr["actualizado_tmstp"]);
                        //obECarrera.creado_tmstp = Convert.ToDateTime(dr["creado_tmstp"]);
                        //obECarrera.actualizado_tmstp = Convert.ToDateTime(dr["actualizado_tmstp"]);
                        _lFacultad.Add(obECarrera);
                    }
                }

                dr.Close();

                if (_lFacultad.Count > 0)
                {
                    _respuesta.Descripcion = "Cantidad de filas: " + _lFacultad.Count;
                    _respuesta.Resultado = _lFacultad;
                    _respuesta.ExisteError = false;
                    _respuesta.Errores = null;
                }
                else
                {
                    _respuesta.Descripcion = "No hay registros.";
                    _respuesta.Resultado = new List<mCarrera>();
                    _respuesta.ExisteError = false;
                    _respuesta.Errores = null;
                }
            }
            catch (Exception ex)
            {
                _respuesta.Descripcion = "Error al obtener los datos.";
                _respuesta.Resultado = new List<mCarrera>();
                _respuesta.ExisteError = true;
                _respuesta.Errores = new List<string> { ex.Message };
            }

            return _respuesta;
        }

        public Result<mCarrera> Obtener(SqlConnection con, int id)
        {
            Result<mCarrera> _respuesta = new Result<mCarrera>();
            List<mCarrera> _lFacultad = new List<mCarrera>();

            try
            {
                SqlCommand cmd = new SqlCommand("asp_obtener_carrera", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", SqlDbType.Int).Value = id;

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr != null)
                {
                    mCarrera? obECarrera = null;
                    while (dr.Read())
                    {
                        obECarrera = new mCarrera();
                        obECarrera.id = Convert.ToInt32(dr["id"]);
                        obECarrera.facultad = Convert.ToInt32(dr["facultad"]);
                        obECarrera.nombre_carrera = dr["nombre_carrera"].ToString();
                        obECarrera.codigo_carrera = dr["codigo_carrera"].ToString();
                        obECarrera.estado_carrera = Convert.ToInt32(dr["estado_carrera"]);
                        obECarrera.creado_tmstp = dr["creado_tmstp"] == DBNull.Value ? null : Convert.ToDateTime(dr["creado_tmstp"]);
                        obECarrera.actualizado_tmstp = dr["actualizado_tmstp"] == DBNull.Value ? null : Convert.ToDateTime(dr["actualizado_tmstp"]);
                        //obECarrera.creado_tmstp = Convert.ToDateTime(dr["creado_tmstp"]);
                        //obECarrera.actualizado_tmstp = Convert.ToDateTime(dr["actualizado_tmstp"]);
                        _lFacultad.Add(obECarrera);
                    }
                }

                dr.Close();

                if (_lFacultad.Count > 0)
                {
                    _respuesta.Descripcion = "Cantidad de filas: " + _lFacultad.Count;
                    _respuesta.Resultado = _lFacultad;
                    _respuesta.ExisteError = false;
                    _respuesta.Errores = null;
                }
                else
                {
                    _respuesta.Descripcion = "No hay registros o no existe.";
                    _respuesta.Resultado = new List<mCarrera>();
                    _respuesta.ExisteError = false;
                    _respuesta.Errores = null;
                }
            }
            catch (Exception ex)
            {
                _respuesta.Descripcion = "Error al obtener los datos.";
                _respuesta.Resultado = new List<mCarrera>();
                _respuesta.ExisteError = true;
                _respuesta.Errores = new List<string> { ex.Message };
            }

            return _respuesta;
        }

        public Result<mCarrera> Obtener_recuperar(SqlConnection con, int id)
        {
            Result<mCarrera> _respuesta = new Result<mCarrera>();
            List<mCarrera> _lFacultad = new List<mCarrera>();

            try
            {
                SqlCommand cmd = new SqlCommand("asp_obtener_recuperar_carrera", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", SqlDbType.Int).Value = id;

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr != null)
                {
                    mCarrera? obECarrera = null;
                    while (dr.Read())
                    {
                        obECarrera = new mCarrera();
                        obECarrera.id = Convert.ToInt32(dr["id"]);
                        obECarrera.facultad = Convert.ToInt32(dr["facultad"]);
                        obECarrera.nombre_carrera = dr["nombre_carrera"].ToString();
                        obECarrera.codigo_carrera = dr["codigo_carrera"].ToString();
                        obECarrera.estado_carrera = Convert.ToInt32(dr["estado_carrera"]);
                        obECarrera.creado_tmstp = dr["creado_tmstp"] == DBNull.Value ? null : Convert.ToDateTime(dr["creado_tmstp"]);
                        obECarrera.actualizado_tmstp = dr["actualizado_tmstp"] == DBNull.Value ? null : Convert.ToDateTime(dr["actualizado_tmstp"]);
                        _lFacultad.Add(obECarrera);
                    }
                }

                dr.Close();

                if (_lFacultad.Count > 0)
                {
                    _respuesta.Descripcion = "Cantidad de filas: " + _lFacultad.Count;
                    _respuesta.Resultado = _lFacultad;
                    _respuesta.ExisteError = false;
                    _respuesta.Errores = null;
                }
                else
                {
                    _respuesta.Descripcion = "No hay registros o no existe.";
                    _respuesta.Resultado = new List<mCarrera>();
                    _respuesta.ExisteError = false;
                    _respuesta.Errores = null;
                }
            }
            catch (Exception ex)
            {
                _respuesta.Descripcion = "Error al obtener los datos.";
                _respuesta.Resultado = new List<mCarrera>();
                _respuesta.ExisteError = true;
                _respuesta.Errores = new List<string> { ex.Message };
            }

            return _respuesta;
        }

        public Result<mCarrera> Registrar(SqlConnection con, mCarreraDTO carrera)
        {
            Result<mCarrera> _respuesta = new Result<mCarrera>();

            try
            {
                SqlCommand cmd = new SqlCommand("asp_registrar_carrera", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@facultad", SqlDbType.Int).Value = carrera.facultad;
                cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 200).Value = carrera.nombre_carrera;
                cmd.Parameters.Add("@codigo", SqlDbType.VarChar, 150).Value = carrera.codigo_carrera;

                int filasAfectadas = cmd.ExecuteNonQuery();

                if (filasAfectadas > 0)
                {
                    _respuesta.Descripcion = "Registro exitoso.";
                    _respuesta.ExisteError = false;
                    _respuesta.Errores = null;
                }
                else
                {
                    _respuesta.Descripcion = "No se pudo realizar el registro.";
                    _respuesta.ExisteError = true;
                    _respuesta.Errores = new List<string> { "No se afectaron filas en la base de datos." };
                }
            }
            catch (Exception ex)
            {
                _respuesta.Descripcion = "Error al realizar el registro.";
                _respuesta.ExisteError = true;
                _respuesta.Errores = new List<string> { ex.Message };
            }

            return _respuesta;
        }

        public Result<mCarrera> Actualizar(SqlConnection con, int id, mCarreraDTO carrera)
        {
            Result<mCarrera> _respuesta = new Result<mCarrera>();
            Result<mCarrera> resultadoObtener = Obtener(con, id); // Primero, verifica si el ID existe utilizando el método Obtener

            if (resultadoObtener.ExisteError || resultadoObtener.Resultado.Count == 0)
            {
                _respuesta.Descripcion = "No se puede actualizar. El ID no existe o hay un error al obtener los datos.";
                _respuesta.ExisteError = true;
                _respuesta.Errores = resultadoObtener.Errores;
            }
            else
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("asp_actualizar_carrera", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    cmd.Parameters.Add("@facultad", SqlDbType.Int).Value = carrera.facultad;
                    cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 200).Value = carrera.nombre_carrera;
                    cmd.Parameters.Add("@codigo", SqlDbType.VarChar, 150).Value = carrera.codigo_carrera;
                    cmd.Parameters.Add("@estado", SqlDbType.Int).Value = carrera.estado_carrera;

                    int filasAfectadas = cmd.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                    {
                        _respuesta.Descripcion = "Actualización exitosa.";
                        _respuesta.ExisteError = false;
                        _respuesta.Errores = null;
                    }
                    else
                    {
                        _respuesta.Descripcion = "No se pudo actualizar el registro.";
                        _respuesta.ExisteError = true;
                        _respuesta.Errores = new List<string> { "No se afectaron filas en la base de datos." };
                    }
                }
                catch (Exception ex)
                {
                    _respuesta.Descripcion = "Error al actualizar el registro.";
                    _respuesta.ExisteError = true;
                    _respuesta.Errores = new List<string> { ex.Message };
                }
            }

            return _respuesta;
        }

        public Result<mCarrera> Eliminar(SqlConnection con, int id)
        {
            Result<mCarrera> _respuesta = new Result<mCarrera>();
            Result<mCarrera> resultadoObtener = Obtener(con, id); // Primero, verifica si el ID existe utilizando el método Obtener

            if (resultadoObtener.ExisteError || resultadoObtener.Resultado.Count == 0)
            {
                _respuesta.Descripcion = "No se puede eliminar. El ID no existe o hay un error al obtener los datos.";
                _respuesta.ExisteError = true;
                _respuesta.Errores = resultadoObtener.Errores;
            }
            else
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("asp_eliminar_carrera", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

                    int filasAfectadas = cmd.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                    {
                        _respuesta.Descripcion = "Eliminación exitosa.";
                        _respuesta.ExisteError = false;
                        _respuesta.Errores = null;
                    }
                    else
                    {
                        _respuesta.Descripcion = "No se pudo eliminar el registro.";
                        _respuesta.ExisteError = true;
                        _respuesta.Errores = new List<string> { "No se afectaron filas en la base de datos." };
                    }
                }
                catch (Exception ex)
                {
                    _respuesta.Descripcion = "Error al eliminar el registro.";
                    _respuesta.ExisteError = true;
                    _respuesta.Errores = new List<string> { ex.Message };
                }
            }

            return _respuesta;
        }

        public Result<mCarrera> Recuperar(SqlConnection con, int id)
        {
            Result<mCarrera> _respuesta = new Result<mCarrera>();
            Result<mCarrera> resultadoObtener = Obtener_recuperar(con, id); // Primero, verifica si el ID existe utilizando el método Obtener

            if (resultadoObtener.ExisteError || resultadoObtener.Resultado.Count == 0)
            {
                _respuesta.Descripcion = "No se puede recuperar. El ID no existe o hay un error al obtener los datos.";
                _respuesta.ExisteError = true;
                _respuesta.Errores = resultadoObtener.Errores;
            }
            else
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("asp_recuperar_carrera", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

                    int filasAfectadas = cmd.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                    {
                        _respuesta.Descripcion = "Recuperación exitosa, ya puedes listar por su ID.";
                        _respuesta.ExisteError = false;
                        _respuesta.Errores = null;
                    }
                    else
                    {
                        _respuesta.Descripcion = "No se pudo recuperar el registro.";
                        _respuesta.ExisteError = true;
                        _respuesta.Errores = new List<string> { "No se afectaron filas en la base de datos." };
                    }
                }
                catch (Exception ex)
                {
                    _respuesta.Descripcion = "Error al recuperar el registro.";
                    _respuesta.ExisteError = true;
                    _respuesta.Errores = new List<string> { ex.Message };
                }
            }

            return _respuesta;
        }
    }
}
