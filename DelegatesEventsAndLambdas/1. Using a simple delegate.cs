// ReSharper disable RedundantDelegateCreation
/*
 *      This example demonstrates the use of a simple delegate. Step through the test method and see how it works.
 *      
 *      Terminology:
 *      
 *          1.  Delegate    -   A type-safe function pointer. A delegate will allow us to specify what the function we'll 
 *                              be calling looks like without having to specify which function to call. The declaration for 
 *                              a delegate looks just like the declaration for a function, except that in this case, we're 
 *                              declaring the signature of functions that this delegate can reference.  
 *          
 *      Observe:
 *          
 *          1.  There are three steps in defining and using a delegate: Declaration, Instantiation and Invocation
 *          2.  You can pass a delegate around as if it were a variable
 *      
 *          
 *      Try:
 *      
 *          1.  Add your own method and invoke it via the SimpleDelegate
 * 
 */


using System;
using NUnit.Framework;

namespace DelegatesAndLambdas
{
    [TestFixture]
    public class SimpleDelegates
    {
        // Declaration
        public delegate void SimpleDelegate(double parm1);

        [Test]
        public void Instantiate_and_invoke_a_delegate_using_the_CSharp1_syntax()
        {
            // Instantiation
            var simpleDelegate = new SimpleDelegate(printSquareRoot);

            // Invocation
            simpleDelegate(49);
        }

        [Test]
        public void Instantiate_and_invoke_a_delegate_using_the_CSharp2_syntax()
        {
            // Instantiation
            SimpleDelegate simpleDelegate = printSquareRoot;

            // Invocation
            simpleDelegate(49);
        }

        [Test]
        public void Pass_a_delegate_as_a_parameter()
        {
            // Instantiation
            SimpleDelegate simpleDelegate = printSquareRoot;

            // Pass as a parameter to a method
            foo(simpleDelegate);
        }

        private void printSquareRoot(double number)
        {
            Console.WriteLine("Square root == {0}", Math.Sqrt(number));
        }
        
        private void foo(SimpleDelegate param1)
        {
            // Invocation
            param1(64);
        }
    }
}