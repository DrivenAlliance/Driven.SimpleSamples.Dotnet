/*
 *      This example demonstrates the use of the 'Self Shunt Pattern'. Step through the test method and see how it works.
 *      
 *      Terminology:
 *      
 *          1.  SUT         -   System Under Test. The piece of code that you want to test
 *          
 *      Observe:
 *      
 *          1.  The test fixture itself is passed into the SUT.
 *          2.  The test fixture implements the INotifier interface so that when the SUT calls a method on the inteface, the
 *              call comes back to the test fixture and the parameters can be recorded.
 *          
 *      Try:
 *      
 *          1.  Run the test and watch it pass
 *          2.  Debug the test and step through the code to see the paths it takes - not that the call in to INotifier.Send in
 *              SimpleReportSender is actuall to SelfShuntPattern.Send.
 * 
 */
using Driven.UnitTesting.ExampleClasses;
using NUnit.Framework;

namespace Driven.UnitTesting
{
    [TestFixture]
    public class SelfShuntPattern : INotifier
    {
        private string _message;

        [Test]
        public void CanSendEmail()
        {
            var sender = new SimpleReportSender(this);
            _message = string.Empty;

            var result = sender.PublishReport("MY REPORT");

            Assert.IsTrue(result);
            Assert.That(_message, Is.EqualTo("MY REPORT"));
        }

        public bool Send(string message)
        {
            _message = message;
            return true;
        }
    }
}
