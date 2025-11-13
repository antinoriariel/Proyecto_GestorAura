using System;
using System.Configuration;
using Microsoft.Data.SqlClient;

namespace CapaDatos
{
    public class BackupDAO
    {
        private readonly string _cadenaConexion =
            ConfigurationManager.ConnectionStrings["conexionBD"].ConnectionString;

        /// <summary>
        /// Obtiene el nombre de la base de datos desde la cadena de conexión.
        /// </summary>
        private string ObtenerNombreBaseDatos()
        {
            var builder = new SqlConnectionStringBuilder(_cadenaConexion);
            return builder.InitialCatalog; // proyecto_gestorAura
        }

        /// <summary>
        /// Ejecuta el BACKUP DATABASE hacia la ruta indicada (.bak).
        /// </summary>
        public void GenerarBackup(string rutaCompletaBak)
        {
            if (string.IsNullOrWhiteSpace(rutaCompletaBak))
                throw new ArgumentException("La ruta de backup no puede estar vacía.");

            string nombreBD = ObtenerNombreBaseDatos();

            using var cn = new SqlConnection(_cadenaConexion);
            cn.Open();

            string sql = $@"
BACKUP DATABASE [{nombreBD}]
TO DISK = @ruta
WITH INIT,
     NAME = @nombreBackup,
     SKIP, NOFORMAT;";

            using var cmd = new SqlCommand(sql, cn);
            cmd.Parameters.AddWithValue("@ruta", rutaCompletaBak);
            cmd.Parameters.AddWithValue("@nombreBackup",
                $"{nombreBD}_Backup_{DateTime.Now:yyyyMMdd_HHmmss}");

            // Si la BD es grande, que no venza el timeout
            cmd.CommandTimeout = 0;

            cmd.ExecuteNonQuery();
        }
    }
}
