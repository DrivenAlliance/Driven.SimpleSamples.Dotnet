/*
 *      This example demonstrates the usage of anonymous methods. Step through the test method and see they work.
 *      
 *      Terminology:
 *      
 *          1.  Anonymous Method    -   These allow you to create inline un-named ( i.e. anonymous ) methods in your code, 
 *                                      which can help increase the readability and maintainability of your applications 
 *                                      by keeping the caller of the method and the method itself as close to one another 
 *                                      as possible. This is similar to the best practice of keeping the declaration of a 
 *                                      variable, for example, as close to the code that uses it.
 *          
 *      Observe:
 *          
 *          1.  This time there is no method called printSquareRoot. It is created inline.
 * 
 */


using System;
using NUnit.Framework;

namespace DelegatesAndLambdas
{
    [TestFixture]
    public class AnonymousMethods
    {
        // Declaration
        public delegate void SimpleDelegate(double parm1);

        [Test]
        public void Instantiate_and_invoke_an_anonymous_method()
        {
            // Instantiation
            SimpleDelegate printSquareRoot = delegate(double number)
                 {
                     Console.WriteLine(Math.Sqrt(number));
                 };

            // Invocation
            printSquareRoot(49);
            
        }

        [Test]
        public void Use_a_framework_method_that_accepts_a_ActionOfT_delegate()
        {
            var samples = new System.Collections.Generic.List<double> { 9, 16, 25, 36 };

            // Instantiation
            Action<double> printSquareRoot = delegate(double number)
                {
                    Console.WriteLine(Math.Sqrt(number));
                };

            // Invocation
            samples.ForEach(printSquareRoot);            
        }

    }
}