using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicaMedica;

[Table("Paciente")]
public class Paciente
{
    [Key]
    [Column("dni")]
    public int Dni { get; set; }

    [Column("nombre")]
    public string Nombre { get; set; } = "";

    [Column("apellido")]
    public string Apellido { get; set; } = "";

    [Column("tel")]
    public long? Tel { get; set; }

    [Column("mail")]
    public string? Mail { get; set; }

    [Column("fecha_nac")]
    public string? FechaNac { get; set; }

    [Column("fecha_baja")]
    public string? FechaBaja { get; set; }

    public List<Turno> Turnos { get; set; } = new List<Turno>();

    public void mostrarDatos()
    {
        Console.WriteLine("DNI: " + Dni);
        Console.WriteLine("Nombre: " + Nombre + " " + Apellido);
        Console.WriteLine("Tel: " + Tel);
        Console.WriteLine("Mail: " + Mail);
        Console.WriteLine("Fecha nac: " + FechaNac);
    }
}
