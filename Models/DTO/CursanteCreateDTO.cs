using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace APICursantes.Models.DTO
{
    public class CursanteCreateDTO
    {
        string Apellido { get; set; }
        string Nombre { get; set; }
           int TipoDoc { get; set; }
           string DNI { get; set; }
           Date FechaNac { get; set; }
          string Direccion { get; set; }
           string Celular { get; set; }
           string TelefonoOpcional { get; set; }
           string EMail { get; set; }
           int Ciudad { get; set; }
		   string Obser { get; set; }
		   string Foto { get; set; }
    }
}
