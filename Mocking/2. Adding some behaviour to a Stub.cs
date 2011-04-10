/*
 *      This example demonstrates how to add some fake behaviour to a Stub
 *      
 *      Terminology:
 *      
 *          1.  Expectation -   Some sort of behaviour that we want our Stub to simulate
 *          
 *      Observe:
 *      
 *          1.  The use of 'IgnoreArguments'
 *          2.  The use of 'Return' to state what our stub should return when it is called
 *          
 *      Try:
 *      
 *          1.  Setting specific arguments for the expectation
 *          2.  Change the return from 'true' to 'false'. See how the behaviour of the Stub changes.
 * 
 */

using Driven.Mocking.ExampleClasses;
using NUnit.Framework;
using Rhino.Mocks;

namespace Driven.Mocking
{
    [TestFixture]
    public class StubWithBehaviour
    {
        [Test]
        public void Add_some_simple_behaviour_to_a_Stub()
        {
            // Create a Stub (fake implementation) of the INotifier interface
            var notifier = MockRepository.GenerateStub<INotifier>();
            
            // Set an expectation that when the Send method is called with any arguments, it returns true
            notifier.Expect(x => x.Send(""))
                .IgnoreArguments()
                .Return(true);

            // Pass the Stub into the SUT
            IReportSender reportSender = new SimpleReportSender(notifier);

            bool result = reportSender.PublishReport("Hello World");

            Assert.That(result, Is.True);
        }
    }
}