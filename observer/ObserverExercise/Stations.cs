using System;

public class FireStation
{
    public void Alert(){
        Console.WriteLine($"{nameof(FireStation)} was informed of emergency!");
    }
}

public class PoliceStation
{
    public void Alert(){
        Console.WriteLine($"{nameof(PoliceStation)} was informed of emergency!");
    }
}

public class HospitalStation
{
    public void Alert(){
        Console.WriteLine($"{nameof(HospitalStation)} was informed of emergency!");
    }
}
