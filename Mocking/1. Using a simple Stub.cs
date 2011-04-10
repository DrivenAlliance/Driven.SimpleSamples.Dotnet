/*
 *      This example demonstrates a simple use of an stub. Step through the test method and see how it works.
 *      
 *      Terminology:
 *      
 *          1.  Stub        -   A dummy/fake implementation of an interface
 *          2.  SUT         -   System Under Test. The piece of code that you want to isolate using a Stub
 *          
 *      Observe:
 *      
 *          1.  No actual coded implementation of INofifier is used - it is 'faked' by the mocking framework
 *          2.  Step through the code and you will see that when the Stub is called, the call is just ignored
 *          
 * 
 */

using Driven.Mocking.ExampleClasses;
using NUnit.Framework;
using Rhino.Mocks;

namespace Driven.Mocking
{
    [TestFixture]
    public class SimpleStub
    {
        public void Pass_a_stub_object_into_the_system_under_test()
        {
            // Create a Stub (fake implementation) of the INotifier interface
            var notifier = MockRepository.GenerateStub<INotifier>();

            // Pass the Stub into the SUT
            IReportSender reportSender = new SimpleReportSender(notifier);

            // Exercise the SUT
            reportSender.PublishReport("Hello World");

        }
    }
}