namespace Ej6;


public class Mazo
{
    private List<Carta> cartas = new List<Carta>();

    public Mazo()
    {
        string[] palos = { "Espadas", "Bastos", "Oros", "Copas" };

        for (int i = 0; i < palos.Length; i++)
        {
            for (int numero = 1; numero <= 12; numero++)
            {
                cartas.Add(new Carta(palos[i], numero));
            }
        }
    }

    public void barajar()
    {
        Random random = new Random();

        for (int i = cartas.Count - 1; i > 0; i--)
        {
            int j = random.Next(i + 1);
            Carta temp = cartas[i];
            cartas[i] = cartas[j];
            cartas[j] = temp;
        }
    }

    public Carta robarCarta()
    {
        if (cartas.Count == 0)
        {
            Console.WriteLine("El mazo esta vacio");
            return null;
        }

        Carta carta = cartas[cartas.Count - 1];
        cartas.RemoveAt(cartas.Count - 1);
        return carta;
    }

    public int cuantasCartasQuedan()
    {
        return cartas.Count;
    }
}
