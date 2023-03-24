using System;
using ChoreLibrary;

Person owner = new Person
{
    FirstName = "Max",
    LastName = "Mustermann",
    EmailAddress = "max@mustermann.com",
    PhoneNumber = "1414"
};

Chore chore = new Chore
{
    ChoreName = "Take out the trash",
    Owner = owner
};

chore.PerformedWork(3);
chore.PerformedWork(1.5);
chore.CompleteChore();

Console.ReadLine();