namespace Ej4;


public class Carrera
{
    private IVehiculo vehiculo1;
    private IVehiculo vehiculo2;

    public Carrera(IVehiculo vehiculo1, IVehiculo vehiculo2)
    {
        this.vehiculo1 = vehiculo1;
        this.vehiculo2 = vehiculo2;
    }

    public void competir(int segundos)
    {
        vehiculo1.reiniciarPosicion();
        vehiculo2.reiniciarPosicion();

        vehiculo1.mover(segundos);
        vehiculo2.mover(segundos);

        Console.WriteLine("Vehiculo 1 llego a " + vehiculo1.posicion() + " metros");
        Console.WriteLine("Vehiculo 2 llego a " + vehiculo2.posicion() + " metros");

        if (vehiculo1.posicion() > vehiculo2.posicion())
            Console.WriteLine("Gano el vehiculo 1");
        else if (vehiculo2.posicion() > vehiculo1.posicion())
            Console.WriteLine("Gano el vehiculo 2");
        else
            Console.WriteLine("Empate");
    }
}
