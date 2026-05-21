namespace ej5;


public class CajaDeAhorro : CuentaBancaria
{
    public override bool extraer(int monto)
    {
        if ((getSaldo() - monto) < 0)
        {
            Console.WriteLine("Operacion rechazada, saldo insuficiente");
            return false;
        }
        base.extraer(monto);
        return true;
    }
}