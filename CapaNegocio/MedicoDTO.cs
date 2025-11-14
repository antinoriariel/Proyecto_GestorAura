namespace CapaNegocio
{
    public class MedicoDTO
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
}
