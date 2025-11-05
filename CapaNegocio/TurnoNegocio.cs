using System;
using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class TurnoNegocio
    {
        private readonly TurnoDAO _turnoDao = new TurnoDAO();

        public DataTable ObtenerTurnos() => _turnoDao.ObtenerTurnos();
        public bool CrearTurno(DateTime fecha, TimeSpan hora, int idPaciente, int idMedico, int idUsuarioCreador, string motivo, string observaciones)
            => _turnoDao.InsertarTurno(fecha, hora, idPaciente, idMedico, idUsuarioCreador, motivo, observaciones);
        public bool ActualizarTurno(int idTurno, DateTime fecha, TimeSpan hora, int idMedico, string estado, string motivo, string observaciones)
            => _turnoDao.ActualizarTurno(idTurno, fecha, hora, idMedico, estado, motivo, observaciones);
        public bool EliminarTurno(int idTurno)
            => _turnoDao.EliminarTurno(idTurno);

        public DataTable ObtenerPacientes() => _turnoDao.ObtenerPacientes();
        public DataTable ObtenerMedicos() => _turnoDao.ObtenerMedicos();
    }
}
