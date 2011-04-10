/*
 *      These are some extended examples to show some additional features and some 'gotchas'
 *      
 *      Multiple_calls_to_Stub      
 *      1.  See that the result is false the second time you use the Stub!
 *      2.  Uncomment the call to Repeat.Any() to make it return true each time it is called
 *      3.  Observe the other Repeat options: Once (this is the default), AtLeastOnce, Twice, Times(n) and Never
 *      
 * 
 *      Further examples and a deeper explanation of Rhino Mocks:
 *      
 *      http://ayende.com/Wiki/Rhino+Mocks+3.5.ashx
 * 
 */
using Driven.Mocking.ExampleClasses;
using NUnit.Framework;
using Rhino.Mocks;

namespace Driven.Mocking
{
    [TestFixture]
    public class ExtendedExamples
    {
        [Test]
        public void Multiple_calls_to_Stub()
        {
            // Create a Stub (fake implementation) of the INotifier interface
            var notifier = MockRepository.GenerateStub<INotifier>();

            // Set an expectation that when the Send method is called with any arguments, it returns true
            notifier.Expect(x => x.Send(""))
                .IgnoreArguments()
                .Return(true)
                //.Repeat.Any()
                ;

            // Pass the Stub into the SUT
            IReportSender reportSender = new SimpleReportSender(notifier);

            // Exercise the SUT once
            bool result = reportSender.PublishReport("Hello World");
            Assert.That(result, Is.True);

            // Exercise the SUT a second time
            result = reportSender.PublishReport("Hello World");
            Assert.That(result, Is.False);
        }

        [Test]
        public void GettingTheArgumentsThatWereUsedToCallTheMethod()
        {
            // Create a Stub (fake implementation) of the INotifier interface
            var notifier = MockRepository.GenerateStub<INotifier>();
            
            // Pass the Stub into the SUT
            IReportSender reportSender = new SimpleReportSender(notifier);

            // Exercise the SUT once
            reportSender.PublishReport("Hello World 1");
            
            // Exercise the SUT a second time
            reportSender.PublishReport("Hello World 2");


            var firstCall = notifier.GetArgumentsForCallsMadeOn(x => x.Send(null))[0];
            var secondCall = notifier.GetArgumentsForCallsMadeOn(x => x.Send(null))[1];

            var firstCallFirstArg = firstCall[0];
            var secondCallFirstArg = secondCall[0];


            Assert.That(firstCallFirstArg, Is.EqualTo("Hello World 1"));
            Assert.That(secondCallFirstArg, Is.EqualTo("Hello World 2"));

        }
    }
}