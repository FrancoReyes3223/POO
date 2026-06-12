using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicaMedica;

[Table("Especialidad")]
public class Especialidad
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("Nombre")]
    public string Nombre { get; set; } = "";

    [Column("duracion")]
    public int Duracion { get; set; }

    public List<Disponibilidad> Disponibilidades { get; set; } = new List<Disponibilidad>();

    public void mostrar()
    {
        Console.WriteLine(Id + " - " + Nombre + " (" + Duracion + " min)");
    }
}
