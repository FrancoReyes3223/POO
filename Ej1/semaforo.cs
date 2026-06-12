namespace Ej1;


public class Semaforo
{
    private string color;
    private int segundos;

    private bool intermitente = false;
    private int segundosIntermitente;

    public Semaforo(string colorInicial)
    {
        color = colorInicial;
        segundos = 0;
    }

    private int duracionActual()
    {
        if (color == "Rojo")
            return 30;
        else if (color == "Rojo + Amarillo")
            return 2;
        else if (color == "Verde")
            return 20;
        else
            return 2;
    }

    private void siguienteColor()
    {
        if (color == "Rojo")
            color = "Rojo + Amarillo";
        else if (color == "Rojo + Amarillo")
            color = "Verde";
        else if (color == "Verde")
            color = "Amarillo";
        else
            color = "Rojo";
    }

    public void pasoDelTiempo(int tiempo)
    {
        if (intermitente)
        {
            segundosIntermitente += tiempo;
            return;
        }

        for (int i = 0; i < tiempo; i++)
        {
            segundos += 1;
            if (segundos >= duracionActual())
            {
                siguienteColor();
                segundos = 0;
            }
        }
    }

    public void mostrarColor()
    {
        if (intermitente)
        {
            if (segundosIntermitente % 2 == 0)
                Console.WriteLine("Amarillo");
            else
                Console.WriteLine("Apagado");
            return;
        }

        Console.WriteLine(color);
    }

    public void ponerEnIntermitente()
    {
        intermitente = true;
        segundosIntermitente = 0;
    }

    public void sacarDeIntermitente()
    {
        intermitente = false;
    }
}
