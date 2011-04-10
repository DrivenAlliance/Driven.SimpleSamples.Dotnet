using System;

namespace Driven.Mocking.ExampleClasses
{
    public class SimpleReportSender : IReportSender
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