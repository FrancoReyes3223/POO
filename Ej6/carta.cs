namespace Ej6;


public class Carta
{
    private string palo;
    private int numero;

    public Carta(string palo, int numero)
    {
        this.palo = palo;
        this.numero = numero;
    }

    public string getPalo()
    {
        return palo;
    }

    public int getNumero()
    {
        return numero;
    }
}
