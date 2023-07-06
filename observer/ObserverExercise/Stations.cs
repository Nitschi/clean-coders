using System;

public class FireStation
{
    public void Notify(){
        Console.WriteLine($"{nameof(FireStation)} was informed of emergency!");
    }
}

public class PoliceStation
{
    public void Notify(){
        Console.WriteLine($"{nameof(PoliceStation)} was informed of emergency!");
    }
}

public class HospitalStation
{
    public void Notify(){
        Console.WriteLine($"{nameof(HospitalStation)} was informed of emergency!");
    }
}
