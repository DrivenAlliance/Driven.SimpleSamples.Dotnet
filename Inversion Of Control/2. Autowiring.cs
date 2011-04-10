/*
 *      This example demonstrates how 'Auto Wiring' makes life simpler. Step through the test method and 
 *      see how it works.
 *      
 *      Terminology:
 *      
 *          1.  AutoWiring  -   The ability of the IoC container to know what dependencies are required to create a class
 *                              and to then create them for you automagically *          
 *      Observe:
 *      
 *          1.  At no time do we tell the container that SimpleReportSender requires an INotifier. It is smart enough 
 *              to work this out for itself!
 *          
 *      Try:
 *      
 *          1.  Add a different implementation for IReportSender and configure the container to use that instead
 * 
 */

using Castle.Core;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Driven.InversionOfControl.ExampleClasses;
using NUnit.Framework;

namespace Driven.InversionOfControl
{
    [TestFixture]
    public class AutoWiring
    {
        [Test]
        public void Register_and_use_an_IReportSender_Service_without_creating_its_dependencies()
        {
            // Create a container instance
            IWindsorContainer container = new WindsorContainer();

            // Add services to the container 
            configureContainer(container);

            // Ask the container for a service
            var reportSender = container.Resolve<IReportSender>();

            /* At this point, we have an instance of an IReportSender that has either an EmailSender 
             * or an SmsSender injected into it, depending on how we configured the container */

            // Send the notification
            reportSender.PublishReport("Hello World");

        }

        private void configureContainer(IWindsorContainer container)
        {
            // Configure INotifier service to be implemented by the EmailNotifier concrete type
            container.Register(Component
                                   .For<INotifier>()
                                   .ImplementedBy<EmailNotifier>()
                                   .LifeStyle.Is(LifestyleType.Transient));

            // Configure IReportSender service to be implemented by SimpleReportSender
            container.Register(Component
                                   .For<IReportSender>()
                                   .ImplementedBy<SimpleReportSender>()
                                   .LifeStyle.Is(LifestyleType.Transient));

            /* NOTE: At no time do we tell the container that SimpleReportSender requires an INotifier. It is 
             * smart enough to work this out for itself!
            */

        }
    }
}