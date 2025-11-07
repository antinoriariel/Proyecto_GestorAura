using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Configuration;

namespace CapaDatos
{
    public class NotaDAO
    {
        private readonly string conexion = ConfigurationManager.ConnectionStrings["conexionBD"].ConnectionString;

        public DataTable ObtenerNotasPorSecretaria(int idSecretaria)
        {
            using SqlConnection conn = new SqlConnection(conexion);
            using SqlCommand cmd = new SqlCommand("SELECT id_nota AS Id, titulo AS [Título], cuerpo AS [Cuerpo], fecha_creacion AS [Fecha] FROM notas_secretaria WHERE id_secretaria = @id AND activo = 1 ORDER BY fecha_creacion DESC", conn);
            cmd.Parameters.AddWithValue("@id", idSecretaria);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new();
            da.Fill(dt);
            return dt;
        }

        public DataTable BuscarNotas(int idSecretaria, string filtro)
        {
            using SqlConnection conn = new SqlConnection(conexion);
            using SqlCommand cmd = new SqlCommand(@"SELECT id_nota AS Id, titulo AS [Título], cuerpo AS [Cuerpo], fecha_creacion AS [Fecha]
                                                   FROM notas_secretaria
                                                   WHERE id_secretaria = @id AND activo = 1 AND titulo LIKE '%' + @filtro + '%'
                                                   ORDER BY fecha_creacion DESC", conn);
            cmd.Parameters.AddWithValue("@id", idSecretaria);
            cmd.Parameters.AddWithValue("@filtro", filtro);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new();
            da.Fill(dt);
            return dt;
        }

        public void InsertarNota(int idSecretaria, string titulo, string cuerpo)
        {
            using SqlConnection conn = new SqlConnection(conexion);
            conn.Open();
            using SqlCommand cmd = new SqlCommand("INSERT INTO notas_secretaria (id_secretaria, titulo, cuerpo) VALUES (@id, @titulo, @cuerpo)", conn);
            cmd.Parameters.AddWithValue("@id", idSecretaria);
            cmd.Parameters.AddWithValue("@titulo", titulo);
            cmd.Parameters.AddWithValue("@cuerpo", cuerpo);
            cmd.ExecuteNonQuery();
        }

        public void ActualizarNota(int idNota, string titulo, string cuerpo)
        {
            using SqlConnection conn = new SqlConnection(conexion);
            conn.Open();
            using SqlCommand cmd = new SqlCommand(@"UPDATE notas_secretaria SET titulo=@titulo, cuerpo=@cuerpo, 
                                                    fecha_modificacion=SYSDATETIME() WHERE id_nota=@id", conn);
            cmd.Parameters.AddWithValue("@titulo", titulo);
            cmd.Parameters.AddWithValue("@cuerpo", cuerpo);
            cmd.Parameters.AddWithValue("@id", idNota);
            cmd.ExecuteNonQuery();
        }

        public void EliminarNota(int idNota)
        {
            using SqlConnection conn = new SqlConnection(conexion);
            conn.Open();
            using SqlCommand cmd = new SqlCommand("UPDATE notas_secretaria SET activo = 0 WHERE id_nota = @id", conn);
            cmd.Parameters.AddWithValue("@id", idNota);
            cmd.ExecuteNonQuery();
        }
    }
}
