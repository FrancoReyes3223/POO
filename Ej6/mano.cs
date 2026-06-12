namespace Ej6;


public class Mano
{
    private List<Carta> cartas = new List<Carta>();

    public void recibirCarta(Carta carta)
    {
        cartas.Add(carta);
    }

    public void mostrarMano()
    {
        for (int i = 0; i < cartas.Count; i++)
        {
            Console.WriteLine(cartas[i].getNumero() + " de " + cartas[i].getPalo());
        }
    }

    public int cantidadDeCartas()
    {
        return cartas.Count;
    }
}
