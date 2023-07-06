using System;
using System.Collections.Generic;

public class Alarm
{
    private List<IObserver<AlarmMessage>> observers = new ();
    public void AddObserver(IObserver<AlarmMessage> observer){
        observers.Add(observer);
    }

    public void InformObservers(AlarmMessage message){
        foreach(var observer in observers){
            observer.Notify(message);
        }
    }
    public void TriggerAlarm(string alarmText)
    {
        Console.WriteLine(alarmText);

        var alarmMessage = new AlarmMessage(alarmText);
        InformObservers(alarmMessage);
    }
}

public class AlarmMessage{
    public string messageText {get; init;}
    public AlarmMessage(string messageText){
        this.messageText = messageText;
    }
}