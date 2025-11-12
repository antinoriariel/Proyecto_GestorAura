using System;
using System.Collections.Generic;
using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class HistoriaClinicaNegocio
    {
        private readonly HistoriaClinicaDAO _dao = new();

        public bool RegistrarHistoriaClinica(
            string nombrePaciente,
            string estado,              // ya mapeado: 'abierta','cerrada','archivada'
            string motivo,
            DateTime fechaHora,
            string impresionDiagnostica,
            string diagnostico,
            string indicaciones,
            string antecedentes,
            string observaciones,
            string tipoConsulta,        // ya mapeado: 'guardia','consulta','control','internacion'
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

        public List<String> BuscarPacientes(string texto)
        {
            var resultado = new List<string>();
            var dt = _dao.BuscarPacientesPorNombre(texto);
            foreach (DataRow row in dt.Rows)
                resultado.Add(row["nombre_completo"].ToString()!);
            return resultado;
        }
    }
}
