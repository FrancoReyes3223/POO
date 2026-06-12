namespace ej5;

public class Banco
{
    private List<CuentaBancaria> cuentas = new List<CuentaBancaria>();

    public void agregarCuenta(CuentaBancaria cuenta)
    {
        cuentas.Add(cuenta);
    }

    private bool estaRegistrada(CuentaBancaria cuenta)
    {
        for (int i = 0; i < cuentas.Count; i++)
        {
            if (cuentas[i] == cuenta)
                return true;
        }
        return false;
    }

    public void transferir(CuentaBancaria origen, CuentaBancaria destino, int monto)
    {
        if (!estaRegistrada(origen) || !estaRegistrada(destino))
        {
            Console.WriteLine("Transferencia rechazada, alguna cuenta no esta registrada");
            return;
        }

        if (monto <= 0)
        {
            Console.WriteLine("Transferencia rechazada, el monto debe ser positivo");
            return;
        }

        if (origen.extraer(monto))
        {
            destino.depositar(monto);
        }
        else
        {
            Console.WriteLine("Transferencia rechazada, saldo insuficiente");
        }
    }
}
