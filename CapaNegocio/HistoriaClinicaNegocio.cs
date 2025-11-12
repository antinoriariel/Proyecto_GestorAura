using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using CapaDatos;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace CapaNegocio
{
    public class HistoriaClinicaNegocio
    {
        private readonly HistoriaClinicaDAO _dao = new();

        // ===============================
        // MÉTODOS EXISTENTES
        // ===============================

        public bool RegistrarHistoriaClinica(
            string nombrePaciente,
            string estado,
            string motivo,
            DateTime fechaHora,
            string impresionDiagnostica,
            string diagnostico,
            string indicaciones,
            string antecedentes,
            string observaciones,
            string tipoConsulta,
            int idUsuarioActual)
        {
            int idPaciente = BuscarIdPacientePorNombre(nombrePaciente);
            if (idPaciente == 0)
                throw new Exception("No se encontró un paciente con ese nombre.");

            return _dao.InsertarHistoriaClinica(
                idPaciente,
                idUsuarioActual,
                motivo,
                estado,
                fechaHora,
                impresionDiagnostica,
                diagnostico,
                indicaciones,
                antecedentes,
                observaciones,
                tipoConsulta
            );
        }

        public List<(int Id, string NombreCompleto)> ObtenerPacientes()
        {
            return _dao.ObtenerPacientes();
        }

        public int BuscarIdPacientePorNombre(string nombreCompleto)
        {
            var lista = _dao.ObtenerPacientes();
            foreach (var p in lista)
            {
                if (string.Equals(p.NombreCompleto, nombreCompleto, StringComparison.OrdinalIgnoreCase))
                    return p.Id;
            }
            return 0;
        }

        public List<string> BuscarPacientes(string texto)
        {
            var resultado = new List<string>();
            var dt = _dao.BuscarPacientesPorNombre(texto);
            foreach (DataRow row in dt.Rows)
                resultado.Add(row["nombre_completo"].ToString()!);
            return resultado;
        }

        // ===============================
        // NUEVOS MÉTODOS PARA DASHBOARD HC
        // ===============================

        /// <summary>
        /// Obtiene todas las historias clínicas con datos de paciente y médico.
        /// Permite filtrar opcionalmente por paciente y fechas.
        /// </summary>
        public DataTable ObtenerHistoriasDetalladas(int? idPaciente = null, DateTime? desde = null, DateTime? hasta = null)
        {
            return _dao.ObtenerHistoriasDetalladas(idPaciente, desde, hasta);
        }

        public bool ActualizarHistoriaClinica(
    int idHistoria,
    string estado,
    string motivo,
    DateTime fechaHora,
    string impresionDiagnostica,
    string diagnostico,
    string indicaciones,
    string antecedentes,
    string observaciones,
    string tipoConsulta,
    int idUsuarioActual)
        {
            return _dao.ActualizarHistoriaClinica(
                idHistoria, estado, motivo, fechaHora, impresionDiagnostica,
                diagnostico, indicaciones, antecedentes, observaciones,
                tipoConsulta, idUsuarioActual);
        }
        public DataTable ObtenerHistoriasPorPaciente(int idPaciente)
        {
            return _dao.ObtenerHistoriasPorPaciente(idPaciente);
        }

        /// <summary>
        /// Exporta una historia clínica a PDF en la ruta indicada.
        /// </summary>
        public void ExportarHistoriaClinicaPDF(int idHistoria, string rutaDestino)
        {
            var dt = _dao.ObtenerHistoriaDetalladaPorId(idHistoria);
            if (dt.Rows.Count == 0)
                throw new Exception("No se encontró la historia clínica.");

            DataRow row = dt.Rows[0];

            // Crear documento PDF (usando nombres completos para evitar ambigüedades)
            iTextSharp.text.Document doc = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4, 50f, 50f, 60f, 60f);

            using (FileStream fs = new FileStream(rutaDestino, FileMode.Create))
            {
                PdfWriter.GetInstance(doc, fs);
                doc.Open();

                // Encabezado
                var titulo = new iTextSharp.text.Paragraph("Historia Clínica",
                    new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 18f, iTextSharp.text.Font.BOLD))
                {
                    Alignment = iTextSharp.text.Element.ALIGN_CENTER,
                    SpacingAfter = 20f
                };
                doc.Add(titulo);

                // Datos del paciente
                var datosPaciente = new iTextSharp.text.pdf.PdfPTable(2)
                {
                    WidthPercentage = 100
                };
                datosPaciente.DefaultCell.Border = 0;

                void AddRow(string label, string value)
                {
                    datosPaciente.AddCell(new iTextSharp.text.Phrase(label,
                        new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 11f, iTextSharp.text.Font.BOLD)));
                    datosPaciente.AddCell(new iTextSharp.text.Phrase(value ?? "-",
                        new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 11f)));
                }

                AddRow("Paciente:", $"{row["nombre_paciente"]} {row["apellido_paciente"]}");
                AddRow("DNI:", row["dni_paciente"].ToString());
                AddRow("Fecha de Nacimiento:", Convert.ToDateTime(row["f_nacimiento"]).ToString("dd/MM/yyyy"));
                AddRow("Médico:", $"{row["nombre_medico"]} {row["apellido_medico"]}");
                AddRow("Fecha y Hora:", Convert.ToDateTime(row["fecha_hora"]).ToString("dd/MM/yyyy HH:mm"));
                AddRow("Estado:", row["estado"].ToString());
                AddRow("Tipo de Consulta:", row["tipo_consulta"].ToString());
                doc.Add(datosPaciente);

                doc.Add(new iTextSharp.text.Paragraph("\n"));

                // Secciones del cuerpo
                void AddSection(string tituloSec, string contenido)
                {
                    var subtitulo = new iTextSharp.text.Paragraph(tituloSec,
                        new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 13f, iTextSharp.text.Font.BOLDITALIC))
                    {
                        SpacingBefore = 8f,
                        SpacingAfter = 2f
                    };
                    doc.Add(subtitulo);
                    doc.Add(new iTextSharp.text.Paragraph(contenido ?? "-",
                        new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 11f)));
                    doc.Add(new iTextSharp.text.Paragraph("\n"));
                }

                AddSection("Motivo de consulta:", row["motivo"].ToString());
                AddSection("Impresión diagnóstica:", row["impresion_diagnostica"].ToString());
                AddSection("Diagnóstico final:", row["diagnostico"].ToString());
                AddSection("Indicaciones:", row["indicaciones"].ToString());
                AddSection("Antecedentes:", row["antecedentes"].ToString());
                AddSection("Observaciones:", row["observaciones"].ToString());

                // Pie de página
                doc.Add(new iTextSharp.text.Paragraph(
                    $"Emitido automáticamente por GestorAura - {DateTime.Now:dd/MM/yyyy HH:mm}",
                    new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 9f,
                        iTextSharp.text.Font.ITALIC, iTextSharp.text.BaseColor.GRAY)
                ));

                doc.Close();
            }
        }
    }
}
