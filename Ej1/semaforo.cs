namespace POO;

public class Semaforo
{
    string colorActual;
    int segundosEnColor;
    string colorAnterior;
    int segundosAnterior;

    public Semaforo(string colorInicial)
    {
        colorActual = colorInicial;
        segundosEnColor = 0;
    }

    public void PasoDelTiempo(int segundos)
    {
        if (colorActual == "Intermitente")
            return;

        segundosEnColor += segundos;

        bool huboTransicion = true;
        while (huboTransicion)
        {
            huboTransicion = false;

            if (colorActual == "Rojo" && segundosEnColor >= 30)
            {
                segundosEnColor -= 30;
                colorActual = "Rojo+Amarillo";
                huboTransicion = true;
            }
            else if (colorActual == "Rojo+Amarillo" && segundosEnColor >= 2)
            {
                segundosEnColor -= 2;
                colorActual = "Verde";
                huboTransicion = true;
            }
            else if (colorActual == "Verde" && segundosEnColor >= 20)
            {
                segundosEnColor -= 20;
                colorActual = "Amarillo";
                huboTransicion = true;
            }
            else if (colorActual == "Amarillo" && segundosEnColor >= 2)
            {
                segundosEnColor -= 2;
                colorActual = "Rojo";
                huboTransicion = true;
            }
        }
    }

    public void MostrarColor()
    {
        Console.WriteLine("El semáforo está en: " + colorActual);
    }

    public void PonerEnIntermitente()
    {
        colorAnterior = colorActual;
        segundosAnterior = segundosEnColor;
        colorActual = "Intermitente";
    }

    public void SacarDeIntermitente()
    {
        colorActual = colorAnterior;
        segundosEnColor = segundosAnterior;
    }
}
