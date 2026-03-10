using System.ComponentModel.DataAnnotations;

public class CursanteInsertDto
{
    [Required]
    [MaxLength(50)]
    public string Apellido { get; set; }

    [Required]
    [MaxLength(50)]
    public string Nombre { get; set; }

    [Required]
    public int TipoDoc { get; set; }

    [Required]
    public string DNI { get; set; }

    [Required]
    public DateOnly FechaNac { get; set; }

    [MaxLength(100)]
    public string Direccion { get; set; }

    public string Celular { get; set; }

    public string TelefonoOpcional { get; set; }

    [EmailAddress]
    public string Email { get; set; }

    public int Ciudad { get; set; }

    public string Obser { get; set; }

    public string Foto { get; set; }
}