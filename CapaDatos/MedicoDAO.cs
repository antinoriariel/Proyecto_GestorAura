using System;
using System.Data;
using System.Configuration;
using Microsoft.Data.SqlClient;

namespace CapaDatos
{
    public class MedicoDAO
    {
        private readonly string _cn;

        public MedicoDAO()
        {
            _cn = ConfigurationManager.ConnectionStrings["conexionBD"]?.ConnectionString
                  ?? throw new ConfigurationErrorsException("Falta connectionStrings: conexionBD");
        }

        // ============================================================
        // LISTAR MÉDICOS
        // ============================================================
        public DataTable Listar()
        {
            using var con = new SqlConnection(_cn);
            using var da = new SqlDataAdapter(@"
                SELECT 
                    u.id_usuario,
                    m.id_medico,
                    u.nombre AS Nombre,
                    u.apellido AS Apellido,
                    m.especialidad AS Especialidad,
                    m.matricula_provincial AS MatriculaProvincial,
                    m.matricula_nacional AS MatriculaNacional,
                    u.username,
                    u.email,
                    u.dni,
                    u.f_nacimiento,
                    u.telefono,
                    u.activo
                FROM medicos m
                INNER JOIN users u ON u.id_usuario = m.id_usuario
                WHERE u.rol = 'medico' AND u.deleted_at IS NULL
                ORDER BY u.apellido, u.nombre;", con);

            var tabla = new DataTable();
            da.Fill(tabla);
            return tabla;
        }

        // ============================================================
        // OBTENER MÉDICO POR ID_USUARIO (1 SOLO REGISTRO)
        // ============================================================
        public DataRow? ObtenerMedicoPorIdUsuario(int idUsuario)
        {
            using var con = new SqlConnection(_cn);
            using var da = new SqlDataAdapter(@"
                SELECT 
                    u.id_usuario,
                    m.id_medico,
                    u.username,
                    u.nombre,
                    u.apellido,
                    u.email,
                    u.dni,
                    u.f_nacimiento,
                    u.telefono,
                    u.activo,
                    m.especialidad AS Especialidad,
                    m.matricula_provincial AS MatriculaProvincial,
                    m.matricula_nacional AS MatriculaNacional
                FROM medicos m
                INNER JOIN users u ON m.id_usuario = u.id_usuario
                WHERE u.id_usuario = @id
                  AND u.rol = 'medico'
                  AND u.deleted_at IS NULL;",
                con);

            da.SelectCommand.Parameters.AddWithValue("@id", idUsuario);

            var tabla = new DataTable();
            da.Fill(tabla);

            return tabla.Rows.Count == 0 ? null : tabla.Rows[0];
        }

        // ============================================================
        // CREAR MÉDICO (con hash + salt)
        // ============================================================
        public (int idUsuario, int idMedico) Crear(
            string username,
            byte[] passwordHash,
            byte[] passwordSalt,
            string email,
            string nombre,
            string apellido,
            long dni,
            DateTime fNac,
            string? telefono,
            bool activo,
            string especialidad,
            string matriculaProv,
            string? matriculaNac)
        {
            using var con = new SqlConnection(_cn);
            con.Open();
            using var tx = con.BeginTransaction();

            try
            {
                var cmdUser = new SqlCommand(@"
INSERT INTO users 
    (username, password_hash, password_salt, email, nombre, apellido, dni, f_nacimiento, telefono, created_at, activo, rol)
VALUES 
    (@username, @hash, @salt, @email, @nombre, @apellido, @dni, @f_nac, @telefono, SYSUTCDATETIME(), @activo, 'medico');
SELECT CAST(SCOPE_IDENTITY() AS INT);", con, tx);

                cmdUser.Parameters.AddWithValue("@username", username);
                cmdUser.Parameters.Add("@hash", SqlDbType.VarBinary, 256).Value = passwordHash;
                cmdUser.Parameters.Add("@salt", SqlDbType.VarBinary, 128).Value = passwordSalt;
                cmdUser.Parameters.AddWithValue("@email", email);
                cmdUser.Parameters.AddWithValue("@nombre", nombre);
                cmdUser.Parameters.AddWithValue("@apellido", apellido);
                cmdUser.Parameters.AddWithValue("@dni", dni);
                cmdUser.Parameters.AddWithValue("@f_nac", fNac);
                cmdUser.Parameters.AddWithValue("@telefono", (object?)telefono ?? DBNull.Value);
                cmdUser.Parameters.AddWithValue("@activo", activo ? 1 : 0);

                int idUsuario = (int)cmdUser.ExecuteScalar();

                var cmdMed = new SqlCommand(@"
INSERT INTO medicos (id_usuario, especialidad, matricula_provincial, matricula_nacional)
VALUES (@id_usuario, @esp, @mp, @mn);
SELECT CAST(SCOPE_IDENTITY() AS INT);", con, tx);

                cmdMed.Parameters.AddWithValue("@id_usuario", idUsuario);
                cmdMed.Parameters.AddWithValue("@esp", especialidad);
                cmdMed.Parameters.AddWithValue("@mp", matriculaProv);
                cmdMed.Parameters.AddWithValue("@mn", (object?)matriculaNac ?? DBNull.Value);

                int idMedico = (int)cmdMed.ExecuteScalar();

                tx.Commit();
                return (idUsuario, idMedico);
            }
            catch
            {
                tx.Rollback();
                throw;
            }
        }

        // ============================================================
        // ACTUALIZAR MÉDICO
        // ============================================================
        public void Actualizar(
            int idUsuario,
            int idMedico,
            string username,
            string email,
            string nombre,
            string apellido,
            long dni,
            DateTime fNac,
            string? telefono,
            bool activo,
            string especialidad,
            string matriculaProv,
            string? matriculaNac)
        {
            using var con = new SqlConnection(_cn);
            con.Open();
            using var tx = con.BeginTransaction();

            try
            {
                var cmdU = new SqlCommand(@"
UPDATE users
SET username=@username, email=@email, nombre=@nombre, apellido=@apellido,
    dni=@dni, f_nacimiento=@f_nac, telefono=@tel, modified_at=SYSUTCDATETIME(), activo=@activo
WHERE id_usuario=@idU;", con, tx);

                cmdU.Parameters.AddWithValue("@username", username);
                cmdU.Parameters.AddWithValue("@email", email);
                cmdU.Parameters.AddWithValue("@nombre", nombre);
                cmdU.Parameters.AddWithValue("@apellido", apellido);
                cmdU.Parameters.AddWithValue("@dni", dni);
                cmdU.Parameters.AddWithValue("@f_nac", fNac);
                cmdU.Parameters.AddWithValue("@tel", (object?)telefono ?? DBNull.Value);
                cmdU.Parameters.AddWithValue("@activo", activo ? 1 : 0);
                cmdU.Parameters.AddWithValue("@idU", idUsuario);
                cmdU.ExecuteNonQuery();

                var cmdM = new SqlCommand(@"
UPDATE medicos
SET especialidad=@esp, matricula_provincial=@mp, matricula_nacional=@mn, modified_at=SYSUTCDATETIME()
WHERE id_medico=@idM;", con, tx);

                cmdM.Parameters.AddWithValue("@esp", especialidad);
                cmdM.Parameters.AddWithValue("@mp", matriculaProv);
                cmdM.Parameters.AddWithValue("@mn", (object?)matriculaNac ?? DBNull.Value);
                cmdM.Parameters.AddWithValue("@idM", idMedico);
                cmdM.ExecuteNonQuery();

                tx.Commit();
            }
            catch
            {
                tx.Rollback();
                throw;
            }
        }

        // ============================================================
        // ELIMINAR
        // ============================================================
        public void Eliminar(int idUsuario)
        {
            using var con = new SqlConnection(_cn);
            con.Open();
            using var tx = con.BeginTransaction();

            try
            {
                var cmd = new SqlCommand("DELETE FROM users WHERE id_usuario=@id;", con, tx);
                cmd.Parameters.AddWithValue("@id", idUsuario);
                cmd.ExecuteNonQuery();
                tx.Commit();
            }
            catch
            {
                tx.Rollback();
                throw;
            }
        }

        // ============================================================
        // ACTIVAR / DESACTIVAR
        // ============================================================
        public void SetActivo(int idUsuario, bool activo)
        {
            using var con = new SqlConnection(_cn);
            var cmd = new SqlCommand(
                "UPDATE users SET activo=@a, modified_at=SYSUTCDATETIME() WHERE id_usuario=@id;",
                con);

            cmd.Parameters.AddWithValue("@a", activo ? 1 : 0);
            cmd.Parameters.AddWithValue("@id", idUsuario);

            con.Open();
            cmd.ExecuteNonQuery();
        }
    }
}
