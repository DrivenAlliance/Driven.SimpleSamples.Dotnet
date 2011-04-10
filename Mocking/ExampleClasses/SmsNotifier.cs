using System;

namespace Driven.Mocking.ExampleClasses
{
    public class SmsNotifier : INotifier
    {
        public bool Send(string message)
        {
            Console.WriteLine(string.Format("Smsing: {0}", message));
            return true;
        }
    }
}