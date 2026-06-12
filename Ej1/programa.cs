namespace Ej1;

class Program
{
    static void Main(string[] args)
    {
        Semaforo semaforo = new Semaforo("Verde");

        Console.WriteLine("Arranca en Verde (esperado: Verde)");
        semaforo.mostrarColor();

        Console.WriteLine("Pasan 20 seg, cambia a Amarillo (esperado: Amarillo)");
        semaforo.pasoDelTiempo(20);
        semaforo.mostrarColor();

        Console.WriteLine("Pasan 2 seg, cambia a Rojo (esperado: Rojo)");
        semaforo.pasoDelTiempo(2);
        semaforo.mostrarColor();

        Console.WriteLine("Pasan 30 seg, cambia a Rojo + Amarillo (esperado: Rojo + Amarillo)");
        semaforo.pasoDelTiempo(30);
        semaforo.mostrarColor();

        Console.WriteLine("Pasan 2 seg, vuelve a Verde (esperado: Verde)");
        semaforo.pasoDelTiempo(2);
        semaforo.mostrarColor();

        Console.WriteLine("Pasan 54 seg de una (ciclo completo, esperado: Verde)");
        semaforo.pasoDelTiempo(54);
        semaforo.mostrarColor();

        Console.WriteLine("\n=== Modo intermitente ===");
        semaforo.ponerEnIntermitente();

        Console.WriteLine("Segundo 0 (esperado: Amarillo)");
        semaforo.mostrarColor();

        Console.WriteLine("Pasa 1 seg (esperado: Apagado)");
        semaforo.pasoDelTiempo(1);
        semaforo.mostrarColor();

        Console.WriteLine("Pasa 1 seg (esperado: Amarillo)");
        semaforo.pasoDelTiempo(1);
        semaforo.mostrarColor();

        Console.WriteLine("Sale de intermitente, retoma la secuencia normal (esperado: Verde)");
        semaforo.sacarDeIntermitente();
        semaforo.mostrarColor();
    }
}
