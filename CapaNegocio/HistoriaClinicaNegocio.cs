using System;
using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class HistoriaClinicaNegocio
    {
        private readonly HistoriaClinicaDAO _dao = new();

        public bool RegistrarHistoriaClinica(
            string paciente, string estado, string motivo,
            DateTime fechaHora, string impresionDiag, string diagnostico,
            string indicaciones, string antecedentes, string observaciones,
            string tipoConsulta, int idUsuario)
        {
            // Validaciones básicas a nivel negocio
            if (string.IsNullOrWhiteSpace(paciente)) throw new ArgumentException("Paciente requerido");
            if (string.IsNullOrWhiteSpace(estado)) throw new ArgumentException("Estado requerido");
            if (string.IsNullOrWhiteSpace(diagnostico)) throw new ArgumentException("Diagnóstico requerido");

            return _dao.InsertarHistoriaClinica(
                paciente, estado, motivo, fechaHora, impresionDiag,
                diagnostico, indicaciones, antecedentes, observaciones,
                tipoConsulta, idUsuario);
        }

        public DataTable ObtenerTodas()
        {
            return _dao.ObtenerHistoriasClinicas();
        }
    }
}
