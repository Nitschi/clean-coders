using Akka.Actor;
using System;
using System.Collections.Generic;
using System.Text;
using Akka.Event;
using Akka.Util;

namespace ActorBasics;

public class PongActor : Akka.Actor.ReceiveActor
{
    private readonly ILoggingAdapter _log = Context.GetLogger();

    public PongActor(IActorRef pingActor)
    {
        Receive<Pong>(p =>
        {
            _log.Info("Received {0}", p);

            // reply back at a random, short interval
            var replyTime = TimeSpan.FromSeconds(
                ThreadLocalRandom.Current.Next(1, 5));

            Context.System.Scheduler.ScheduleTellOnce(
                replyTime, // delay
                pingActor, // target
                p.Next(), // message
                Self); // sender (optional)
        });
    }
}