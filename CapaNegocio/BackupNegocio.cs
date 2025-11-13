using System;
using System.IO;
using CapaDatos;

namespace CapaNegocio
{
    public class BackupNegocio
    {
        private readonly BackupDAO _dao = new();

        /// <summary>
        /// Genera un backup completo en la carpeta destino:
        ///  - Crea una subcarpeta con fecha/hora.
        ///  - Genera el .bak de la base de datos.
        ///  - Copia la carpeta de adjuntos de pacientes (ArchivosPacientes) si existe.
        /// Devuelve la ruta de la carpeta final del backup.
        /// </summary>
        public string GenerarBackupCompleto(string carpetaDestino)
        {
            if (string.IsNullOrWhiteSpace(carpetaDestino))
                throw new ArgumentException("Debe indicar una carpeta de destino.");

            if (!Directory.Exists(carpetaDestino))
                Directory.CreateDirectory(carpetaDestino);

            string fecha = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            string carpetaBackup = Path.Combine(carpetaDestino, $"Backup_MedicSys_{fecha}");
            Directory.CreateDirectory(carpetaBackup);

            // 1) Archivo .bak de la base de datos
            string archivoBak = Path.Combine(carpetaBackup, "proyecto_gestorAura.bak");
            _dao.GenerarBackup(archivoBak);

            // 2) Copiar adjuntos de pacientes (ArchivosPacientes)
            var archivoNegocio = new ArchivoPacienteNegocio();
            string carpetaAdjuntosOrigen = archivoNegocio.BasePath;

            if (Directory.Exists(carpetaAdjuntosOrigen))
            {
                string carpetaAdjuntosDestino = Path.Combine(carpetaBackup, "ArchivosPacientes");
                CopiarDirectorioRecursivo(carpetaAdjuntosOrigen, carpetaAdjuntosDestino);
            }

            return carpetaBackup;
        }

        private static void CopiarDirectorioRecursivo(string origen, string destino)
        {
            Directory.CreateDirectory(destino);

            foreach (var archivo in Directory.GetFiles(origen))
            {
                string nombre = Path.GetFileName(archivo);
                string destinoArchivo = Path.Combine(destino, nombre);
                File.Copy(archivo, destinoArchivo, overwrite: true);
            }

            foreach (var subdir in Directory.GetDirectories(origen))
            {
                string nombreSub = Path.GetFileName(subdir);
                string destinoSub = Path.Combine(destino, nombreSub);
                CopiarDirectorioRecursivo(subdir, destinoSub);
            }
        }
    }
}
