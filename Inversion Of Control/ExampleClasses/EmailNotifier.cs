using System;

namespace Driven.InversionOfControl.ExampleClasses
{
    public class EmailNotifier : INotifier
    {
        public void Send(string message)
        {
            Console.WriteLine(string.Format("Emailing: {0}", message));
        }
    }
}