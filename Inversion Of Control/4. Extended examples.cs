/*
 *      You can see all the possible permutations of using a container by going through the unit tests
 *      for the Windsor Container:
 *      
 *      http://svn.castleproject.org:8080/svn/castle/trunk/InversionOfControl/Castle.MicroKernel.Tests/Registration/
 * 
 * 
*/

using System;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using NUnit.Framework;

namespace Driven.InversionOfControl
{
    [TestFixture]
    public class ExtendedExamples
    {
        [Test]
        public void Demonstrate_configuring_the_same_service_with_two_different_implementations()
        {
            IWindsorContainer container;
            IAnimal animal;

            // Configure IAnimal to be a Dog that has a LoudBark
            container = configureContainerLoudDog();
            animal = container.Resolve<IAnimal>();

            animal.MakeNoise();


            // Configure IAnimal to a Dog that has a QuietBark
            container = configureContainerQuietDog();
            animal = container.Resolve<IAnimal>();

            animal.MakeNoise();

        }

        private IWindsorContainer configureContainerLoudDog()
        {
            IWindsorContainer container = new WindsorContainer();

            container.Register(Component.For<IAnimal>()
                                   .ImplementedBy<Dog>());

            container.Register(Component.For<IBarker>()
                                   .ImplementedBy<LoudBark>());

            return container;
        }

        private IWindsorContainer configureContainerQuietDog()
        {
            IWindsorContainer container = new WindsorContainer();

            container.Register(Component.For<IAnimal>()
                                   .ImplementedBy<Dog>());

            container.Register(Component.For<IBarker>()
                                   .ImplementedBy<QuietBark>());

            return container;
        }
    }

    internal interface IAnimal
    {
        void MakeNoise();
    }

    class Dog : IAnimal
    {
        private readonly IBarker _barker;

        public Dog(IBarker barker)
        {
            _barker = barker;
        }

        public void MakeNoise()
        {
            _barker.Bark();
        }
    }

    interface IBarker
    {
        void Bark();
    }

    class LoudBark : IBarker
    {
        public void Bark()
        {
            Console.WriteLine("WOOF WOOF!");
        }
    }

    class QuietBark : IBarker
    {
        public void Bark()
        {
            Console.WriteLine("woof.");
        }
    }
}