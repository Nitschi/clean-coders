using System;

public abstract class Station : IObserver<AlarmMessage>{
    public void OnNext(AlarmMessage message){
        this.Alert(message.messageText);
    }

    public void OnCompleted(){
        Console.WriteLine("Alarm sender disconnected");
    }

    public void OnError(Exception e){
        throw new NotImplementedException("TODO");
    }

    public abstract void Alert(string message);
}

public class FireStation : Station
{
    public override void Alert(string message){
        Console.WriteLine($"{nameof(FireStation)} was informed of emergency: {message}");
    }
}

public class PoliceStation : Station
{
    public override void Alert(string message){
        Console.WriteLine($"{nameof(PoliceStation)} was informed of emergency: {message}");
    }
}

public class HospitalStation : Station
{
    public override void Alert(string message){
        Console.WriteLine($"{nameof(HospitalStation)} was informed of emergency: {message}");
    }
}
