using System;
using System.Collections.Generic;
using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class PacienteNegocio
    {
        private readonly PacienteDAO _dao = new();

        // =======================================================
        // NUEVO MÉTODO PARA LISTA SIMPLE (para combos / grillas)
        // =======================================================
        /// <summary>
        /// Devuelve una lista simple de pacientes (id_paciente, nombre_completo)
        /// ideal para combos o listas rápidas en la interfaz.
        /// </summary>
        public DataTable ObtenerListaSimple(bool soloActivos = true)
        {
            // Se obtiene desde el DAO (ya implementado en CapaDatos)
            var tabla = _dao.ObtenerListaSimple(soloActivos);

            // Se agrega una columna calculada para mostrar "Apellido, Nombre"
            if (!tabla.Columns.Contains("nombre_completo"))
                tabla.Columns.Add("nombre_completo", typeof(string));

            foreach (DataRow row in tabla.Rows)
            {
                string nombre = row["nombre"].ToString();
                string apellido = row["apellido"].ToString();
                row["nombre_completo"] = $"{apellido}, {nombre}";
            }

            return tabla;
        }

        // =======================================================
        // MÉTODOS EXISTENTES
        // =======================================================

        /// <summary>
        /// Devuelve una lista completa de pacientes como objetos de negocio.
        /// </summary>
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

        /// <summary>
        /// Registra un nuevo paciente después de validar sus datos.
        /// </summary>
        public void RegistrarPaciente(Paciente p)
        {
            Validar(p);
            _dao.InsertarPaciente(ToDTO(p));
        }

        /// <summary>
        /// Actualiza los datos de un paciente existente.
        /// </summary>
        public void ActualizarPaciente(Paciente p)
        {
            Validar(p);
            if (p.IdPaciente <= 0)
                throw new ArgumentException("IdPaciente inválido.");
            _dao.ActualizarPaciente(ToDTO(p));
        }

        /// <summary>
        /// Marca un paciente como dado de baja (deleted_at = GETDATE()).
        /// </summary>
        public void DarDeBaja(int id) => _dao.DarDeBajaPaciente(id);

        /// <summary>
        /// Reactiva un paciente dado de baja (deleted_at = NULL).
        /// </summary>
        public void Reactivar(int id) => _dao.ReactivarPaciente(id);

        // =======================================================
        // VALIDACIÓN Y MAPEO
        // =======================================================
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

        public DataTable ObtenerPacientePorId(int idPaciente)
        {
            return _dao.ObtenerPacientePorId(idPaciente);
        }

    }

    // =======================================================
    // ENTIDAD DE NEGOCIO: PACIENTE
    // =======================================================
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
