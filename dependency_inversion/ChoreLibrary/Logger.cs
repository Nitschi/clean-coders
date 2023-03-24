using System;

namespace ChoreLibrary
{
    public class Logger
    {
        public readonly List<string> messages = new List<string>();
        public void Log(string message)
        {
            messages.Add(message);
            Console.WriteLine($"Logger: {message}");
        }
    }
}
