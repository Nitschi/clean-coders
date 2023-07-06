// Based the exercise from https://github.com/raw-coding-youtube/design-patterns.

var alarm = new Alarm();

var fireUnsubscriber = alarm.Subscribe(new FireStation());
var policeUnsubscriber = alarm.Subscribe(new PoliceStation());
var hospitalUnsubscriber = alarm.Subscribe(new HospitalStation());

alarm.TriggerAlarm("Something bad");

hospitalUnsubscriber.Dispose();

alarm.TriggerAlarm("Again!!!");
alarm.TurnOffAlarms();