using System;
using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class MensajeNegocio
    {
        private readonly MensajeDAO _dao = new MensajeDAO();

        public DataTable ObtenerConversacion(int idUsuarioActual, int idOtro)
        {
            return _dao.ObtenerConversacion(idUsuarioActual, idOtro);
        }

        public void EnviarMensaje(int idRemitente, int idDestinatario, string cuerpo)
        {
            if (string.IsNullOrWhiteSpace(cuerpo))
                throw new ArgumentException("El mensaje no puede estar vacío.");

            _dao.InsertarMensaje(idRemitente, idDestinatario, cuerpo.Trim());
        }

        public DataTable ObtenerConversaciones(int idUsuario)
        {
            return _dao.ObtenerConversacionesDelUsuario(idUsuario);
        }
    }
}
