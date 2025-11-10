using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Configuration;

namespace CapaDatos
{
    public class HistoriaClinicaDAO
    {
        private readonly string _connectionString;

        public HistoriaClinicaDAO()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["conexionBD"].ConnectionString;
        }

        // Insertar nueva historia clínica
        public bool InsertarHistoriaClinica(
            string paciente, string estado, string motivo,
            DateTime fechaHora, string impresionDiag, string diagnostico,
            string indicaciones, string antecedentes, string observaciones,
            string tipoConsulta, int idUsuario)
        {
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                cn.Open();
                string query = @"
                    INSERT INTO historias_clinicas
                    (paciente_nombre, estado, motivo, fecha_hora, impresion_diagnostica, diagnostico,
                     indicaciones, antecedentes, observaciones, tipo_consulta, id_usuario)
                    VALUES (@paciente, @estado, @motivo, @fechaHora, @impresionDiag, @diagnostico,
                            @indicaciones, @antecedentes, @observaciones, @tipoConsulta, @idUsuario)";

                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.AddWithValue("@paciente", paciente);
                    cmd.Parameters.AddWithValue("@estado", estado);
                    cmd.Parameters.AddWithValue("@motivo", motivo);
                    cmd.Parameters.AddWithValue("@fechaHora", fechaHora);
                    cmd.Parameters.AddWithValue("@impresionDiag", (object?)impresionDiag ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@diagnostico", diagnostico);
                    cmd.Parameters.AddWithValue("@indicaciones", indicaciones);
                    cmd.Parameters.AddWithValue("@antecedentes", (object?)antecedentes ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@observaciones", (object?)observaciones ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@tipoConsulta", tipoConsulta);
                    cmd.Parameters.AddWithValue("@idUsuario", idUsuario);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // Obtener todas las historias clínicas (para futuras vistas)
        public DataTable ObtenerHistoriasClinicas()
        {
            var tabla = new DataTable();
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                cn.Open();
                string query = "SELECT * FROM historias_clinicas ORDER BY fecha_hora DESC";
                using (SqlDataAdapter da = new SqlDataAdapter(query, cn))
                {
                    da.Fill(tabla);
                }
            }
            return tabla;
        }
    }
}
