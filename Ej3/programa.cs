namespace Ej3;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Test Amateur ===");
        Amateur a = new Amateur();

        Console.WriteLine("Corre 10 min (esperado: true, no cansado)");
        Console.WriteLine($"correr(10): {a.correr(10)}, cansado: {a.cansado()}");

        Console.WriteLine("Corre 10 min (esperado: true, cansado)");
        Console.WriteLine($"correr(10): {a.correr(10)}, cansado: {a.cansado()}");

        Console.WriteLine("Corre 1 min con capacidad 0 (esperado: false, cansado)");
        Console.WriteLine($"correr(1): {a.correr(1)}, cansado: {a.cansado()}");

        Console.WriteLine("Descansa 5 min, corre 5 min (esperado: true, cansado)");
        a.descansar(5);
        Console.WriteLine($"correr(5): {a.correr(5)}, cansado: {a.cansado()}");

        Console.WriteLine("Descansa 100 min, capacidad no supera 20, corre 10 (esperado: true, no cansado)");
        a.descansar(100);
        Console.WriteLine($"correr(10): {a.correr(10)}, cansado: {a.cansado()}");

        Console.WriteLine("\n=== Test Profesional ===");
        Profesional p = new Profesional();

        Console.WriteLine("Corre 40 min (esperado: true, cansado)");
        Console.WriteLine($"correr(40): {p.correr(40)}, cansado: {p.cansado()}");

        Console.WriteLine("Corre 1 min con capacidad 0 (esperado: false, cansado)");
        Console.WriteLine($"correr(1): {p.correr(1)}, cansado: {p.cansado()}");

        Console.WriteLine("Descansa 100 min, capacidad no supera 40, corre 20 (esperado: true, no cansado)");
        p.descansar(100);
        Console.WriteLine($"correr(20): {p.correr(20)}, cansado: {p.cansado()}");
    }
}
