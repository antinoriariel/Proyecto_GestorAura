using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Configuration;

namespace CapaDatos
{
    public class MensajeDAO
    {
        private readonly string _connectionString;

        public MensajeDAO()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["conexionBD"].ConnectionString;
        }

        // ============================================================
        // 🔹 Obtener mensajes entre dos usuarios (usa vista con nombres)
        // ============================================================
        public DataTable ObtenerConversacion(int idUsuarioActual, int idOtro)
        {
            var tabla = new DataTable();

            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                string query = @"
                    SELECT 
                        id_mensaje,
                        id_remitente,
                        nombre_remitente,
                        id_destinatario,
                        nombre_destinatario,
                        cuerpo,
                        fecha_creacion
                    FROM vw_mensajes_detalle
                    WHERE 
                        (id_remitente = @idUsuarioActual AND id_destinatario = @idOtro)
                        OR
                        (id_remitente = @idOtro AND id_destinatario = @idUsuarioActual)
                    ORDER BY fecha_creacion ASC;";

                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.AddWithValue("@idUsuarioActual", idUsuarioActual);
                    cmd.Parameters.AddWithValue("@idOtro", idOtro);

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(tabla);
                    }
                }
            }

            return tabla;
        }

        // ============================================================
        // 🔹 Insertar nuevo mensaje
        // ============================================================
        public void InsertarMensaje(int idRemitente, int idDestinatario, string cuerpo)
        {
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                string query = @"
                    INSERT INTO mensajes_usuarios (id_remitente, id_destinatario, cuerpo)
                    VALUES (@idRemitente, @idDestinatario, @cuerpo);";

                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.AddWithValue("@idRemitente", idRemitente);
                    cmd.Parameters.AddWithValue("@idDestinatario", idDestinatario);
                    cmd.Parameters.AddWithValue("@cuerpo", cuerpo);

                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // ============================================================
        // 🔹 Obtener lista de usuarios con los que hay conversación
        // ============================================================
        public DataTable ObtenerConversacionesDelUsuario(int idUsuario)
        {
            var tabla = new DataTable();

            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                string query = @"
                    SELECT DISTINCT 
                        CASE 
                            WHEN id_remitente = @idUsuario THEN id_destinatario
                            ELSE id_remitente
                        END AS id_otro,
                        CASE 
                            WHEN id_remitente = @idUsuario THEN 
                                CONCAT(u2.nombre, ' ', u2.apellido, ' (', u2.rol, ')')
                            ELSE 
                                CONCAT(u1.nombre, ' ', u1.apellido, ' (', u1.rol, ')')
                        END AS nombre_otro
                    FROM mensajes_usuarios m
                    INNER JOIN users u1 ON m.id_remitente = u1.id_usuario
                    INNER JOIN users u2 ON m.id_destinatario = u2.id_usuario
                    WHERE id_remitente = @idUsuario OR id_destinatario = @idUsuario
                    ORDER BY nombre_otro;";

                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(tabla);
                    }
                }
            }

            return tabla;
        }
    }
}
