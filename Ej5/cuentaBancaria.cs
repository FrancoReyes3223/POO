namespace ej5;


public class CuentaBancaria
{
    private int saldo;

    protected int getSaldo()
    {
        return saldo;
    }

    public void depositar(int monto)
    {
        if (monto > 0)
        {
            saldo += monto;
        }
        else
        {
            Console.WriteLine("Monto no valido");
        }
    }

    public virtual bool extraer(int monto)
    {
        saldo -= monto;
        return true;
    }

    public void mostrarSaldo()
    {
        Console.WriteLine(saldo);
    }
}