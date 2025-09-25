using System;
using System.Configuration;
using System.Data;
using Microsoft.Data.SqlClient;

namespace CapaDatos
{
    public class UsuarioDAO
    {
        private readonly string conexion = ConfigurationManager.ConnectionStrings["conexionBD"].ConnectionString;

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
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt.Rows.Count > 0 ? dt.Rows[0] : null;
                    }
                }
            }
        }

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
    }
}
