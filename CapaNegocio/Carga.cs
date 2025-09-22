using System;
using CapaDatos;

namespace CapaNegocio
{
    public class Carga
    {
        private readonly UsuarioDAO usuarioDAO = new UsuarioDAO();

        public void CargarUsuario(string username, string password, string email,
                                  string nombre, string apellido, decimal dni,
                                  DateTime fNacimiento, string telefono, string rol)
        {
            // 🔹 Generar hash y salt a partir de la contraseña
            var (hash, salt) = PasswordHelper.CrearPasswordHash(password);

            // 🔹 Llamar al DAO para guardar en la base
            usuarioDAO.InsertarUsuario(username, hash, salt, email, nombre, apellido, dni, fNacimiento, telefono, rol);
        }
    }
}
