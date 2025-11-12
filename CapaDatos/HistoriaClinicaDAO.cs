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
                    cmd.Parameters.AddWithValue("@tipo_consulta", (object?)tipoConsulta ?? DBNull.Value); // 'guardia','consulta','control','internacion'
                    cmd.Parameters.AddWithValue("@estado", string.IsNullOrWhiteSpace(estado) ? "abierta" : estado); // 'abierta','cerrada','archivada'
                    cmd.Parameters.AddWithValue("@fecha_hora", fechaHora);

                    cn.Open();
                    int filas = cmd.ExecuteNonQuery();
                    return filas > 0;
                }
            }
        }

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
                        {
                            lista.Add((dr.GetInt32(0), dr.GetString(1)));
                        }
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
                    {
                        tabla.Load(dr);
                    }
                }
            }
            return tabla;
        }
    }
}
