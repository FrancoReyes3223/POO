using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicaMedica;

[Table("disponibilidad")]
public class Disponibilidad
{
    [Column("dia")]
    public string Dia { get; set; } = "";

    [Column("horaIni")]
    public string HoraIni { get; set; } = "";

    [Column("horaFin")]
    public string HoraFin { get; set; } = "";

    [Column("medico_id")]
    public int MedicoId { get; set; }

    [Column("especialidad_id")]
    public int EspecialidadId { get; set; }

    public Medico Medico { get; set; } = null!;
    public Especialidad Especialidad { get; set; } = null!;

    public void mostrar()
    {
        Console.WriteLine(Dia + " de " + HoraIni + " a " + HoraFin);
    }
}
