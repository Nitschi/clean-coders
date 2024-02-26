using Akka.Actor;

namespace Banking;

public class Bank : IBank
{
    private readonly IActorRef _bankActor;
    private readonly TimeSpan _timeout = TimeSpan.FromSeconds(5);
    private ActorSystem _actorSystem;

    public Bank()
    {
        _actorSystem = ActorSystem.Create("BankSystem");
        _bankActor = _actorSystem.ActorOf<BankActor>("bank");
    }

    public override bool CreateAccount(string owner, double initialBalance)
    {
        return _bankActor.Ask<bool>(new CreateAccount(owner, initialBalance), _timeout).Result;
    }

    public override void Deposit(string owner, double amount)
    {
        _bankActor.Tell(new Deposit(owner, amount));
    }

    public override bool TryWithdraw(string owner, double amount)
    {
        throw new NotImplementedException();
    }

    public override bool TryTransfer(string sourceOwner, string destinationOwner, double amount)
    {
        throw new NotImplementedException();
    }

    public override double GetBalance(string owner)
    {
        throw new NotImplementedException();
    }
}

// Messages
public record CreateAccount(string Owner, double Amount);
public record Deposit(string Owner, double Amount);
public record Withdraw(string Owner, double Amount);
public record Transfer(string SourceOwner, string DestinationOwner, double Amount);
public record GetBalance(string Owner);

public class BankActor : ReceiveActor
{
    // TODO: Implement
}
