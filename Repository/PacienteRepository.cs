using APICursantes.Models;
using APICursantes.Models.DTO;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace APICursantes.Repository
{
    public class PacienteRepository
    {
        private readonly PacienteContext _context;

        public PacienteRepository(PacienteContext context)
        {
            _context = context;
        }
        public async Task<bool> ActualizarParcial(int id, PacienteDTO paciente)
        {
            var _paciente = await _context.Pacientes.FindAsync(id);
            if (_paciente == null)
                return false;

            // Solo actualizás los campos que vienen con valor
            if (!string.IsNullOrEmpty(paciente.Nombre))
                _paciente.Nombre = paciente.Nombre;

            if (!string.IsNullOrEmpty(paciente.Apellido))
                _paciente.Apellido = paciente.Apellido;

            if (!string.IsNullOrEmpty(paciente.Email))
                _paciente.Email = paciente.Email;

            await _context.SaveChangesAsync();

            return true;
        }
        public async Task<int> TratamientosAsignadosEliminar(int nroPaciente, int idTratamiento)
        {
            return await _context.Database.ExecuteSqlRawAsync(
                "EXEC TratamientosAsignadosEliminar @nroPaciente,@IdTratamiento",
                new SqlParameter("@nroPaciente", nroPaciente),
                new SqlParameter("@idTratamiento", idTratamiento)
            );
        }

    }
}
