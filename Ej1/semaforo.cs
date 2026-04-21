using System.Drawing;

namespace POO;

public class Semaforo
{
    string colorActual;
    int segundosEnColor;
    
    bool esIntermitente = false;

    public Semaforo(string colorInicial)
    {
        colorActual = colorInicial;
        segundosEnColor = 0;
    }

    public void PasoDelTiempo(int segundos)
    {

        
        for(int i = 0; i < segundos && esIntermitente; i++)
        {
            colorActual = colorActual == "Amarillo" ? "Apagado" : "Amarillo";
            segundosEnColor = 0; 
            return;
        }
        
        
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
     esIntermitente = true;   
     colorActual = "Amarillo";
     segundosEnColor = 0;
    }

    public void SacarDeIntermitente()
    {
        esIntermitente = false;
        colorActual = "Rojo"; 
        segundosEnColor = 0;

    }
}
