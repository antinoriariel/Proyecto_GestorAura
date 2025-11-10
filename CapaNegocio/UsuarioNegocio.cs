using CapaDatos;
using System;
using System.Data;

namespace CapaNegocio
{
    public class UsuarioNegocio
    {
        private readonly UsuarioDAO usuarioDAO = new UsuarioDAO();

        // ===============================================================
        // MÉTODO LOGIN
        // ===============================================================
        public UsuarioLoginResult? Login(string username, string password)
        {
            DataRow? row = usuarioDAO.ObtenerUsuarioPorUsername(username);
            if (row == null) return null;
            if (!(bool)row["activo"]) return null;

            byte[] hash = (byte[])row["password_hash"];
            byte[] salt = (byte[])row["password_salt"];

            bool valido = PasswordHelper.ValidarPassword(password, hash, salt);
            if (valido)
            {
                return new UsuarioLoginResult
                {
                    Rol = row["rol"].ToString()!,
                    NombreCompleto = $"{row["nombre"]} {row["apellido"]}"
                };
            }

            return null;
        }

        // ===============================================================
        // MÉTODO REGISTRO DE USUARIO
        // ===============================================================
        public void RegistrarUsuario(string username, string password, string email,
                                     string nombre, string apellido, decimal dni,
                                     DateTime fNacimiento, string telefono, string rol)
        {
            var (hash, salt) = PasswordHelper.CrearPasswordHash(password);
            usuarioDAO.InsertarUsuario(username, hash, salt, email, nombre, apellido, dni, fNacimiento, telefono, rol);
        }

        // ===============================================================
        // NUEVO MÉTODO: Obtener datos generales de la secretaria
        // ===============================================================
        public DataTable ObtenerDatosSecretaria(string username)
        {
            return usuarioDAO.ObtenerDatosSecretaria(username);
        }

        // ===============================================================
        // NUEVO MÉTODO: Obtener ID de usuario por username
        // ===============================================================
        public int ObtenerIdPorUsername(string username)
        {
            return usuarioDAO.ObtenerIdPorUsername(username);
        }

        public DataTable ObtenerUsuariosChatPorRol(string rolActual)
        {
            return usuarioDAO.ObtenerUsuariosChatPorRol(rolActual);
        }

    }
}
