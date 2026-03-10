using System.ComponentModel.DataAnnotations;

namespace APICursantes.Models
{
    public class Cursante
    {
		[Key]
        public int NroCursante { get; set; }
        public string? Apellido { get; set; }

        public string? Nombre { get; set; }

        public string cursante { get; set; }

        public Int16? TipoDoc { get; set; }

        public string? DNI { get; set; }


              public DateOnly? FechaNac { get; set; }


        public string? Direccion { get; set; }
        public string? Celular { get; set; }
        public string? TelefonoOpcional { get; set; }
        public string? Email { get; set; }
        public string Ciudad { get; set; }

        public string? ObserSistemaAnterior { get; set; }


        public string? Foto { get; set; }
     

    }
}
