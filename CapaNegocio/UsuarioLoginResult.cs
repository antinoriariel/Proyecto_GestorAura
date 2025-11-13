namespace CapaNegocio
{
    public class UsuarioLoginResult
    {
        public string Rol { get; set; } = string.Empty;
        public string NombreCompleto { get; set; } = string.Empty;

        // Nuevos campos
        public bool Activo { get; set; }
        public bool PasswordValida { get; set; }
    }
}
