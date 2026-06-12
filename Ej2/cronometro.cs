namespace POO;


public class Cronometro
{
    private int segundos;
    private int minutos;

    public void reiniciar()
    {
        segundos = 0;
        minutos = 0;
    }

    public void incrementarTiempo()
    {
        segundos += 1;
        if (segundos > 59)
        {
            minutos += 1;
            segundos = 0;
        }
    }

    public void mostrarTiempo()
    {
        Console.WriteLine(minutos + " min, " + segundos + " seg");
    }
}
