/*
 *      This example demonstrates how to add some fake behaviour to a Mock
 *      
 *      Observe:
 *      
 *          1.  You add behaviour to a Mock the same way as you would for a Stub
 *          
 */

using Driven.Mocking.ExampleClasses;
using NUnit.Framework;
using Rhino.Mocks;

namespace Driven.Mocking
{
    [TestFixture]
    public class MockWithBehaviour
    {
        [Test]
        public void Add_some_simple_behaviour_to_a_Mock()
        {
            // Create a Mock of the INotifier interface
            var notifier = MockRepository.GenerateMock<INotifier>();

            // Set an expectation that when the Send method is called with any arguments, it returns true
            notifier.Expect(x => x.Send(""))
                .IgnoreArguments()
                .Return(true);

            // Pass the Stub into the SUT
            IReportSender reportSender = new SimpleReportSender(notifier);

            // Exercise the SUT
            var result = reportSender.PublishReport("Hello World");

            // Make an assertion on the Mock
            notifier.AssertWasCalled(x => x.Send("Hello World"));

            // Check the expectation was met
            Assert.That(result, Is.True);
        }
    }
}