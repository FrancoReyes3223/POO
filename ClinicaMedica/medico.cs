using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicaMedica;

[Table("medicos")]
public class Medico
{
    [Key]
    [Column("matricula")]
    public int Matricula { get; set; }

    [Column("nombre")]
    public string Nombre { get; set; } = "";

    [Column("apellido")]
    public string Apellido { get; set; } = "";

    [Column("fecha_baja")]
    public string? FechaBaja { get; set; }

    public List<Disponibilidad> Disponibilidades { get; set; } = new List<Disponibilidad>();

    public void mostrar()
    {
        Console.WriteLine("Mat " + Matricula + " - " + Nombre + " " + Apellido);
    }
}
