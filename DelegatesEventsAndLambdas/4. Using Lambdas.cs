// ReSharper disable RedundantLambdaParameterType
/*
 *      This example demonstrates the use of a lambdas. Step through the test methods and see how they work.
 *      
 *      Terminology:
 *      
 *          1.  Lambda  -   A lambda expression is an anonymous function that can contain expressions and statements, 
 *                          and can be used to create delegates or expression tree types. All lambda expressions use 
 *                          the lambda operator =>, which is read as "goes to". The left side of the lambda operator 
 *                          specifies the input parameters (if any) and the right side holds the expression or statement 
 *                          block. The lambda expression [[ x => x * x ]] is read "x goes to x times x." 
 *          
 *      Observe:
 *      
 *          1.  The most long-winded form of a lambda expression goes like this:
 *                  
 *                  (explicitly-typed-parameter-list) => { statements }
 *                  
 *          2.  The compiler is smart enough to reduce this down to the bare necessities:
 *          
 *                  parameter-name => expression
 */


using System;
using NUnit.Framework;
using System.Linq;

namespace DelegatesAndLambdas
{
    [TestFixture]
    public class Lambdas
    {
        // Declaration
        public delegate void SimpleDelegate(double parm1);

        [Test]
        public void Use_a_simple_lambda_expression()
        {
            // Instantiation - anonymous method
            SimpleDelegate anon = delegate(double number) { Console.WriteLine(Math.Sqrt(number)); };

            // Instantiation - lambda, full syntax
            SimpleDelegate lambda1 = (double number) => Console.WriteLine(Math.Sqrt(number));

            // Instantiation - lambda, shorthand
            SimpleDelegate lambda2 = (number) => Console.WriteLine(Math.Sqrt(number));

            // Instantiation - lambda, concise
            SimpleDelegate lambda3 = number => Console.WriteLine(Math.Sqrt(number));

            // Invocation
            anon(49);
            lambda1(49);
            lambda2(49);
            lambda3(49);

        }

        [Test]
        public void Use_a_lamda_expression_that_returns_a_result()
        {
            // Instantiation - anonymous method
            Func<string, int> returnLengthAnon = delegate(string text) { return text.Length; };

            // Instantiation - lambda, full syntax
            Func<string, int> returnLengthLambda1 = (string text) => { return text.Length; };

            // Instantiation - lambda, shorthand
            Func<string, int> returnLengthLambda2 = (string text) => text.Length; 

            // Instantiation - lambda, concise
            Func<string, int> returnLengthLambda3 = text => text.Length;


            // Invocation
            Console.WriteLine(returnLengthAnon("Hello Anonymous World"));
            Console.WriteLine(returnLengthLambda1("Hello Lambda World"));
            Console.WriteLine(returnLengthLambda2("Hello Lambda World"));
            Console.WriteLine(returnLengthLambda3("Hello Lambda World"));
        }
        

    }
}