using System;
using System.Collections.Generic;
using CapaDatos;

namespace CapaNegocio
{
    public class PacienteNegocio
    {
        private readonly PacienteDAO _dao = new();

        public List<Paciente> ObtenerPacientes(bool soloActivos = false)
        {
            var data = _dao.ObtenerPacientes(soloActivos);
            var lista = new List<Paciente>();
            foreach (var d in data)
            {
                lista.Add(new Paciente
                {
                    IdPaciente = d.IdPaciente,
                    Dni = d.Dni,
                    Nombre = d.Nombre,
                    Apellido = d.Apellido,
                    Sexo = d.Sexo,
                    FechaNac = d.FechaNac,
                    Telefono = d.Telefono,
                    Email = d.Email,
                    Direccion = d.Direccion,
                    GrupoSanguineo = d.GrupoSanguineo,
                    Alergias = d.Alergias,
                    Activo = d.Activo,
                    FechaAlta = d.FechaAlta
                });
            }
            return lista;
        }

        public void RegistrarPaciente(Paciente p)
        {
            Validar(p);
            _dao.InsertarPaciente(ToDTO(p));
        }

        public void ActualizarPaciente(Paciente p)
        {
            Validar(p);
            if (p.IdPaciente <= 0)
                throw new ArgumentException("IdPaciente inválido.");
            _dao.ActualizarPaciente(ToDTO(p));
        }

        public void DarDeBaja(int id) => _dao.DarDeBajaPaciente(id);

        public void Reactivar(int id) => _dao.ReactivarPaciente(id);

        private static void Validar(Paciente p)
        {
            if (string.IsNullOrWhiteSpace(p.Dni))
                throw new ArgumentException("El DNI es obligatorio.");
            if (string.IsNullOrWhiteSpace(p.Nombre))
                throw new ArgumentException("El nombre es obligatorio.");
            if (string.IsNullOrWhiteSpace(p.Apellido))
                throw new ArgumentException("El apellido es obligatorio.");
            if (p.FechaNac >= DateTime.Today)
                throw new ArgumentException("Fecha de nacimiento inválida.");
            if (string.IsNullOrWhiteSpace(p.Sexo))
                throw new ArgumentException("El sexo es obligatorio (H/M).");
        }

        private static PacienteDTO ToDTO(Paciente p) => new()
        {
            IdPaciente = p.IdPaciente,
            Dni = p.Dni,
            Nombre = p.Nombre,
            Apellido = p.Apellido,
            Sexo = p.Sexo,
            FechaNac = p.FechaNac,
            Telefono = p.Telefono,
            Email = p.Email,
            Direccion = p.Direccion,
            GrupoSanguineo = p.GrupoSanguineo,
            Alergias = p.Alergias,
            Activo = p.Activo,
            FechaAlta = p.FechaAlta
        };
    }

    public class Paciente
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
        public bool Activo { get; set; }
        public DateTime FechaAlta { get; set; }
    }
}
