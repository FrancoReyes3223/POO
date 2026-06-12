namespace Ej4;


public class Bicicleta : IVehiculo
{
    private int velocidad = 10;
    private int posicionActual = 0;

    public void mover(int tiempo)
    {
        posicionActual += velocidad * tiempo;
    }

    public int posicion()
    {
        return posicionActual;
    }

    public void reiniciarPosicion()
    {
        posicionActual = 0;
    }
}
