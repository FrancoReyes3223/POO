namespace Ej3;

internal  class Amateur : Interfaz{
    
    private int CapacidadCorrer = 20;
    private bool EstaCansado = false;

    public bool correr (int minutos)
    {
        if(minutos <= CapacidadCorrer)
        {

            if(CapacidadCorrer == minutos)
                EstaCansado = true;
            else {
                EstaCansado = false;
            }
            CapacidadCorrer -= minutos;
            
            return true;
        }
        else {
            EstaCansado = true;
            CapacidadCorrer = 0;
            return false;
        }

    }


    public bool cansado()
    {
        return EstaCansado;
    } 

    public void descansar(int minutos)
    {
        
        CapacidadCorrer += minutos;
        if (CapacidadCorrer > 20) CapacidadCorrer = 20;
    }



}



internal  class Profesional : Interfaz{
    
    private int CapacidadCorrer = 40;
    private bool EstaCansado = false;

    public bool correr (int minutos)
    {
        if(minutos <= CapacidadCorrer)
        {

            if(CapacidadCorrer == minutos)
                EstaCansado = true;
            else {
                EstaCansado = false;
            }
            CapacidadCorrer -= minutos;
            
            return true;
        }
        else {
            EstaCansado = true;
            CapacidadCorrer = 0;
            return false;
        }

    }


    public bool cansado()
    {
        return EstaCansado;
    } 

    public void descansar(int minutos)
    {
        
        CapacidadCorrer += minutos;
        if (CapacidadCorrer > 40) CapacidadCorrer = 40;
    }



}