using System;
using System.Collections.Generic;

public class Alarm : IObservable<AlarmMessage>
{
    private List<IObserver<AlarmMessage>> observers = new();
    public IDisposable Subscribe(IObserver<AlarmMessage> observer)
	{
		observers.Add(observer);
		return new Unsubscriber(observers, observer);
	}

    public void Notify(AlarmMessage message){
        foreach(var observer in observers){
            observer.OnNext(message);
        }
    }

    public void TriggerAlarm(string alarmText)
    {
        Console.WriteLine(alarmText);

        var alarmMessage = new AlarmMessage(alarmText);
        Notify(alarmMessage);
    }

    public void TurnOffAlarms(){
        foreach(var observer in observers){
            observer.OnCompleted();
        }
    }

    private class Unsubscriber : IDisposable
    {
        private List<IObserver<AlarmMessage>>_observers;
        private IObserver<AlarmMessage> _observer;

        public Unsubscriber(List<IObserver<AlarmMessage>> observers, IObserver<AlarmMessage> observer)
        {
            this._observers = observers;
            this._observer = observer;
        }

        public void Dispose()
        {
            if (_observer != null && _observers.Contains(_observer))
                _observers.Remove(_observer);
        }
    }
}

public class AlarmMessage{
    public string messageText {get; init;}
    public AlarmMessage(string messageText){
        this.messageText = messageText;
    }
}