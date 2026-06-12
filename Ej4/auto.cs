namespace Ej4;


public class Auto : IVehiculo
{
    private int velocidad = 40;
    private int posicionActual = 0;

    public Auto()
    {
    }

    public Auto(int velocidad)
    {
        this.velocidad = velocidad;
    }

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
