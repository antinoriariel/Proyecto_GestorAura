using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using Microsoft.Data.SqlClient;

namespace CapaDatos
{
    public class HistoriaClinicaDAO
    {
        private readonly string _connectionString;

        public HistoriaClinicaDAO()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["conexionBD"].ConnectionString;
        }

        // ==============================================================
        // INSERTAR HISTORIA CLÍNICA
        // ==============================================================
        public bool InsertarHistoriaClinica(
            int idPaciente,
            int idUsuario,
            string motivo,
            string estado,
            DateTime fechaHora,
            string impresionDiagnostica,
            string diagnostico,
            string indicaciones,
            string antecedentes,
            string observaciones,
            string tipoConsulta)
        {
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                string query = @"
                    INSERT INTO historias_clinicas
                    (id_paciente, id_usuario, mdc, antecedentes_patologicos, diagnostico, 
                     impresion_diagnostica, evolucion, indicaciones, impresion_general, 
                     examenes_complementarios, tipo_consulta, estado, fecha_hora)
                    VALUES 
                    (@id_paciente, @id_usuario, @mdc, @antecedentes, @diagnostico, 
                     @impresion_diag, @evolucion, @indicaciones, @impresion_general, 
                     @examenes, @tipo_consulta, @estado, @fecha_hora);";

                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.AddWithValue("@id_paciente", idPaciente);
                    cmd.Parameters.AddWithValue("@id_usuario", idUsuario);
                    cmd.Parameters.AddWithValue("@mdc", (object?)motivo ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@antecedentes", (object?)antecedentes ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@diagnostico", (object?)diagnostico ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@impresion_diag", (object?)impresionDiagnostica ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@evolucion", (object?)observaciones ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@indicaciones", (object?)indicaciones ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@impresion_general", DBNull.Value);
                    cmd.Parameters.AddWithValue("@examenes", DBNull.Value);
                    cmd.Parameters.AddWithValue("@tipo_consulta", (object?)tipoConsulta ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@estado", string.IsNullOrWhiteSpace(estado) ? "abierta" : estado);
                    cmd.Parameters.AddWithValue("@fecha_hora", fechaHora);

                    cn.Open();
                    int filas = cmd.ExecuteNonQuery();
                    return filas > 0;
                }
            }
        }

        // ==============================================================
        // OBTENER PACIENTES / BUSCAR PACIENTES
        // ==============================================================
        public List<(int Id, string NombreCompleto)> ObtenerPacientes()
        {
            var lista = new List<(int, string)>();
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                string query = @"SELECT id_paciente, CONCAT(nombre, ' ', apellido) AS nombre_completo 
                                 FROM pacientes
                                 ORDER BY apellido, nombre;";
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                            lista.Add((dr.GetInt32(0), dr.GetString(1)));
                    }
                }
            }
            return lista;
        }

        public DataTable BuscarPacientesPorNombre(string texto)
        {
            var tabla = new DataTable();
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                string query = @"SELECT id_paciente, CONCAT(nombre, ' ', apellido) AS nombre_completo 
                                 FROM pacientes 
                                 WHERE nombre LIKE @txt OR apellido LIKE @txt
                                 ORDER BY apellido, nombre;";
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.AddWithValue("@txt", $"%{texto}%");
                    cn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                        tabla.Load(dr);
                }
            }
            return tabla;
        }

        // ==============================================================
        // NUEVOS MÉTODOS PARA DASHBOARD HC
        // ==============================================================

        /// <summary>
        /// Devuelve todas las historias clínicas con información de paciente y médico.
        /// </summary>
        public DataTable ObtenerHistoriasDetalladas(int? idPaciente = null, DateTime? desde = null, DateTime? hasta = null)
        {
            var tabla = new DataTable();
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                string query = @"
                    SELECT 
                        hc.id_hc AS id_historia,
                        p.id_paciente,
                        CONCAT(p.apellido, ', ', p.nombre) AS paciente,
                        u.nombre + ' ' + u.apellido AS medico,
                        hc.fecha_hora,
                        hc.estado,
                        hc.tipo_consulta,
                        hc.mdc AS motivo,
                        hc.impresion_diagnostica,
                        hc.diagnostico,
                        hc.indicaciones,
                        hc.evolucion AS observaciones
                    FROM historias_clinicas hc
                    INNER JOIN pacientes p ON hc.id_paciente = p.id_paciente
                    LEFT JOIN users u ON hc.id_usuario = u.id_usuario
                    WHERE (@idPaciente IS NULL OR hc.id_paciente = @idPaciente)
                      AND (@desde IS NULL OR hc.fecha_hora >= @desde)
                      AND (@hasta IS NULL OR hc.fecha_hora <= @hasta)
                    ORDER BY hc.fecha_hora DESC;";

                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.AddWithValue("@idPaciente", (object?)idPaciente ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@desde", (object?)desde ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@hasta", (object?)hasta ?? DBNull.Value);

                    cn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                        tabla.Load(dr);
                }
            }
            return tabla;
        }

        /// <summary>
        /// Devuelve una historia clínica completa (detallada) para exportar a PDF.
        /// </summary>
        public DataTable ObtenerHistoriaDetalladaPorId(int idHistoria)
        {
            var tabla = new DataTable();
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                string query = @"
                    SELECT 
                        hc.id_hc AS id_historia,
                        hc.id_paciente,
                        p.nombre AS nombre_paciente,
                        p.apellido AS apellido_paciente,
                        p.dni AS dni_paciente,
                        p.f_nacimiento,
                        u.nombre AS nombre_medico,
                        u.apellido AS apellido_medico,
                        hc.fecha_hora,
                        hc.estado,
                        hc.tipo_consulta,
                        hc.mdc AS motivo,
                        hc.impresion_diagnostica,
                        hc.diagnostico,
                        hc.indicaciones,
                        hc.antecedentes_patologicos AS antecedentes,
                        hc.evolucion AS observaciones
                    FROM historias_clinicas hc
                    INNER JOIN pacientes p ON hc.id_paciente = p.id_paciente
                    LEFT JOIN users u ON hc.id_usuario = u.id_usuario
                    WHERE hc.id_hc = @id_hc;";

                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.AddWithValue("@id_hc", idHistoria);
                    cn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                        tabla.Load(dr);
                }
            }
            return tabla;
        }
    }
}
