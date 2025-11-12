// CapaNegocio/ArchivoPacienteNegocio.cs
using System;
using System.Data;
using System.IO;
using CapaDatos;

namespace CapaNegocio
{
    public class ArchivoPaciente
    {
        public int IdArchivo { get; set; }
        public int IdPaciente { get; set; }
        public int? IdUsuarioSubidor { get; set; }
        public string NombreOriginal { get; set; } = "";
        public string NombreSistema { get; set; } = "";
        public string? TipoArchivo { get; set; }
        public string RutaArchivo { get; set; } = "";
        public string? Descripcion { get; set; }
        public int? TamañoKb { get; set; }
        public DateTime FechaSubida { get; set; }
        public bool Activo { get; set; } = true;
    }

    public class ArchivoPacienteNegocio
    {
        private readonly ArchivoPacienteDAO _dao = new();

        /// <summary>
        /// Carpeta base donde se guardan los adjuntos. Por defecto: [CarpetaEjecutable]\ArchivosPacientes
        /// </summary>
        public string BasePath { get; set; } =
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ArchivosPacientes");

        /// <summary>
        /// Asegura la carpeta del paciente y retorna la ruta física completa.
        /// </summary>
        private string EnsurePacienteDir(int idPaciente)
        {
            if (!Directory.Exists(BasePath))
                Directory.CreateDirectory(BasePath);

            string dirPaciente = Path.Combine(BasePath, idPaciente.ToString());
            if (!Directory.Exists(dirPaciente))
                Directory.CreateDirectory(dirPaciente);

            return dirPaciente;
        }

        public DataTable ObtenerPorPaciente(int idPaciente) => _dao.ObtenerPorPaciente(idPaciente);

        /// <summary>
        /// Copia el archivo al directorio del paciente con nombre de sistema único y lo registra en BD.
        /// </summary>
        public int SubirArchivo(int idPaciente, int? idUsuarioSubidor, string rutaOrigen, string? descripcion = null)
        {
            if (string.IsNullOrWhiteSpace(rutaOrigen) || !File.Exists(rutaOrigen))
                throw new FileNotFoundException("No se encontró el archivo de origen.", rutaOrigen);

            string dirPaciente = EnsurePacienteDir(idPaciente);

            string nombreOriginal = Path.GetFileName(rutaOrigen);
            string ext = Path.GetExtension(rutaOrigen);
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            string nombreSistema = $"{timestamp}_{Guid.NewGuid():N}{ext}".ToLowerInvariant();

            string destino = Path.Combine(dirPaciente, nombreSistema);
            File.Copy(rutaOrigen, destino, overwrite: false);

            var fi = new FileInfo(rutaOrigen);
            int tamañoKb = (int)Math.Max(1, Math.Round(fi.Length / 1024.0));

            return _dao.Insertar(
                idPaciente: idPaciente,
                idUsuarioSubidor: idUsuarioSubidor,
                nombreOriginal: nombreOriginal,
                nombreSistema: nombreSistema,
                tipoArchivo: ext?.TrimStart('.').ToUpperInvariant(),
                rutaArchivo: destino, // guardamos la ruta física completa para abrir directo
                descripcion: descripcion,
                tamañoKb: tamañoKb
            );
        }

        public bool EliminarLogico(int idArchivo) => _dao.EliminarLogico(idArchivo);

        public DataRow? ObtenerUno(int idArchivo) => _dao.ObtenerUno(idArchivo);

        public bool ActualizarDescripcion(int idArchivo, string? descripcion) =>
            _dao.ActualizarDescripcion(idArchivo, descripcion ?? "");
    }
}
