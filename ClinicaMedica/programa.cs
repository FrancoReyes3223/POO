using Microsoft.EntityFrameworkCore;

namespace ClinicaMedica;

class Program
{
    const int RESERVADO = 1;
    const int CANCELADO = 2;

    static void Main(string[] args)
    {
        using ClinicaContext db = new ClinicaContext();

        Console.WriteLine("=== Registro de turno ===");

        // 1 - Paciente
        Paciente paciente = buscarOcrearPaciente(db);

        // 2 - Especialidad
        Especialidad especialidad = elegirEspecialidad(db);
        if (especialidad == null)
            return;

        // 3 - Medico
        Medico medico = elegirMedico(db, especialidad);
        if (medico == null)
            return;

        // 4 - Disponibilidad y fecha/hora deseada
        Disponibilidad disp = db.Disponibilidades
            .First(d => d.EspecialidadId == especialidad.Id && d.MedicoId == medico.Matricula);

        Console.WriteLine("\nDisponibilidad del medico:");
        disp.mostrar();

        Console.Write("Ingrese la fecha deseada (aaaa-mm-dd): ");
        string fecha = Console.ReadLine();
        Console.Write("Ingrese la hora deseada (hh:mm): ");
        string hora = Console.ReadLine();

        // 5 - Confirmar y registrar
        Console.WriteLine("\n=== Resumen del turno ===");
        Console.WriteLine("Paciente: " + paciente.Nombre + " " + paciente.Apellido);
        Console.WriteLine("Especialidad: " + especialidad.Nombre);
        Console.WriteLine("Medico: " + medico.Nombre + " " + medico.Apellido);
        Console.WriteLine("Fecha y hora: " + fecha + " " + hora);
        Console.Write("Confirma el turno? (s/n): ");
        string conf = Console.ReadLine();

        if (conf == "s" || conf == "S")
        {
            Turno turno = new Turno();
            turno.DniPaciente = paciente.Dni;
            turno.EspecialidadId = especialidad.Id;
            turno.Matricula = medico.Matricula;
            turno.Fecha = fecha;
            turno.Hora = hora;
            turno.EstadoId = RESERVADO;

            db.Turnos.Add(turno);
            db.SaveChanges();
            Console.WriteLine("Turno reservado con exito");
        }
        else
        {
            Console.WriteLine("Turno cancelado");
        }
    }

    // 1 - busca el paciente por DNI; si no existe lo registra
    static Paciente buscarOcrearPaciente(ClinicaContext db)
    {
        Console.Write("Ingrese el DNI del paciente: ");
        int dni = int.Parse(Console.ReadLine());

        Paciente paciente = db.Pacientes
            .Include(p => p.Turnos).ThenInclude(t => t.Especialidad)
            .Include(p => p.Turnos).ThenInclude(t => t.Estado)
            .FirstOrDefault(p => p.Dni == dni);

        if (paciente != null)
        {
            Console.WriteLine("\nPaciente encontrado:");
            paciente.mostrarDatos();
            mostrarYcancelarTurnos(db, paciente);
            return paciente;
        }

        Console.WriteLine("\nPaciente no registrado. Cargue sus datos:");
        paciente = new Paciente();
        paciente.Dni = dni;
        Console.Write("Nombre: ");
        paciente.Nombre = Console.ReadLine();
        Console.Write("Apellido: ");
        paciente.Apellido = Console.ReadLine();
        Console.Write("Telefono: ");
        paciente.Tel = long.Parse(Console.ReadLine());
        Console.Write("Email: ");
        paciente.Mail = Console.ReadLine();
        Console.Write("Fecha de nacimiento (aaaa-mm-dd): ");
        paciente.FechaNac = Console.ReadLine();

        db.Pacientes.Add(paciente);
        db.SaveChanges();
        Console.WriteLine("Paciente registrado");
        return paciente;
    }

    // muestra los turnos reservados y permite cancelar uno
    static void mostrarYcancelarTurnos(ClinicaContext db, Paciente paciente)
    {
        List<Turno> reservados = paciente.Turnos
            .Where(t => t.EstadoId == RESERVADO)
            .ToList();

        if (reservados.Count == 0)
        {
            Console.WriteLine("El paciente no tiene turnos reservados");
            return;
        }

        Console.WriteLine("\nTurnos reservados:");
        for (int i = 0; i < reservados.Count; i++)
        {
            Console.Write((i + 1) + ") ");
            reservados[i].mostrar();
        }

        Console.Write("Desea cancelar algun turno? (s/n): ");
        string resp = Console.ReadLine();
        if (resp == "s" || resp == "S")
        {
            Console.Write("Numero de turno a cancelar: ");
            int op = int.Parse(Console.ReadLine());
            if (op >= 1 && op <= reservados.Count)
            {
                reservados[op - 1].EstadoId = CANCELADO;
                db.SaveChanges();
                Console.WriteLine("Turno cancelado");
            }
            else
            {
                Console.WriteLine("Opcion invalida");
            }
        }
    }

    // 2 - lista las especialidades y devuelve la elegida
    static Especialidad elegirEspecialidad(ClinicaContext db)
    {
        List<Especialidad> especialidades = db.Especialidades.ToList();

        Console.WriteLine("\nEspecialidades disponibles:");
        foreach (Especialidad e in especialidades)
            e.mostrar();

        Console.Write("Ingrese el id de la especialidad: ");
        int id = int.Parse(Console.ReadLine());

        Especialidad elegida = especialidades.FirstOrDefault(e => e.Id == id);
        if (elegida == null)
            Console.WriteLine("Especialidad invalida");
        return elegida;
    }

    // 3 - lista los medicos que atienden la especialidad y devuelve el elegido
    static Medico elegirMedico(ClinicaContext db, Especialidad especialidad)
    {
        List<Medico> medicos = db.Disponibilidades
            .Where(d => d.EspecialidadId == especialidad.Id)
            .Select(d => d.Medico)
            .ToList();

        if (medicos.Count == 0)
        {
            Console.WriteLine("No hay medicos para esa especialidad");
            return null;
        }

        Console.WriteLine("\nMedicos que atienden " + especialidad.Nombre + ":");
        foreach (Medico m in medicos)
            m.mostrar();

        Console.Write("Ingrese la matricula del medico: ");
        int mat = int.Parse(Console.ReadLine());

        Medico elegido = medicos.FirstOrDefault(m => m.Matricula == mat);
        if (elegido == null)
            Console.WriteLine("Matricula invalida");
        return elegido;
    }
}
