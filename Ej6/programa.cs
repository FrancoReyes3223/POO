namespace Ej6;

class Program
{
    static void Main(string[] args)
    {
        Mazo mazo = new Mazo();
        mazo.barajar();

        Mano jugador1 = new Mano();
        Mano jugador2 = new Mano();

        // Repartir 3 cartas a cada jugador
        for (int i = 0; i < 3; i++)
        {
            jugador1.recibirCarta(mazo.robarCarta());
            jugador2.recibirCarta(mazo.robarCarta());
        }

        Console.WriteLine("=== Mano jugador 1 ===");
        jugador1.mostrarMano();

        Console.WriteLine("=== Mano jugador 2 ===");
        jugador2.mostrarMano();

        Console.WriteLine("Cartas que quedan en el mazo:");
        Console.WriteLine(mazo.cuantasCartasQuedan());
    }
}
