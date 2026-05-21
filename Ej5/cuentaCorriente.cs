namespace ej5;

public class CuentaCorriente : CuentaBancaria
{
    private int descubierto;

    public CuentaCorriente(int descubierto)
    {
        this.descubierto = descubierto;
    }

    public override bool extraer(int monto)
    {
        if ((getSaldo() - monto) < -descubierto)
        {
            Console.WriteLine("Extraccion invalida, limite de descubierto alcanzado");
            return false;
        }
        base.extraer(monto);
        return true;
    }
}