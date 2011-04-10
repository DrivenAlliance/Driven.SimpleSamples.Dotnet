using System;

namespace Driven.InversionOfControl.ExampleClasses
{
    public class SmsNotifier : INotifier
    {
        public void Send(string message)
        {
            Console.WriteLine(string.Format("Smsing: {0}", message));
        }
    }
}