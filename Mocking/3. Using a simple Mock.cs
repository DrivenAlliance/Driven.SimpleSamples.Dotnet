/*
 *      This example demonstrates how to create a simple Mock
 *      
 *      Terminology:
 *      
 *          1.  Mock     -  A Mock, like a Stub, is a dummy implementation of an interface, but one we would like to
 *                          verify the actual behaviour of 
 *          
 *      Observe:
 *      
 *          1.  The call to GenerateMock instead of GenerateStub
 *          2.  The fact that we assert that a call to the Send method was actually made.
 *          
 *      Try:
 *      
 *          1.  Temporarily remove the call to INotifier.Send in the SimpleReportSender. Run the test and watch it fail.
 *          2.  Change the arguments that reportSender.Send is called with. Run the test and watch it fail.
 *          3.  Use the commented out AssertWasCalled method that ignores arguments. Run the test and watch it pass.
 */

using Driven.Mocking.ExampleClasses;
using NUnit.Framework;
using Rhino.Mocks;

namespace Driven.Mocking
{
    [TestFixture]
    public class SimpleMock
    {
        [Test]
        public void Pass_a_mock_object_into_the_system_under_test()
        {
            // Create a Mock of the INotifier interface
            var notifier = MockRepository.GenerateMock<INotifier>();

            // Pass the Stub into the SUT
            IReportSender reportSender = new SimpleReportSender(notifier);

            // Exercise the SUT
            reportSender.PublishReport("Hello World");

            // Make an assertion on the Mock
            notifier.AssertWasCalled(x => x.Send("Hello World"));
            //notifier.AssertWasCalled(x => x.Send(""), options => options.IgnoreArguments());

        }
    }
}