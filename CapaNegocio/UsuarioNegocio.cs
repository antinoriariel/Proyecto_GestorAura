using CapaDatos;
using System;
using System.Data;

namespace CapaNegocio
{
    public class UsuarioNegocio
    {
        private readonly UsuarioDAO _usuarioDAO = new();

        // ===============================================================
        // MÉTODO LOGIN (CORREGIDO)
        // ===============================================================
        public UsuarioLoginResult? Login(string username, string password)
        {
            DataRow? row = _usuarioDAO.ObtenerUsuarioPorUsername(username);

            // Usuario NO existe → devolver null
            if (row == null)
                return null;

            // Extraer hash/salt
            byte[] hash = (byte[])row["password_hash"];
            byte[] salt = (byte[])row["password_salt"];

            bool passwordCorrecta = PasswordHelper.ValidarPassword(password, hash, salt);

            // Devolver SIEMPRE el estado del usuario
            return new UsuarioLoginResult
            {
                Rol = row["rol"].ToString()!,
                NombreCompleto = $"{row["nombre"]} {row["apellido"]}",
                Activo = (bool)row["activo"],
                PasswordValida = passwordCorrecta
            };
        }

        // ===============================================================
        // REGISTRO DE NUEVO USUARIO
        // ===============================================================
        public void RegistrarUsuario(string username, string password, string email,
                                     string nombre, string apellido, decimal dni,
                                     DateTime fNacimiento, string telefono, string rol)
        {
            var (hash, salt) = PasswordHelper.CrearPasswordHash(password);
            _usuarioDAO.InsertarUsuario(username, hash, salt, email, nombre, apellido, dni, fNacimiento, telefono, rol);
        }

        // ===============================================================
        // DATOS DE SECRETARIA
        // ===============================================================
        public DataTable ObtenerDatosSecretaria(string username)
        {
            try
            {
                return _usuarioDAO.ObtenerDatosSecretaria(username);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener datos de la secretaria: " + ex.Message);
            }
        }

        // ===============================================================
        // DATOS DE MÉDICO
        // ===============================================================
        public DataTable ObtenerDatosMedico(string username)
        {
            try
            {
                return _usuarioDAO.ObtenerDatosMedico(username);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener datos del médico: " + ex.Message);
            }
        }

        // ===============================================================
        // ID DE USUARIO POR USERNAME
        // ===============================================================
        public int ObtenerIdPorUsername(string username)
        {
            try
            {
                return _usuarioDAO.ObtenerIdPorUsername(username);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener ID de usuario: " + ex.Message);
            }
        }

        // ===============================================================
        // LISTADO DE USUARIOS PARA CHAT
        // ===============================================================
        public DataTable ObtenerUsuariosChatPorRol(string rolActual)
        {
            try
            {
                return _usuarioDAO.ObtenerUsuariosChatPorRol(rolActual);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener usuarios de chat: " + ex.Message);
            }
        }


        // ===============================================================
        // LISTADO COMPLETO DE USUARIOS
        // ===============================================================
        public DataTable ListarUsuarios(string filtro = "")
        {
            try
            {
                return _usuarioDAO.ListarUsuarios(filtro);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el listado de usuarios: " + ex.Message);
            }
        }

    }
}
