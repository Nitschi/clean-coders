using System;

public class FireStation : IObserver<AlarmMessage>
{
    public void Notify(AlarmMessage message){
        this.Alert(message.messageText);
    }
    public void Alert(string message){
        Console.WriteLine($"{nameof(FireStation)} was informed of emergency: {message}");
    }
}

public class PoliceStation : IObserver<AlarmMessage>
{
    public void Notify(AlarmMessage message){
        this.Alert(message.messageText);
    }
    public void Alert(string message){
        Console.WriteLine($"{nameof(PoliceStation)} was informed of emergency: {message}");
    }
}

public class HospitalStation : IObserver<AlarmMessage>
{
    public void Notify(AlarmMessage message){
        this.Alert(message.messageText);
    }
    public void Alert(string message){
        Console.WriteLine($"{nameof(HospitalStation)} was informed of emergency: {message}");
    }
}
