using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using Microsoft.Data.SqlClient;

namespace CapaDatos
{
    public class PacienteDAO
    {
        private readonly string conexion = ConfigurationManager.ConnectionStrings["conexionBD"].ConnectionString;

        /// <summary>
        /// Lista completa de pacientes (DTO) con control de activos.
        /// </summary>
        public List<PacienteDTO> ObtenerPacientes(bool soloActivos = false)
        {
            List<PacienteDTO> lista = new();

            using SqlConnection conn = new(conexion);
            string query = @"
                SELECT id_paciente, dni, nombre, apellido, sexo, f_nacimiento,
                       telefono, email, direccion, grupo_sanguineo, alergias,
                       created_at, deleted_at
                FROM pacientes
                " + (soloActivos ? "WHERE deleted_at IS NULL" : "") + @"
                ORDER BY apellido, nombre";

            using SqlCommand cmd = new(query, conn);
            conn.Open();

            using SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lista.Add(new PacienteDTO
                {
                    IdPaciente = dr.GetInt32(0),
                    Dni = dr["dni"].ToString(),
                    Nombre = dr["nombre"].ToString(),
                    Apellido = dr["apellido"].ToString(),
                    Sexo = dr["sexo"].ToString(),
                    FechaNac = Convert.ToDateTime(dr["f_nacimiento"]),
                    Telefono = dr["telefono"] is DBNull ? null : dr["telefono"].ToString(),
                    Email = dr["email"] is DBNull ? null : dr["email"].ToString(),
                    Direccion = dr["direccion"] is DBNull ? null : dr["direccion"].ToString(),
                    GrupoSanguineo = dr["grupo_sanguineo"] is DBNull ? null : dr["grupo_sanguineo"].ToString(),
                    Alergias = dr["alergias"] is DBNull ? null : dr["alergias"].ToString(),
                    FechaAlta = Convert.ToDateTime(dr["created_at"]),
                    Activo = dr["deleted_at"] is DBNull
                });
            }
            return lista;
        }

        /// <summary>
        /// NUEVO: devuelve un DataTable con columnas (id_paciente, nombre, apellido),
        /// pensado para combos/listas de selección rápida en la UI.
        /// </summary>
        public DataTable ObtenerListaSimple(bool soloActivos = true)
        {
            var tabla = new DataTable();

            using SqlConnection conn = new(conexion);
            string query = @"
                SELECT id_paciente, nombre, apellido
                FROM pacientes
                " + (soloActivos ? "WHERE deleted_at IS NULL" : "") + @"
                ORDER BY apellido, nombre;";

            using SqlCommand cmd = new(query, conn);
            using SqlDataAdapter da = new(cmd);
            conn.Open();
            da.Fill(tabla);

            return tabla;
        }

        public void InsertarPaciente(PacienteDTO p)
        {
            using SqlConnection conn = new(conexion);
            string query = @"
                INSERT INTO pacientes
                    (dni, nombre, apellido, sexo, f_nacimiento, telefono, email,
                     direccion, grupo_sanguineo, alergias, created_at)
                VALUES
                    (@dni, @nombre, @apellido, @sexo, @f_nac, @tel, @mail,
                     @dir, @grupo, @alergias, GETDATE())";

            using SqlCommand cmd = new(query, conn);
            cmd.Parameters.AddWithValue("@dni", p.Dni);
            cmd.Parameters.AddWithValue("@nombre", p.Nombre);
            cmd.Parameters.AddWithValue("@apellido", p.Apellido);
            cmd.Parameters.AddWithValue("@sexo", p.Sexo);
            cmd.Parameters.AddWithValue("@f_nac", p.FechaNac);
            cmd.Parameters.AddWithValue("@tel", (object?)p.Telefono ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@mail", (object?)p.Email ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@dir", (object?)p.Direccion ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@grupo", (object?)p.GrupoSanguineo ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@alergias", (object?)p.Alergias ?? DBNull.Value);

            conn.Open();
            cmd.ExecuteNonQuery();
        }

        public void ActualizarPaciente(PacienteDTO p)
        {
            using SqlConnection conn = new(conexion);
            string query = @"
                UPDATE pacientes SET
                    dni = @dni,
                    nombre = @nombre,
                    apellido = @apellido,
                    sexo = @sexo,
                    f_nacimiento = @f_nac,
                    telefono = @tel,
                    email = @mail,
                    direccion = @dir,
                    grupo_sanguineo = @grupo,
                    alergias = @alergias,
                    modified_at = GETDATE()
                WHERE id_paciente = @id";

            using SqlCommand cmd = new(query, conn);
            cmd.Parameters.AddWithValue("@id", p.IdPaciente);
            cmd.Parameters.AddWithValue("@dni", p.Dni);
            cmd.Parameters.AddWithValue("@nombre", p.Nombre);
            cmd.Parameters.AddWithValue("@apellido", p.Apellido);
            cmd.Parameters.AddWithValue("@sexo", p.Sexo);
            cmd.Parameters.AddWithValue("@f_nac", p.FechaNac);
            cmd.Parameters.AddWithValue("@tel", (object?)p.Telefono ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@mail", (object?)p.Email ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@dir", (object?)p.Direccion ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@grupo", (object?)p.GrupoSanguineo ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@alergias", (object?)p.Alergias ?? DBNull.Value);

            conn.Open();
            cmd.ExecuteNonQuery();
        }

        public void DarDeBajaPaciente(int idPaciente)
        {
            using SqlConnection conn = new(conexion);
            string query = "UPDATE pacientes SET deleted_at = GETDATE() WHERE id_paciente = @id";
            using SqlCommand cmd = new(query, conn);
            cmd.Parameters.AddWithValue("@id", idPaciente);
            conn.Open();
            cmd.ExecuteNonQuery();
        }

        public void ReactivarPaciente(int idPaciente)
        {
            using SqlConnection conn = new(conexion);
            string query = "UPDATE pacientes SET deleted_at = NULL WHERE id_paciente = @id";
            using SqlCommand cmd = new(query, conn);
            cmd.Parameters.AddWithValue("@id", idPaciente);
            conn.Open();
            cmd.ExecuteNonQuery();
        }
    }

    public class PacienteDTO
    {
        public int IdPaciente { get; set; }
        public string Dni { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Sexo { get; set; }
        public DateTime FechaNac { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
        public string GrupoSanguineo { get; set; }
        public string Alergias { get; set; }
        public DateTime FechaAlta { get; set; }
        public bool Activo { get; set; }
    }
}
