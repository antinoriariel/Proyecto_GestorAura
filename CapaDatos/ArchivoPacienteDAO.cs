// CapaDatos/ArchivoPacienteDAO.cs
using System;
using System.Data;
using System.Configuration;
using Microsoft.Data.SqlClient;

namespace CapaDatos
{
    public class ArchivoPacienteDAO
    {
        private readonly string _connectionString;

        public ArchivoPacienteDAO()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["conexionBD"].ConnectionString;
        }

        public DataTable ObtenerPorPaciente(int idPaciente)
        {
            using var cn = new SqlConnection(_connectionString);
            using var da = new SqlDataAdapter(@"
                SELECT 
                    id_archivo,
                    id_paciente,
                    id_usuario_subidor,
                    nombre_original,
                    nombre_sistema,
                    tipo_archivo,
                    ruta_archivo,
                    descripcion,
                    tamaño_kb,
                    fecha_subida,
                    activo
                FROM archivos_pacientes
                WHERE id_paciente = @idPaciente AND activo = 1
                ORDER BY fecha_subida DESC;", cn);

            da.SelectCommand.Parameters.Add("@idPaciente", SqlDbType.Int).Value = idPaciente;
            var tabla = new DataTable();
            da.Fill(tabla);
            return tabla;
        }

        public int Insertar(
            int idPaciente,
            int? idUsuarioSubidor,
            string nombreOriginal,
            string nombreSistema,
            string tipoArchivo,
            string rutaArchivo,
            string descripcion,
            int? tamañoKb)
        {
            using var cn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(@"
                INSERT INTO archivos_pacientes
                (id_paciente, id_usuario_subidor, nombre_original, nombre_sistema, tipo_archivo, ruta_archivo, descripcion, tamaño_kb)
                OUTPUT INSERTED.id_archivo
                VALUES (@id_paciente, @id_usuario_subidor, @nombre_original, @nombre_sistema, @tipo_archivo, @ruta_archivo, @descripcion, @tamaño_kb);", cn);

            cmd.Parameters.Add("@id_paciente", SqlDbType.Int).Value = idPaciente;
            if (idUsuarioSubidor.HasValue)
                cmd.Parameters.Add("@id_usuario_subidor", SqlDbType.Int).Value = idUsuarioSubidor.Value;
            else
                cmd.Parameters.Add("@id_usuario_subidor", SqlDbType.Int).Value = DBNull.Value;

            cmd.Parameters.Add("@nombre_original", SqlDbType.NVarChar, 255).Value = nombreOriginal;
            cmd.Parameters.Add("@nombre_sistema", SqlDbType.NVarChar, 255).Value = nombreSistema ?? (object)DBNull.Value;
            cmd.Parameters.Add("@tipo_archivo", SqlDbType.NVarChar, 50).Value = (object?)tipoArchivo ?? DBNull.Value;
            cmd.Parameters.Add("@ruta_archivo", SqlDbType.NVarChar, 500).Value = rutaArchivo;
            cmd.Parameters.Add("@descripcion", SqlDbType.NVarChar, 500).Value = (object?)descripcion ?? DBNull.Value;
            if (tamañoKb.HasValue) cmd.Parameters.Add("@tamaño_kb", SqlDbType.Int).Value = tamañoKb.Value;
            else cmd.Parameters.Add("@tamaño_kb", SqlDbType.Int).Value = DBNull.Value;

            cn.Open();
            return (int)cmd.ExecuteScalar();
        }

        public bool EliminarLogico(int idArchivo)
        {
            using var cn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(@"
                UPDATE archivos_pacientes
                SET activo = 0, fecha_subida = fecha_subida
                WHERE id_archivo = @id", cn);

            cmd.Parameters.Add("@id", SqlDbType.Int).Value = idArchivo;
            cn.Open();
            return cmd.ExecuteNonQuery() > 0;
        }

        public DataRow? ObtenerUno(int idArchivo)
        {
            using var cn = new SqlConnection(_connectionString);
            using var da = new SqlDataAdapter(@"
                SELECT TOP 1 *
                FROM archivos_pacientes
                WHERE id_archivo = @id;", cn);

            da.SelectCommand.Parameters.Add("@id", SqlDbType.Int).Value = idArchivo;

            var tabla = new DataTable();
            da.Fill(tabla);
            return tabla.Rows.Count > 0 ? tabla.Rows[0] : null;
        }

        public bool ActualizarDescripcion(int idArchivo, string descripcion)
        {
            using var cn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(@"
                UPDATE archivos_pacientes
                SET descripcion = @desc
                WHERE id_archivo = @id;", cn);

            cmd.Parameters.Add("@id", SqlDbType.Int).Value = idArchivo;
            cmd.Parameters.Add("@desc", SqlDbType.NVarChar, 500).Value = (object?)descripcion ?? DBNull.Value;

            cn.Open();
            return cmd.ExecuteNonQuery() > 0;
        }
    }
}
