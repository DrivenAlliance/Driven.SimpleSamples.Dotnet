/*
 *      This example demonstrates how 'Auto Wiring' makes life simpler. Step through the test method and 
 *      see how it works.
 *      
 *      Observe:
 *      
 *          1.  All concrete types that implement the specified interface are added to the container
 *          
 *          
 *      Try:
 *      
 *          1.  Replacing the 'BasedOn' with the 'Where' filter
 *          2.  Uncommenting the 'If' filter to see how you can load at an even finer grained level than 
 *              the assembly or namespace
 * */

using System.Reflection;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Driven.InversionOfControl.ExampleClasses;
using NUnit.Framework;

namespace Driven.InversionOfControl
{
    [TestFixture]
    public class RegisterTypesFromAssembly
    {
        [Test]
        public void Register_all_types_in_an_assembly_that_implement_a_specific_interface()
        {
            // Create a container instance
            IWindsorContainer container = new WindsorContainer();

            // Add services to the container 
            configureContainer(container);

            // Ask the container for a service
            var reportSenders = container.ResolveAll<INotifier>();
            
            foreach (var reportSender in reportSenders)
            {
                // Send the notification
                reportSender.Send("Hello World");
            }
        }

        private void configureContainer(IWindsorContainer container)
        {
            // Configure all concrete types that implement the INotifier interface
            container.Register(AllTypes
                                   .FromAssembly(Assembly.GetExecutingAssembly())
                                   .BasedOn<INotifier>()
                                   //.Where(Component.IsInNamespace("InversionOfControl.ExampleClasses"))
                                   //.If(t => t.Name.StartsWith("Em"))
                                   .WithService.FirstInterface()
                                   .Configure(c => c.LifeStyle.Transient));
            
        }
    }
}