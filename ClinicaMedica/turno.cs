using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicaMedica;

[Table("turno")]
public class Turno
{
    [Column("dni_paciente")]
    public int DniPaciente { get; set; }

    [Column("especialidad_id")]
    public int EspecialidadId { get; set; }

    [Column("matricula")]
    public int Matricula { get; set; }

    [Column("hora")]
    public string Hora { get; set; } = "";

    [Column("fecha")]
    public string Fecha { get; set; } = "";

    [Column("estado_id")]
    public int EstadoId { get; set; }

    public Especialidad Especialidad { get; set; } = null!;
    public Medico Medico { get; set; } = null!;
    public Estado Estado { get; set; } = null!;

    public void mostrar()
    {
        Console.WriteLine("Fecha " + Fecha + " " + Hora + " - " + Especialidad.Nombre
            + " - Mat " + Matricula + " - " + Estado.Descripcion);
    }
}
