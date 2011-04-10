/*
 *      This example demonstrates a simple use of an stub. Step through the test method and see how it works.
 *      
 *      Terminology:
 *      
 *          1.  [TestFixture]   -   This attribute tells the NUnit framework that there are tests in this class. Test fixture classes should be public
 *          2.  [Test]          -   This attribute tells the NUnit framework that this method is a Test. Tests must be public and return void
 *          3.  TripleA syntax  -   This refers to the way tests are structured - Arrange Act Assert
 *          4.  Arrange         -   Set up the objects and application state you would like to test
 *          5.  Act             -   Exercise the piece of code under test
 *          6.  Assert          -   Check that the results of the actions are what was expected
 *          
 *      Try:
 *      
 *          1.  Run the test and watch it pass
 *          2.  Debug the test and step through the code to see the paths it takes
 *          3.  Change the input variables and watch the test fail
 * 
 */

using Driven.UnitTesting.ExampleClasses;
using NUnit.Framework;

namespace Driven.UnitTesting
{
    [TestFixture]
    public class SimpleTest
    {
        [Test]
        public void CanAddTwoNumbers()
        {
            // Arrange
            var calculator = new Calculator();

            // Act
            var result = calculator.AddTwoIntegers(10, 20);

            // Assert
            Assert.That(result, Is.EqualTo(10 + 20));
        }
    }
}