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

        // =====================================
        // EXPORTAR HISTORIA CLÍNICA A PDF (PRO)
        // =====================================
        public void ExportarHistoriaClinicaPDF(int idHistoria, string rutaDestino)
        {
            var dt = _dao.ObtenerHistoriaDetalladaPorId(idHistoria);
            if (dt.Rows.Count == 0)
                throw new Exception("No se encontró la historia clínica.");

            DataRow row = dt.Rows[0];

            Document doc = new Document(PageSize.A4, 55f, 55f, 70f, 60f);
            using (FileStream fs = new FileStream(rutaDestino, FileMode.Create))
            {
                PdfWriter writer = PdfWriter.GetInstance(doc, fs);
                doc.Open();

                // ====== ENCABEZADO ======
                PdfPTable header = new PdfPTable(2);
                header.WidthPercentage = 100;
                header.SetWidths(new float[] { 1.2f, 4f });
                header.DefaultCell.Border = Rectangle.NO_BORDER;

                string logoPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "logo_gestoraura.png");
                if (File.Exists(logoPath))
                {
                    iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(logoPath);
                    logo.ScaleAbsolute(70f, 70f);
                    PdfPCell logoCell = new PdfPCell(logo)
                    {
                        Border = Rectangle.NO_BORDER,
                        HorizontalAlignment = Element.ALIGN_LEFT,
                        VerticalAlignment = Element.ALIGN_MIDDLE,
                        PaddingBottom = 5f
                    };
                    header.AddCell(logoCell);
                }
                else
                {
                    header.AddCell(new PdfPCell(new Phrase("GestorAura", new Font(Font.FontFamily.HELVETICA, 16f, Font.BOLD)))
                    {
                        Border = Rectangle.NO_BORDER,
                        PaddingTop = 25f
                    });
                }

                PdfPCell titleCell = new PdfPCell(new Phrase("HISTORIA CLÍNICA\nSistema GestorAura",
                    new Font(Font.FontFamily.HELVETICA, 16f, Font.BOLD, new BaseColor(0, 0, 0))))
                {
                    Border = Rectangle.NO_BORDER,
                    HorizontalAlignment = Element.ALIGN_RIGHT,
                    VerticalAlignment = Element.ALIGN_MIDDLE,
                    PaddingTop = 15f
                };
                header.AddCell(titleCell);
                doc.Add(header);

                DrawLine(doc, writer, 50, 740);
                doc.Add(new Paragraph("\n"));

                // ====== DATOS DEL PACIENTE ======
                PdfPTable tabla = new PdfPTable(2)
                {
                    WidthPercentage = 100,
                    SpacingAfter = 20f
                };
                tabla.SetWidths(new float[] { 2f, 4f });

                Font fLabel = new Font(Font.FontFamily.HELVETICA, 11f, Font.BOLD, new BaseColor(0, 0, 0));
                Font fValue = new Font(Font.FontFamily.HELVETICA, 11f, Font.NORMAL, BaseColor.BLACK);
                BaseColor altColor = new BaseColor(238, 238, 238);

                void AddRow(string label, string val, bool shaded)
                {
                    BaseColor bg = shaded ? altColor : BaseColor.WHITE;
                    PdfPCell c1 = new PdfPCell(new Phrase(label, fLabel)) { Border = Rectangle.NO_BORDER, BackgroundColor = bg, Padding = 4f };
                    PdfPCell c2 = new PdfPCell(new Phrase(val ?? "-", fValue)) { Border = Rectangle.NO_BORDER, BackgroundColor = bg, Padding = 4f };
                    tabla.AddCell(c1);
                    tabla.AddCell(c2);
                }

                bool shade = false;
                AddRow("Paciente:", $"{row["nombre_paciente"]} {row["apellido_paciente"]}", shade = !shade);
                AddRow("DNI:", row["dni_paciente"].ToString(), shade = !shade);
                AddRow("Fecha de Nacimiento:", Convert.ToDateTime(row["f_nacimiento"]).ToString("dd/MM/yyyy"), shade = !shade);
                AddRow("Médico:", $"{row["nombre_medico"]} {row["apellido_medico"]}", shade = !shade);
                AddRow("Fecha y Hora:", Convert.ToDateTime(row["fecha_hora"]).ToString("dd/MM/yyyy HH:mm"), shade = !shade);
                AddRow("Estado:", row["estado"].ToString(), shade = !shade);
                AddRow("Tipo de Consulta:", row["tipo_consulta"].ToString(), shade = !shade);

                doc.Add(tabla);

                // ====== SECCIONES ======
                Font fSec = new Font(Font.FontFamily.HELVETICA, 13f, Font.BOLD, new BaseColor(0, 136, 204)); // azul institucional
                Font fBody = new Font(Font.FontFamily.HELVETICA, 11f, Font.NORMAL, BaseColor.DARK_GRAY);

                void AddSection(string titulo, string contenido)
                {
                    Paragraph sec = new Paragraph(titulo + ":", fSec) { SpacingBefore = 8f, SpacingAfter = 4f };
                    Paragraph body = new Paragraph(string.IsNullOrWhiteSpace(contenido) ? "-" : contenido, fBody)
                    { SpacingAfter = 8f };
                    doc.Add(sec);
                    doc.Add(body);
                }

                AddSection("Motivo de consulta", row["motivo"].ToString());
                AddSection("Impresión diagnóstica", row["impresion_diagnostica"].ToString());
                AddSection("Diagnóstico final", row["diagnostico"].ToString());
                AddSection("Indicaciones", row["indicaciones"].ToString());
                AddSection("Antecedentes", row["antecedentes"].ToString());
                AddSection("Observaciones", row["observaciones"].ToString());

                // ====== FIRMA Y PIE ======
                doc.Add(new Paragraph("\n"));
                DrawLine(doc, writer, 120, 120);

                Paragraph firma = new Paragraph("Firma del profesional",
                    new Font(Font.FontFamily.HELVETICA, 10f, Font.ITALIC, BaseColor.GRAY))
                {
                    Alignment = Element.ALIGN_CENTER,
                    SpacingAfter = 20f
                };
                doc.Add(firma);

                Paragraph pie = new Paragraph($"Emitido automáticamente por GestorAura - {DateTime.Now:dd/MM/yyyy HH:mm}",
                    new Font(Font.FontFamily.HELVETICA, 9f, Font.ITALIC, BaseColor.GRAY))
                {
                    Alignment = Element.ALIGN_CENTER
                };
                doc.Add(pie);

                doc.Close();
            }
        }

        // ======= LÍNEA AUXILIAR =======
        private static void DrawLine(Document doc, PdfWriter writer, float left, float y)
        {
            PdfContentByte cb = writer.DirectContent;
            cb.SetColorStroke(BaseColor.LIGHT_GRAY);
            cb.SetLineWidth(0.8f);
            cb.MoveTo(left, y);
            cb.LineTo(doc.PageSize.Width - left, y);
            cb.Stroke();
        }
    }
}
