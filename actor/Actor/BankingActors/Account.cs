namespace Banking;

public class Account
{
    public string Owner { get; }
    public double Balance { get; private set; }

    public Account(string owner, double initialBalance)
    {
        Owner = owner;
        Balance = initialBalance;
    }

    public void Deposit(double amount)
    {
        Balance += amount;
    }

    public bool Withdraw(double amount)
    {
        if (Balance >= amount)
        {
            Balance -= amount;
            return true;
        }
        return false;
    }
}