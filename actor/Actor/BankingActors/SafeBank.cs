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
        return _bankActor.Ask<bool>(new Withdraw(owner, amount), _timeout).Result;
    }

    public override bool TryTransfer(string sourceOwner, string destinationOwner, double amount)
    {
        return _bankActor.Ask<bool>(new Transfer(sourceOwner, destinationOwner, amount), _timeout).Result;
    }

    public override double GetBalance(string owner)
    {
        return _bankActor.Ask<double>(new GetBalance(owner), _timeout).Result;
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
    private Dictionary<string, Account> Accounts = new();

    public BankActor()
    {
        Receive<CreateAccount>(createAccount =>
        {
            var account = new Account(createAccount.Owner, createAccount.Amount);
            Accounts[createAccount.Owner] = account;
            Sender.Tell(true);
        });

        Receive<Deposit>(deposit =>
        {
            if (Accounts.TryGetValue(deposit.Owner, out var account))
            {
                account.Deposit(deposit.Amount);
            }
        });

        Receive<Withdraw>(withdraw =>
        {
            if (Accounts.TryGetValue(withdraw.Owner, out var account) && account.Withdraw(withdraw.Amount))
            {
                Sender.Tell(true);
            }
            else
            {
                Sender.Tell(false);
            }
        });

        Receive<Transfer>(transfer =>
        {
            if (Accounts.TryGetValue(transfer.SourceOwner, out var sourceAccount) && Accounts.TryGetValue(transfer.DestinationOwner, out var destinationAccount))
            {
                if (sourceAccount.Withdraw(transfer.Amount))
                {
                    destinationAccount.Deposit(transfer.Amount);
                    Sender.Tell(true);
                }
                else
                {
                    Sender.Tell(false);
                }
            }
            else
            {
                Sender.Tell(false);
            }
        });

        Receive<GetBalance>(balance =>
        {
            if (Accounts.TryGetValue(balance.Owner, out var account))
            {
                Sender.Tell(account.Balance);
            }
            else
            {
                Sender.Tell(0.0); // Consider how to handle account not found
            }
        });
    }
}
