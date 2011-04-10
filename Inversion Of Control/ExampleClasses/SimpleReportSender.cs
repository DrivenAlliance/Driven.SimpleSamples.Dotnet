using System;

namespace Driven.InversionOfControl.ExampleClasses
{
    public class SimpleReportSender : IReportSender
    {
        private readonly INotifier _notifier;

        public SimpleReportSender(INotifier notifier)
        {
            _notifier = notifier;
        }

        public void PublishReport(string reportText)
        {
            Console.WriteLine("Using the SimpleReportSender");
            _notifier.Send(reportText);
        }
    }
}