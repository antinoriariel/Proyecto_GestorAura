using System;
using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    // DTOs simples
    public record MedicoCrearDto(
        string Username, string Email, string Nombre, string Apellido, long Dni,
        DateTime FechaNacimiento, string? Telefono, bool Activo,
        string Especialidad, string MatriculaProvincial, string? MatriculaNacional);

    public record MedicoActualizarDto(
        int IdUsuario, int IdMedico,
        string Username, string Email, string Nombre, string Apellido, long Dni,
        DateTime FechaNacimiento, string? Telefono, bool Activo,
        string Especialidad, string MatriculaProvincial, string? MatriculaNacional);

    public class MedicoNegocio
    {
        private readonly MedicoDAO _dao = new MedicoDAO();

        public DataTable Listar() => _dao.Listar();

        public (int idUsuario, int idMedico) Crear(MedicoCrearDto dto)
            => _dao.Crear(dto.Username, dto.Email, dto.Nombre, dto.Apellido, dto.Dni,
                          dto.FechaNacimiento, dto.Telefono, dto.Activo,
                          dto.Especialidad, dto.MatriculaProvincial, dto.MatriculaNacional);

        public void Actualizar(MedicoActualizarDto dto)
            => _dao.Actualizar(dto.IdUsuario, dto.IdMedico,
                               dto.Username, dto.Email, dto.Nombre, dto.Apellido, dto.Dni,
                               dto.FechaNacimiento, dto.Telefono, dto.Activo,
                               dto.Especialidad, dto.MatriculaProvincial, dto.MatriculaNacional);

        public void Eliminar(int idUsuario) => _dao.Eliminar(idUsuario);

        public void SetActivo(int idUsuario, bool activo) => _dao.SetActivo(idUsuario, activo);
    }
}
