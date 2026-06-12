using Microsoft.EntityFrameworkCore;

namespace ClinicaMedica;

public class ClinicaContext : DbContext
{
    public DbSet<Paciente> Pacientes { get; set; }
    public DbSet<Medico> Medicos { get; set; }
    public DbSet<Especialidad> Especialidades { get; set; }
    public DbSet<Estado> Estados { get; set; }
    public DbSet<Disponibilidad> Disponibilidades { get; set; }
    public DbSet<Turno> Turnos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlite("Data Source=db-poo.db");
    }

    protected override void OnModelCreating(ModelBuilder modelo)
    {
        // claves compuestas
        modelo.Entity<Disponibilidad>().HasKey(d => new { d.EspecialidadId, d.MedicoId });
        modelo.Entity<Turno>().HasKey(t => new { t.DniPaciente, t.EspecialidadId, t.Matricula });

        // relaciones de disponibilidad
        modelo.Entity<Disponibilidad>()
            .HasOne(d => d.Medico)
            .WithMany(m => m.Disponibilidades)
            .HasForeignKey(d => d.MedicoId);

        modelo.Entity<Disponibilidad>()
            .HasOne(d => d.Especialidad)
            .WithMany(e => e.Disponibilidades)
            .HasForeignKey(d => d.EspecialidadId);

        // relaciones de turno
        modelo.Entity<Turno>()
            .HasOne<Paciente>()
            .WithMany(p => p.Turnos)
            .HasForeignKey(t => t.DniPaciente);

        modelo.Entity<Turno>()
            .HasOne(t => t.Especialidad)
            .WithMany()
            .HasForeignKey(t => t.EspecialidadId);

        modelo.Entity<Turno>()
            .HasOne(t => t.Medico)
            .WithMany()
            .HasForeignKey(t => t.Matricula);

        modelo.Entity<Turno>()
            .HasOne(t => t.Estado)
            .WithMany()
            .HasForeignKey(t => t.EstadoId);
    }
}
