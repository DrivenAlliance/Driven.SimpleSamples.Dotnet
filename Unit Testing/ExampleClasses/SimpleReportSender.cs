using System;

namespace Driven.UnitTesting.ExampleClasses
{
    public class SimpleReportSender 
    {
        private readonly INotifier _notifier;

        public SimpleReportSender(INotifier notifier)
        {
            _notifier = notifier;
        }

        public bool PublishReport(string reportText)
        {
            Console.WriteLine("Using the SimpleReportSender");
            return _notifier.Send(reportText);
        }
    }
}