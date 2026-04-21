namespace POO;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Ingresá el color inicial (Rojo, Verde, Amarillo): ");
        string colorInicial = Console.ReadLine();
        Semaforo miSemaforo = new Semaforo(colorInicial);

        miSemaforo.PasoDelTiempo(32);
        miSemaforo.MostrarColor();

        miSemaforo.PasoDelTiempo(10);
        miSemaforo.MostrarColor();

        miSemaforo.PonerEnIntermitente();
        miSemaforo.MostrarColor();

        miSemaforo.PasoDelTiempo(3);
        miSemaforo.MostrarColor();

        miSemaforo.SacarDeIntermitente();
        miSemaforo.MostrarColor();
    }
}

