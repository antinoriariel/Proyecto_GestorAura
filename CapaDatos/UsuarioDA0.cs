using System;
using System.Configuration;
using System.Data;
using Microsoft.Data.SqlClient;

namespace CapaDatos
{
    public class UsuarioDAO
    {
        private readonly string conexion = ConfigurationManager.ConnectionStrings["conexionBD"].ConnectionString;

        // ===============================================================
        // OBTENER USUARIO POR USERNAME (LOGIN)
        // ===============================================================
        public DataRow? ObtenerUsuarioPorUsername(string username)
        {
            using (SqlConnection conn = new SqlConnection(conexion))
            {
                string query = @"
                SELECT id_usuario,
                       username,
                       password_hash,
                       password_salt,
                       rol,
                       activo,
                       nombre,
                       apellido
                FROM users
                WHERE username COLLATE Latin1_General_CS_AS = @user";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@user", SqlDbType.VarChar, 30).Value = username;

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new();
                        da.Fill(dt);
                        return dt.Rows.Count > 0 ? dt.Rows[0] : null;
                    }
                }
            }
        }

        // ===============================================================
        // INSERTAR USUARIO
        // ===============================================================
        public void InsertarUsuario(string username, byte[] hash, byte[] salt,
                                    string email, string nombre, string apellido,
                                    decimal dni, DateTime fNacimiento, string telefono, string rol)
        {
            using (SqlConnection conn = new SqlConnection(conexion))
            {
                conn.Open();
                string insert = @"
                INSERT INTO users 
                (username, password_hash, password_salt, email, nombre, apellido, dni, f_nacimiento, telefono, rol)
                VALUES (@user, @hash, @salt, @mail, @nombre, @apellido, @dni, @fnac, @tel, @rol)";

                using (SqlCommand cmd = new SqlCommand(insert, conn))
                {
                    cmd.Parameters.AddWithValue("@user", username);
                    cmd.Parameters.Add("@hash", SqlDbType.VarBinary, 256).Value = hash;
                    cmd.Parameters.Add("@salt", SqlDbType.VarBinary, 128).Value = salt;
                    cmd.Parameters.AddWithValue("@mail", email);
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@apellido", apellido);
                    cmd.Parameters.AddWithValue("@dni", dni);
                    cmd.Parameters.AddWithValue("@fnac", fNacimiento);
                    cmd.Parameters.AddWithValue("@tel", telefono);
                    cmd.Parameters.AddWithValue("@rol", rol);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // ===============================================================
        // OBTENER DATOS SECRETARIA
        // ===============================================================
        public DataTable ObtenerDatosSecretaria(string username)
        {
            using (SqlConnection conn = new SqlConnection(conexion))
            {
                string query = @"
                SELECT nombre,
                       apellido,
                       rol,
                       email
                FROM users
                WHERE username COLLATE Latin1_General_CS_AS = @user
                  AND activo = 1";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@user", SqlDbType.VarChar, 30).Value = username;
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        // ===============================================================
        // OBTENER ID POR USERNAME
        // ===============================================================
        public int ObtenerIdPorUsername(string username)
        {
            using (SqlConnection conn = new SqlConnection(conexion))
            {
                string query = "SELECT id_usuario FROM users WHERE username COLLATE Latin1_General_CS_AS = @user";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@user", SqlDbType.VarChar, 30).Value = username;
                    conn.Open();
                    object result = cmd.ExecuteScalar();
                    return result != null ? Convert.ToInt32(result) : 0;
                }
            }
        }

        // ===============================================================
        // OBTENER USUARIOS DE CHAT SEGÚN ROL
        // ===============================================================
        public DataTable ObtenerUsuariosChatPorRol(string rolActual)
        {
            using (SqlConnection cn = new SqlConnection(conexion))
            {
                string query = @"
                SELECT id_usuario, nombre, apellido, rol
                FROM users
                WHERE activo = 1
                  AND rol IN (
                        CASE 
                            WHEN @rol = 'secretaria' THEN 'medico'
                            WHEN @rol = 'medico' THEN 'secretaria'
                            ELSE 'none'
                        END
                  )
                ORDER BY nombre, apellido;";

                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.AddWithValue("@rol", rolActual);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        // ===============================================================
        // OBTENER DATOS MÉDICO
        // ===============================================================
        public DataTable ObtenerDatosMedico(string username)
        {
            using (SqlConnection cn = new SqlConnection(conexion))
            {
                string query = @"
                SELECT u.nombre,
                       u.apellido,
                       m.especialidad,
                       m.matricula_provincial,
                       m.matricula_nacional
                FROM users u
                INNER JOIN medicos m ON u.id_usuario = m.id_usuario
                WHERE u.username COLLATE Latin1_General_CS_AS = @username
                  AND u.activo = 1";

                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.Add("@username", SqlDbType.VarChar, 30).Value = username;
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }


        // ===============================================================
        // LISTAR USUARIOS (CON FILTRO OPCIONAL)
        // ===============================================================
        public DataTable ListarUsuarios(string filtro)
        {
            using (SqlConnection conn = new SqlConnection(conexion))
            {
                string query = @"
        SELECT 
            id_usuario,
            username,
            nombre,
            apellido,
            email,
            rol,
            dni,
            f_nacimiento,
            telefono,
            activo
        FROM users
        WHERE (@filtro = '' 
               OR username LIKE @like
               OR nombre  LIKE @like
               OR apellido LIKE @like
               OR email   LIKE @like
               OR rol     LIKE @like)
        ORDER BY apellido, nombre;";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@filtro", SqlDbType.VarChar, 100).Value = filtro ?? string.Empty;
                    cmd.Parameters.Add("@like", SqlDbType.VarChar, 100).Value = "%" + (filtro ?? string.Empty) + "%";

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        // ===============================================================
        // CAMBIAR ESTADO ACTIVO
        // ===============================================================
        public void CambiarEstadoUsuario(int idUsuario, bool activo)
        {
            using (SqlConnection conn = new SqlConnection(conexion))
            {
                conn.Open();
                string query = "UPDATE users SET activo = @activo WHERE id_usuario = @id";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@activo", activo);
                    cmd.Parameters.AddWithValue("@id", idUsuario);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // ===============================================================
        // ELIMINAR USUARIO
        // ===============================================================
        public void EliminarUsuario(int idUsuario)
        {
            using (SqlConnection conn = new SqlConnection(conexion))
            {
                conn.Open();
                string query = "DELETE FROM users WHERE id_usuario = @id";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", idUsuario);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
