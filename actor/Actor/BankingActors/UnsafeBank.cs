namespace Banking;

public class UnsafeBank : IBank
{
    private Dictionary<string, Account> Accounts = new();

    public override bool CreateAccount(string owner, double initialBalance)
    {
        if (Accounts.ContainsKey(owner))
        {
            return false; // Account already exists
        }

        Accounts[owner] = new Account(owner, initialBalance);
        return true; // Account creation successful
    }

    public override void Deposit(string owner, double amount)
    {
        if (Accounts.TryGetValue(owner, out var account))
        {
            account.Deposit(amount);
        }
        else
        {
            throw new InvalidOperationException($"Account for {owner} not found.");
        }
    }

    public override bool TryWithdraw(string owner, double amount)
    {
        if (Accounts.TryGetValue(owner, out var account) && account.Balance >= amount)
        {
            account.Withdraw(amount);
            return true; // Withdrawal successful
        }
        return false; // Withdrawal failed
    }

    public override bool TryTransfer(string sourceOwner, string destinationOwner, double amount)
    {
        if (!Accounts.TryGetValue(sourceOwner, out var sourceAccount) || !Accounts.TryGetValue(destinationOwner, out var destinationAccount))
        {
            return false; // One or both accounts not found
        }

        if (sourceAccount.Balance < amount)
        {
            return false; // Insufficient funds
        }

        sourceAccount.Withdraw(amount);
        destinationAccount.Deposit(amount);
        return true; // Transfer successful
    }

    public override double GetBalance(string owner)
    {
        if (Accounts.TryGetValue(owner, out var account))
        {
            return account.Balance;
        }
        throw new InvalidOperationException($"Account for {owner} not found.");
    }
}
