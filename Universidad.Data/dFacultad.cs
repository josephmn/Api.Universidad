using System.Data;
using System.Data.SqlClient;
using Universidad.Model;
using Universidad.Model.DTO;

namespace Universidad.Data
{
    public class dFacultad
    {
        public Result<mFacultad> Listar(SqlConnection con)
        {
            Result<mFacultad> _respuesta = new Result<mFacultad>();
            List<mFacultad> _lFacultad = new List<mFacultad>();

            try
            {
                SqlCommand cmd = new SqlCommand("asp_listar_facultad", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr != null)
                {
                    mFacultad? obEFacultad = null;
                    while (dr.Read())
                    {
                        obEFacultad = new mFacultad();
                        obEFacultad.id = Convert.ToInt32(dr["id"]);
                        obEFacultad.nombre_facultad = dr["nombre_facultad"].ToString();
                        obEFacultad.codigo_facultad = dr["codigo_facultad"].ToString();
                        obEFacultad.estado_facultad = Convert.ToInt32(dr["estado_facultad"]);
                        obEFacultad.creado_tmstp = dr["creado_tmstp"] == DBNull.Value ? null : Convert.ToDateTime(dr["creado_tmstp"]);
                        obEFacultad.actualizado_tmstp = dr["actualizado_tmstp"] == DBNull.Value ? null : Convert.ToDateTime(dr["actualizado_tmstp"]);
                        //obEFacultad.creado_tmstp = Convert.ToDateTime(dr["creado_tmstp"]);
                        //obEFacultad.actualizado_tmstp = Convert.ToDateTime(dr["actualizado_tmstp"]);
                        _lFacultad.Add(obEFacultad);
                    }
                }

                dr.Close();

                if (_lFacultad.Count > 0)
                {
                    foreach (mFacultad facultad in _lFacultad)
                    {
                        List<mCarrera> _lCarrera = new List<mCarrera>();

                        SqlCommand cmd2 = new SqlCommand("asp_obtener_carrera_det", con);
                        cmd2.CommandType = CommandType.StoredProcedure;

                        cmd2.Parameters.AddWithValue("@id", SqlDbType.Int).Value = facultad.id;

                        SqlDataReader drd2 = cmd2.ExecuteReader();

                        if (drd2 != null)
                        {
                            mCarrera? obECarrera = null;
                            while (drd2.Read())
                            {
                                obECarrera = new mCarrera();
                                obECarrera.id = Convert.ToInt32(drd2["id"]);
                                obECarrera.facultad = Convert.ToInt32(drd2["facultad"]);
                                obECarrera.nombre_carrera = drd2["nombre_carrera"].ToString();
                                obECarrera.codigo_carrera = drd2["codigo_carrera"].ToString();
                                obECarrera.estado_carrera = Convert.ToInt32(drd2["estado_carrera"]);
                                obECarrera.creado_tmstp = drd2["creado_tmstp"] == DBNull.Value ? null : Convert.ToDateTime(drd2["creado_tmstp"]);
                                obECarrera.actualizado_tmstp = drd2["actualizado_tmstp"] == DBNull.Value ? null : Convert.ToDateTime(drd2["actualizado_tmstp"]);
                                _lCarrera.Add(obECarrera);
                            }

                        }

                        drd2.Close();

                        facultad.lista_carreras = _lCarrera;
                    }

                    _respuesta.Descripcion = "Cantidad de filas: " + _lFacultad.Count;
                    _respuesta.Resultado = _lFacultad;
                    _respuesta.ExisteError = false;
                    _respuesta.Errores = null;
                }
                else
                {
                    _respuesta.Descripcion = "No hay registros.";
                    _respuesta.Resultado = new List<mFacultad>();
                    _respuesta.ExisteError = false;
                    _respuesta.Errores = null;
                }
            }
            catch (Exception ex)
            {
                _respuesta.Descripcion = "Error al obtener los datos.";
                _respuesta.Resultado = new List<mFacultad>();
                _respuesta.ExisteError = true;
                _respuesta.Errores = new List<string> { ex.Message };
            }

            return _respuesta;
        }

        public Result<mFacultad> Obtener(SqlConnection con, int id)
        {
            Result<mFacultad> _respuesta = new Result<mFacultad>();
            List<mFacultad> _lFacultad = new List<mFacultad>();

            try
            {
                SqlCommand cmd = new SqlCommand("asp_obtener_facultad", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", SqlDbType.Int).Value = id;

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr != null)
                {
                    mFacultad? obEFacultad = null;
                    while (dr.Read())
                    {
                        obEFacultad = new mFacultad();
                        obEFacultad.id = Convert.ToInt32(dr["id"]);
                        obEFacultad.nombre_facultad = dr["nombre_facultad"].ToString();
                        obEFacultad.codigo_facultad = dr["codigo_facultad"].ToString();
                        obEFacultad.estado_facultad = Convert.ToInt32(dr["estado_facultad"]);
                        obEFacultad.creado_tmstp = dr["creado_tmstp"] == DBNull.Value ? null : Convert.ToDateTime(dr["creado_tmstp"]);
                        obEFacultad.actualizado_tmstp = dr["actualizado_tmstp"] == DBNull.Value ? null : Convert.ToDateTime(dr["actualizado_tmstp"]);
                        _lFacultad.Add(obEFacultad);
                    }
                }

                dr.Close();

                if (_lFacultad.Count > 0)
                {
                    foreach (mFacultad facultad in _lFacultad)
                    {
                        List<mCarrera> _lCarrera = new List<mCarrera>();

                        SqlCommand cmd2 = new SqlCommand("asp_obtener_carrera_det", con);
                        cmd2.CommandType = CommandType.StoredProcedure;

                        cmd2.Parameters.AddWithValue("@id", SqlDbType.Int).Value = facultad.id;

                        SqlDataReader drd2 = cmd2.ExecuteReader();

                        if (drd2 != null)
                        {
                            mCarrera? obECarrera = null;
                            while (drd2.Read())
                            {
                                obECarrera = new mCarrera();
                                obECarrera.id = Convert.ToInt32(drd2["id"]);
                                obECarrera.facultad = Convert.ToInt32(drd2["facultad"]);
                                obECarrera.nombre_carrera = drd2["nombre_carrera"].ToString();
                                obECarrera.codigo_carrera = drd2["codigo_carrera"].ToString();
                                obECarrera.estado_carrera = Convert.ToInt32(drd2["estado_carrera"]);
                                obECarrera.creado_tmstp = drd2["creado_tmstp"] == DBNull.Value ? null : Convert.ToDateTime(drd2["creado_tmstp"]);
                                obECarrera.actualizado_tmstp = drd2["actualizado_tmstp"] == DBNull.Value ? null : Convert.ToDateTime(drd2["actualizado_tmstp"]);
                                _lCarrera.Add(obECarrera);
                            }

                        }

                        drd2.Close();

                        facultad.lista_carreras = _lCarrera;
                    }

                    _respuesta.Descripcion = "Cantidad de filas: " + _lFacultad.Count;
                    _respuesta.Resultado = _lFacultad;
                    _respuesta.ExisteError = false;
                    _respuesta.Errores = null;
                }
                else
                {
                    _respuesta.Descripcion = "No hay registros o no existe.";
                    _respuesta.Resultado = new List<mFacultad>();
                    _respuesta.ExisteError = false;
                    _respuesta.Errores = null;
                }
            }
            catch (Exception ex)
            {
                _respuesta.Descripcion = "Error al obtener los datos.";
                _respuesta.Resultado = new List<mFacultad>();
                _respuesta.ExisteError = true;
                _respuesta.Errores = new List<string> { ex.Message };
            }

            return _respuesta;
        }

        public Result<mFacultad> Obtener_recuperar(SqlConnection con, int id)
        {
            Result<mFacultad> _respuesta = new Result<mFacultad>();
            List<mFacultad> _lFacultad = new List<mFacultad>();

            try
            {
                SqlCommand cmd = new SqlCommand("asp_obtener_recuperar_facultad", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", SqlDbType.Int).Value = id;

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr != null)
                {
                    mFacultad? obEFacultad = null;
                    while (dr.Read())
                    {
                        obEFacultad = new mFacultad();
                        obEFacultad.id = Convert.ToInt32(dr["id"]);
                        obEFacultad.nombre_facultad = dr["nombre_facultad"].ToString();
                        obEFacultad.codigo_facultad = dr["codigo_facultad"].ToString();
                        obEFacultad.estado_facultad = Convert.ToInt32(dr["estado_facultad"]);
                        obEFacultad.creado_tmstp = dr["creado_tmstp"] == DBNull.Value ? null : Convert.ToDateTime(dr["creado_tmstp"]);
                        obEFacultad.actualizado_tmstp = dr["actualizado_tmstp"] == DBNull.Value ? null : Convert.ToDateTime(dr["actualizado_tmstp"]);
                        _lFacultad.Add(obEFacultad);
                    }
                }

                dr.Close();

                if (_lFacultad.Count > 0)
                {
                    foreach (mFacultad facultad in _lFacultad)
                    {
                        List<mCarrera> _lCarrera = new List<mCarrera>();

                        SqlCommand cmd2 = new SqlCommand("asp_obtener_carrera_det", con);
                        cmd2.CommandType = CommandType.StoredProcedure;

                        cmd2.Parameters.AddWithValue("@id", SqlDbType.Int).Value = facultad.id;

                        SqlDataReader drd2 = cmd2.ExecuteReader();

                        if (drd2 != null)
                        {
                            mCarrera? obECarrera = null;
                            while (drd2.Read())
                            {
                                obECarrera = new mCarrera();
                                obECarrera.id = Convert.ToInt32(drd2["id"]);
                                obECarrera.facultad = Convert.ToInt32(drd2["facultad"]);
                                obECarrera.nombre_carrera = drd2["nombre_carrera"].ToString();
                                obECarrera.codigo_carrera = drd2["codigo_carrera"].ToString();
                                obECarrera.estado_carrera = Convert.ToInt32(drd2["estado_carrera"]);
                                obECarrera.creado_tmstp = drd2["creado_tmstp"] == DBNull.Value ? null : Convert.ToDateTime(drd2["creado_tmstp"]);
                                obECarrera.actualizado_tmstp = drd2["actualizado_tmstp"] == DBNull.Value ? null : Convert.ToDateTime(drd2["actualizado_tmstp"]);
                                _lCarrera.Add(obECarrera);
                            }

                        }

                        drd2.Close();

                        facultad.lista_carreras = _lCarrera;
                    }

                    _respuesta.Descripcion = "Cantidad de filas: " + _lFacultad.Count;
                    _respuesta.Resultado = _lFacultad;
                    _respuesta.ExisteError = false;
                    _respuesta.Errores = null;
                }
                else
                {
                    _respuesta.Descripcion = "No hay registros o no existe.";
                    _respuesta.Resultado = new List<mFacultad>();
                    _respuesta.ExisteError = false;
                    _respuesta.Errores = null;
                }
            }
            catch (Exception ex)
            {
                _respuesta.Descripcion = "Error al obtener los datos.";
                _respuesta.Resultado = new List<mFacultad>();
                _respuesta.ExisteError = true;
                _respuesta.Errores = new List<string> { ex.Message };
            }

            return _respuesta;
        }

        public Result<mFacultad> Registrar(SqlConnection con, mFacultadDTO facultad)
        {
            Result<mFacultad> _respuesta = new Result<mFacultad>();

            try
            {
                SqlCommand cmd = new SqlCommand("asp_registrar_facultad", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 200).Value = facultad.nombre_facultad;
                cmd.Parameters.Add("@codigo", SqlDbType.VarChar, 150).Value = facultad.codigo_facultad;

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

        public Result<mFacultad> Actualizar(SqlConnection con, int id, mFacultadDTO facultad)
        {
            Result<mFacultad> _respuesta = new Result<mFacultad>();
            Result<mFacultad> resultadoObtener = Obtener(con, id); // Primero, verifica si el ID existe utilizando el método Obtener

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
                    SqlCommand cmd = new SqlCommand("asp_actualizar_facultad", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 200).Value = facultad.nombre_facultad;
                    cmd.Parameters.Add("@codigo", SqlDbType.VarChar, 150).Value = facultad.codigo_facultad;
                    cmd.Parameters.Add("@estado", SqlDbType.Int).Value = facultad.estado_facultad;

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

        public Result<mFacultad> Eliminar(SqlConnection con, int id)
        {
            Result<mFacultad> _respuesta = new Result<mFacultad>();
            Result<mFacultad> resultadoObtener = Obtener(con, id); // Primero, verifica si el ID existe utilizando el método Obtener

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
                    SqlCommand cmd = new SqlCommand("asp_eliminar_facultad", con);
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

        public Result<mFacultad> Eliminar(SqlConnection con, int id, mCarreraMoverDTO carrera)
        {
            Result<mFacultad> _respuesta = new Result<mFacultad>();
            Result<mFacultad> resultadoObtener = Obtener(con, id); // Primero, verifica si el ID existe utilizando el método Obtener

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
                    SqlCommand cmd = new SqlCommand("asp_eliminar_migrar_facultad", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    cmd.Parameters.Add("@facultad", SqlDbType.Int).Value = carrera.facultad;

                    int filasAfectadas = cmd.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                    {
                        _respuesta.Descripcion = "Eliminación exitosa y migración de carrera a nueva facultad.";
                        _respuesta.ExisteError = false;
                        _respuesta.Errores = null;
                    }
                    else
                    {
                        _respuesta.Descripcion = "No se pudo eliminar y migrar los registros.";
                        _respuesta.ExisteError = true;
                        _respuesta.Errores = new List<string> { "No se afectaron filas en la base de datos." };
                    }
                }
                catch (Exception ex)
                {
                    _respuesta.Descripcion = "Error al eliminar y migrar los registros.";
                    _respuesta.ExisteError = true;
                    _respuesta.Errores = new List<string> { ex.Message };
                }
            }

            return _respuesta;
        }

        public Result<mFacultad> Recuperar(SqlConnection con, int id)
        {
            Result<mFacultad> _respuesta = new Result<mFacultad>();
            Result<mFacultad> resultadoObtener = Obtener_recuperar(con, id); // Primero, verifica si el ID existe utilizando el método Obtener

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
                    SqlCommand cmd = new SqlCommand("asp_recuperar_facultad", con);
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
