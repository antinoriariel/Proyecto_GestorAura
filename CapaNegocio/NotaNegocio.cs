using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class NotaNegocio
    {
        private readonly NotaDAO dao = new NotaDAO();

        public DataTable ObtenerNotasPorSecretaria(int idSecretaria)
        {
            return dao.ObtenerNotasPorSecretaria(idSecretaria);
        }

        public DataTable BuscarNotas(int idSecretaria, string filtro)
        {
            return dao.BuscarNotas(idSecretaria, filtro);
        }

        public void InsertarNota(int idSecretaria, string titulo, string cuerpo)
        {
            dao.InsertarNota(idSecretaria, titulo, cuerpo);
        }

        public void ActualizarNota(int idNota, string titulo, string cuerpo)
        {
            dao.ActualizarNota(idNota, titulo, cuerpo);
        }

        public void EliminarNota(int idNota)
        {
            dao.EliminarNota(idNota);
        }
    }
}
