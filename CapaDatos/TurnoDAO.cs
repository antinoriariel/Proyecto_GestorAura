using System;
using System.Data;
using System.Configuration;
using Microsoft.Data.SqlClient;

namespace CapaDatos
{
    public class TurnoDAO
    {
        // ✅ Conexión a la base de datos
        private readonly string conexion = ConfigurationManager.ConnectionStrings["conexionBD"].ConnectionString;

        // === OBTENER LISTA DE TURNOS ===
        public DataTable ObtenerTurnos()
        {
            using (SqlConnection conn = new SqlConnection(conexion))
            {
                string query = @"
                    SELECT 
                        t.id_turno,
                        t.fecha_turno,
                        t.hora_turno,
                        CONCAT(p.nombre, ' ', p.apellido) AS paciente,
                        CONCAT(u.nombre, ' ', u.apellido) AS medico,
                        t.estado,
                        t.motivo
                    FROM turnos t
                    INNER JOIN pacientes p ON t.id_paciente = p.id_paciente
                    INNER JOIN medicos m ON t.id_medico = m.id_medico
                    INNER JOIN users u ON m.id_usuario = u.id_usuario
                    WHERE t.deleted_at IS NULL
                    ORDER BY t.fecha_turno, t.hora_turno;";

                using (SqlDataAdapter da = new SqlDataAdapter(query, conn))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        // === INSERTAR NUEVO TURNO ===
        public bool InsertarTurno(DateTime fecha, TimeSpan hora, int idPaciente, int idMedico, int idUsuarioCreador, string motivo, string observaciones)
        {
            using (SqlConnection conn = new SqlConnection(conexion))
            {
                string query = @"
                    INSERT INTO turnos (fecha_turno, hora_turno, id_paciente, id_medico, id_usuario_creador, motivo, observaciones, estado)
                    VALUES (@fecha, @hora, @pac, @med, @usr, @motivo, @obs, 'programado');";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@fecha", fecha);
                    cmd.Parameters.AddWithValue("@hora", hora);
                    cmd.Parameters.AddWithValue("@pac", idPaciente);
                    cmd.Parameters.AddWithValue("@med", idMedico);
                    cmd.Parameters.AddWithValue("@usr", idUsuarioCreador);
                    cmd.Parameters.AddWithValue("@motivo", (object)motivo ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@obs", (object)observaciones ?? DBNull.Value);

                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // === ACTUALIZAR TURNO EXISTENTE ===
        public bool ActualizarTurno(int idTurno, DateTime fecha, TimeSpan hora, int idMedico, string estado, string motivo, string observaciones)
        {
            using (SqlConnection conn = new SqlConnection(conexion))
            {
                string query = @"
                    UPDATE turnos
                    SET fecha_turno = @fecha,
                        hora_turno = @hora,
                        id_medico = @medico,
                        estado = @estado,
                        motivo = @motivo,
                        observaciones = @obs,
                        modified_at = GETDATE()
                    WHERE id_turno = @id;";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@fecha", fecha);
                    cmd.Parameters.AddWithValue("@hora", hora);
                    cmd.Parameters.AddWithValue("@medico", idMedico);
                    cmd.Parameters.AddWithValue("@estado", estado);
                    cmd.Parameters.AddWithValue("@motivo", (object)motivo ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@obs", (object)observaciones ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@id", idTurno);

                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // === ELIMINACIÓN LÓGICA ===
        public bool EliminarTurno(int idTurno)
        {
            using (SqlConnection conn = new SqlConnection(conexion))
            {
                string query = "UPDATE turnos SET deleted_at = GETDATE() WHERE id_turno = @id;";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", idTurno);
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // === LISTA DE PACIENTES ===
        public DataTable ObtenerPacientes()
        {
            using (SqlConnection conn = new SqlConnection(conexion))
            {
                string query = "SELECT id_paciente, CONCAT(nombre, ' ', apellido) AS nombreCompleto FROM pacientes ORDER BY nombre, apellido;";
                using (SqlDataAdapter da = new SqlDataAdapter(query, conn))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        // === LISTA DE MÉDICOS ===
        public DataTable ObtenerMedicos()
        {
            using (SqlConnection conn = new SqlConnection(conexion))
            {
                string query = @"
                    SELECT 
                        m.id_medico, 
                        CONCAT(u.nombre, ' ', u.apellido, ' (', m.especialidad, ')') AS nombreCompleto
                    FROM medicos m
                    INNER JOIN users u ON m.id_usuario = u.id_usuario
                    ORDER BY u.nombre;";

                using (SqlDataAdapter da = new SqlDataAdapter(query, conn))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        // === TURNOS DEL DÍA POR ID DE MÉDICO ===
        public DataTable ObtenerTurnosDelDia(DateTime fecha, int? idMedico = null)
        {
            using (SqlConnection conn = new SqlConnection(conexion))
            {
                string query = @"
                    SELECT 
                        t.id_turno,
                        CONVERT(varchar(5), t.hora_turno, 108) AS hora_turno,
                        CONCAT(p.nombre, ' ', p.apellido) AS paciente,
                        CONCAT(u.nombre, ' ', u.apellido) AS medico,
                        t.estado,
                        t.motivo
                    FROM turnos t
                    INNER JOIN pacientes p ON t.id_paciente = p.id_paciente
                    INNER JOIN medicos m ON t.id_medico = m.id_medico
                    INNER JOIN users u ON m.id_usuario = u.id_usuario
                    WHERE 
                        CAST(t.fecha_turno AS date) = @fecha
                        AND t.deleted_at IS NULL
                        AND t.estado IN ('programado', 'confirmado')
                        AND (@idMedico IS NULL OR t.id_medico = @idMedico)
                    ORDER BY t.hora_turno ASC;";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@fecha", SqlDbType.Date).Value = fecha;
                    cmd.Parameters.Add("@idMedico", SqlDbType.Int).Value = (object?)idMedico ?? DBNull.Value;

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        // === TURNOS DEL DÍA FILTRADOS POR NOMBRE DE MÉDICO ===
        public DataTable ObtenerTurnosDelDiaPorNombre(DateTime fecha, string? nombreMedico = null)
        {
            using (SqlConnection conn = new SqlConnection(conexion))
            {
                string query = @"
                    SELECT 
                        t.id_turno,
                        CONVERT(varchar(5), t.hora_turno, 108) AS hora_turno,
                        CONCAT(p.nombre, ' ', p.apellido) AS paciente,
                        CONCAT(u.nombre, ' ', u.apellido) AS medico,
                        t.estado,
                        t.motivo
                    FROM turnos t
                    INNER JOIN pacientes p ON t.id_paciente = p.id_paciente
                    INNER JOIN medicos m ON t.id_medico = m.id_medico
                    INNER JOIN users u ON m.id_usuario = u.id_usuario
                    WHERE 
                        CAST(t.fecha_turno AS date) = @fecha
                        AND t.deleted_at IS NULL
                        AND t.estado IN ('programado', 'confirmado')
                        AND (
                            @nombreMedico IS NULL 
                            OR CONCAT(u.nombre, ' ', u.apellido) LIKE '%' + @nombreMedico + '%'
                            OR CONCAT(u.apellido, ' ', u.nombre) LIKE '%' + @nombreMedico + '%'
                        )
                    ORDER BY t.hora_turno ASC;";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@fecha", SqlDbType.Date).Value = fecha;
                    cmd.Parameters.Add("@nombreMedico", SqlDbType.VarChar, 100).Value = (object?)nombreMedico ?? DBNull.Value;

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }
    }
}
