using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace APICursantes.Models.DTO
{
    public class PacienteDTO
    {
        public int? NroPaciente { get; set; }
        public string? Apellido { get; set; }

        public string? Nombre { get; set; }

        public string? TipoDoc { get; set; }

        public string? DNI { get; set; }

        public DateOnly? FechaNac { get; set; }
        public string? Direccion { get; set; }
        public string? Celular { get; set; }
        public string? TelefonoOpcional { get; set; }
        public string? Email { get; set; }
        public string? Ciudad { get; set; }

        public string? ObserSistemaAnterior { get; set; }

        
        public string? Foto { get; set; }
    }
}
