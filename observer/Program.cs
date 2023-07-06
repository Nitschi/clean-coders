// Based the exercise from https://github.com/raw-coding-youtube/design-patterns.

var alarm = new Alarm();

alarm.AddObserver(new FireStation());
alarm.AddObserver(new PoliceStation());
alarm.AddObserver(new HospitalStation());

alarm.TriggerAlarm("Something bad");