using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace APICursantes.Models.DTO
{
    public class CursanteCreateDTO
    {
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public    short TipoDoc { get; set; }
        public    string DNI { get; set; }
        public DateOnly FechaNac { get; set; }
        public   string Direccion { get; set; }
        public    string Celular { get; set; }
        public    string TelefonoOpcional { get; set; }
        public    string EMail { get; set; }
        public    int Ciudad { get; set; }
		public    string Obser { get; set; }
		public    string Foto { get; set; }
    }
}
