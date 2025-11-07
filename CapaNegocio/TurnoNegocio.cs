using System;
using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class TurnoNegocio
    {
        private readonly TurnoDAO _turnoDao = new TurnoDAO();

        // === LISTADO GENERAL DE TURNOS ===
        public DataTable ObtenerTurnos() => _turnoDao.ObtenerTurnos();

        // === CREAR TURNO ===
        public bool CrearTurno(DateTime fecha, TimeSpan hora, int idPaciente, int idMedico, int idUsuarioCreador, string motivo, string observaciones)
            => _turnoDao.InsertarTurno(fecha, hora, idPaciente, idMedico, idUsuarioCreador, motivo, observaciones);

        // === ACTUALIZAR TURNO ===
        public bool ActualizarTurno(int idTurno, DateTime fecha, TimeSpan hora, int idMedico, string estado, string motivo, string observaciones)
            => _turnoDao.ActualizarTurno(idTurno, fecha, hora, idMedico, estado, motivo, observaciones);

        // === ELIMINAR (LÓGICO) ===
        public bool EliminarTurno(int idTurno)
            => _turnoDao.EliminarTurno(idTurno);

        // === LISTAS AUXILIARES ===
        public DataTable ObtenerPacientes() => _turnoDao.ObtenerPacientes();
        public DataTable ObtenerMedicos() => _turnoDao.ObtenerMedicos();

        // === TURNOS DEL DÍA (por ID de médico, versión anterior) ===
        public DataTable ObtenerTurnosDelDia(DateTime fecha, int? idMedico = null)
            => _turnoDao.ObtenerTurnosDelDia(fecha, idMedico);

        // === NUEVO: TURNOS DEL DÍA FILTRADOS POR NOMBRE DE MÉDICO ===
        public DataTable ObtenerTurnosDelDiaPorNombre(DateTime fecha, string? nombreMedico = null)
            => _turnoDao.ObtenerTurnosDelDiaPorNombre(fecha, nombreMedico);
    }
}
