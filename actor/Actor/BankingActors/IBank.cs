namespace Banking;

public abstract class IBank
{
    public abstract bool CreateAccount(string owner, double initialBalance);
    public abstract void Deposit(string owner, double amount);
    public abstract bool TryWithdraw(string owner, double amount);
    public abstract bool TryTransfer(string sourceOwner, string destinationOwner, double amount);
    public abstract double GetBalance(string owner);
}