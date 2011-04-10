/*
 *      This example demonstrates a simple use of an stub. Step through the test method and see how it works.
 *      
 *      Observe:
 *      
 *            1.  All asserts have an optional message.
 *            2.  The message you write should give more information about what you were expecting to happen
 *            3.  Only add a custom message if you are improving the default one (the example below does not improve on the default)
 *          
 *      Try:
 *          
 *            1.  Run the test and observe the output. See that the message does not appear in the result
 *            2.  Change an input variable and re-run the test. See that the custom message is now displayed
 *            3.  Remove the custom message and run the test again. See the default message. Does the custom message improve the default one?
 */

using Driven.UnitTesting.ExampleClasses;
using NUnit.Framework;

namespace Driven.UnitTesting
{
    [TestFixture]
    public class AssertsMessages
    {
        [Test]
        public void AddingMessagesToAsserts()
        {
            // Arrange
            var calculator = new Calculator();

            // Act
            var result = calculator.AddTwoIntegers(11, 22);

            // Assert
            Assert.That(result, Is.EqualTo(33), "Two numbers were not added as expected");

        }
    }
}