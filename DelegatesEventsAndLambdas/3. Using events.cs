/*
 *      This example demonstrates the use of a simple event. Step through the test method and see how it works.
 *      
 *      Terminology:
 *      
 *          1.  Event   -   An event in C# is a way for a class to provide notifications to clients of that class when 
 *                          some interesting thing happens to an object. The most familiar use for events is in graphical 
 *                          user interfaces; typically, the classes that represent controls in the interface have events 
 *                          that are notified when the user does something to the control (for example, click a button).
 *          
 *      Observe:
 *          
 *          1.  Events are declared using delegates. 
 *          2.  We subscrive to an event using the [[ += ]] syntax. To unsubscribe from an event, use [[ -= ]]
 *          3.  We must check for null before calling an event. If there are no subscribers, it will be null.
 *          4.  The invocation of the EvenNumberFound event is in a methof called onEvenNumberFound and this method is 
 *              marked as protected. This is because events can only be fired from the class they are declared in - 
 *              which means you cannot call them directly from a derived class!
 *          X.  Not shown in this example, but relevant: Many code components can subscribe to the same event. They will be 
 *              called in the order that they subscribe
 *          X.  Events can be very hard to debug, and should be used with caution, especially when using them to control
 *              the logical flow of an application. Often, the solution option that doesn't require an event is a the cleaner 
 *              one.
 *          
 *      Try:
 *      
 *          1.  Add your own event to notify the outside world when an non-even number is found by Foo.
 * 
 */


using System;
using NUnit.Framework;

namespace DelegatesAndLambdas
{
    [TestFixture]
    public class SimpleEvents
    {
        [Test]
        public void Instantiate_and_invoke_a_delegate_using_the_CSharp1_syntax()
        {
            var foo = new Foo();

            // Subscribe to event
            foo.EvenNumberFound += printSquareRoot;

            foo.DoSomething(15);
            foo.DoSomething(16);
            foo.DoSomething(17);
        }

        private void printSquareRoot(double number)
        {
            Console.WriteLine("Square root == {0}", Math.Sqrt(number));
        }
    }


    public class Foo
    {
        // Delegate Declaration
        public delegate void SimpleDelegate(double parm1);

        // Event Declaration
        public event SimpleDelegate EvenNumberFound;

        public void DoSomething(double number)
        {
            Console.WriteLine("Doing something really important with {0}.", number);

            if (isEven(number))
            {
                Console.WriteLine("Found an even number!"); 
                onEvenNumberFound(number);
            }
        }

        private bool isEven(double number)
        {
            return number % 2 == 0;
        }

        protected void onEvenNumberFound(double number)
        {
            // Event Invocation
            if (EvenNumberFound != null) 
                EvenNumberFound(number);
        }
    }
}