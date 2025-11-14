using System;
using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class Medico
    {
        public int IdUsuario { get; set; }
        public int IdMedico { get; set; }

        public string Username { get; set; } = "";
        public string Nombre { get; set; } = "";
        public string Apellido { get; set; } = "";
        public string Email { get; set; } = "";

        public long Dni { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string? Telefono { get; set; }
        public bool Activo { get; set; }

        public string Especialidad { get; set; } = "";
        public string MatriculaProvincial { get; set; } = "";
        public string? MatriculaNacional { get; set; }
    }

    // ============================
    // DTOs
    // ============================
    public record MedicoCrearDto(
        string Username,
        string Password,
        string Email,
        string Nombre,
        string Apellido,
        long Dni,
        DateTime FechaNacimiento,
        string? Telefono,
        bool Activo,
        string Especialidad,
        string MatriculaProvincial,
        string? MatriculaNacional
    );

    public record MedicoActualizarDto(
        int IdUsuario,
        int IdMedico,
        string Username,
        string Email,
        string Nombre,
        string Apellido,
        long Dni,
        DateTime FechaNacimiento,
        string? Telefono,
        bool Activo,
        string Especialidad,
        string MatriculaProvincial,
        string? MatriculaNacional
    );

    public class MedicoNegocio
    {
        private readonly MedicoDAO _dao = new();

        public DataTable Listar() => _dao.Listar();

        // ============================================================
        // CREAR MÉDICO (con hash + salt usando PasswordHelper)
        // ============================================================
        public (int idUsuario, int idMedico) Crear(MedicoCrearDto dto)
        {
            // Crear hash + salt usando tu helper real
            var (hash, salt) = PasswordHelper.CrearPasswordHash(dto.Password);

            return _dao.Crear(
                dto.Username,
                hash,
                salt,
                dto.Email,
                dto.Nombre,
                dto.Apellido,
                dto.Dni,
                dto.FechaNacimiento,
                dto.Telefono,
                dto.Activo,
                dto.Especialidad,
                dto.MatriculaProvincial,
                dto.MatriculaNacional
            );
        }

        // ============================================================
        // ACTUALIZAR
        // (no cambia contraseña aquí, sólo datos básicos)
        // ============================================================
        public void Actualizar(MedicoActualizarDto dto)
            => _dao.Actualizar(
                dto.IdUsuario,
                dto.IdMedico,
                dto.Username,
                dto.Email,
                dto.Nombre,
                dto.Apellido,
                dto.Dni,
                dto.FechaNacimiento,
                dto.Telefono,
                dto.Activo,
                dto.Especialidad,
                dto.MatriculaProvincial,
                dto.MatriculaNacional
            );

        public void Eliminar(int idUsuario) => _dao.Eliminar(idUsuario);

        public void SetActivo(int idUsuario, bool activo) => _dao.SetActivo(idUsuario, activo);

        // ============================================================
        // OBTENER MÉDICO LOGUEADO (POR ID)
        // ============================================================
        public Medico? ObtenerPorIdUsuario(int idUsuario)
        {
            DataRow? row = _dao.ObtenerMedicoPorIdUsuario(idUsuario);
            if (row == null)
                return null;

            return new Medico
            {
                IdUsuario = Convert.ToInt32(row["id_usuario"]),
                IdMedico = Convert.ToInt32(row["id_medico"]),
                Username = row["username"].ToString()!,
                Nombre = row["nombre"].ToString()!,
                Apellido = row["apellido"].ToString()!,
                Email = row["email"].ToString()!,
                Dni = Convert.ToInt64(row["dni"]),
                FechaNacimiento = Convert.ToDateTime(row["f_nacimiento"]),
                Telefono = row["telefono"] == DBNull.Value ? null : row["telefono"].ToString(),
                Activo = Convert.ToBoolean(row["activo"]),
                Especialidad = row["Especialidad"].ToString()!,
                MatriculaProvincial = row["MatriculaProvincial"].ToString()!,
                MatriculaNacional =
                    row["MatriculaNacional"] == DBNull.Value
                        ? null
                        : row["MatriculaNacional"].ToString()
            };
        }
    }
}
