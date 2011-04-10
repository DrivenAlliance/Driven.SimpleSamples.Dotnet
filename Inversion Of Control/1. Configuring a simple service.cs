/*
 *      This example demonstrates a simple use of an inversion of control container. Step through the test method 
 *      and see how it works.
 *      
 *      Terminology:
 *      
 *          1.  Container   -   This is a configurable repository of services.
 *          2.  Service     -   This is a particular item that the Container is aware of (typically an interface)
 *          3.  Component   -   This is the concrete type that implements the service
 *          4.  Registering -   This is the act of notifying the Container of a Service and the Component that implements it
 *          5.  IoC         -   Inversion of Control. A software design pattern.
 *          
 *      Observe:
 *      
 *          1.  The test method has no knowledge of which INotifier is actually created
 *          2.  The service is created as 'Transient'. This means a new component will be created each time you ask
 *              the container for it. If you set it to 'Singleton', then you will get the same component instance each
 *              time you ask for the service.
 *          
 *      Try:
 *      
 *          1.  Change the concrete type that implements the service from EmailNotifier to SmsNotifier
 * 
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
    public class SimpleComponentRegistration
    {
        [Test]
        public void Register_and_use_an_INotifier_Service()
        {
            // Create a container instance
            IWindsorContainer container = new WindsorContainer();

            // Add services to the container (ie register specific interfaces and their concrete types)
            configureContainer(container);

            // Ask the container for a particular service (represented by an interface)
            var notifier = container.Resolve<INotifier>();

            /* At this point, whether we have an EmailSender or an SmsSender depends on how we configured the container */

            // Send the notification
            notifier.Send("Hello World");

        }

        private void configureContainer(IWindsorContainer container)
        {
            // Configure INotifier service to be implemented by the EmailNotifier concrete type
            container.Register(Component
                                   .For<INotifier>()
                                   .ImplementedBy<EmailNotifier>()
                                   .LifeStyle.Is(LifestyleType.Transient));
        }
    }
}