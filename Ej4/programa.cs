namespace Ej4;

class Program
{
    static void Main(string[] args)
    {
        Auto fiat = new Auto(45);
        Bicicleta bici = new Bicicleta();
        Camion camion = new Camion();

        bici.mover(20);
        Console.WriteLine(bici.posicion());
        bici.mover(10);
        Console.WriteLine(bici.posicion());

        Console.WriteLine("\n=== Carrera Auto vs Camion (10 seg) ===");
        Carrera carrera = new Carrera(fiat, camion);
        carrera.competir(10);
    }
}
