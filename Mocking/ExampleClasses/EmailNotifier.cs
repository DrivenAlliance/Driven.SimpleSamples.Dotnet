using System;

namespace Driven.Mocking.ExampleClasses
{
    public class EmailNotifier : INotifier
    {
        public bool Send(string message)
        {
            Console.WriteLine(string.Format("Emailing: {0}", message));
            return true;
        }
    }
}