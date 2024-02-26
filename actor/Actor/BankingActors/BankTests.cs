using NUnit.Framework;
using Banking;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Banking.Tests;

[TestFixture]
public class BankTests
{
    private Random _random = new Random();

    [Test]
    public void BankTransfersMaintainCorrectTotalAmountWithMultiThreading()
    {
        var bank = new Bank();

        // Initially, create two accounts with a total balance of 300
        bank.CreateAccount("Alice", 150);
        bank.CreateAccount("Bob", 150);

        int numberOfOperations = 3000;
        var threads = new List<Thread>();

        for (int i = 0; i < numberOfOperations; i++)
        {
            var thread = new Thread(() =>
            {
                // Randomly choose the source and destination for each transfer
                bool transferFromAliceToBob = _random.Next(2) == 0; // Randomly returns true or false
                var amount = _random.Next(1, 101); // Random amount between 1 and 100

                if (transferFromAliceToBob)
                {
                    bank.TryTransfer("Alice", "Bob", amount);
                }
                else
                {
                    bank.TryTransfer("Bob", "Alice", amount);
                }
            });

            threads.Add(thread);
        }

        // Start all threads
        foreach (var thread in threads)
        {
            thread.Start();
        }

        // Wait for all threads to complete
        foreach (var thread in threads)
        {
            thread.Join();
        }

        // After all operations, the total balance should still be 300
        var aliceBalance = bank.GetBalance("Alice");
        var bobBalance = bank.GetBalance("Bob");
        var totalBalance = aliceBalance + bobBalance;

        // Assert that the total balance remains unchanged
        Assert.AreEqual(300, totalBalance, "The total balance after all transfers should remain 300.");
    }
}
