/*
 *      This example demonstrates a simple use of an stub. Step through the test method and see how it works.
 *      
 *      Observe:
 *      
 *            1.  There are a huge number of ways of asserting. Look through the Assert class in reflector to see more options.
 *            1.  There are multiple ways of asserting the same thing. Pick the one that is most readable
 *          
 */

using NUnit.Framework;

namespace Driven.UnitTesting
{
    [TestFixture]
    public class SimpleAsserts
    {
        [Test]
        public void VariousDifferentWaysOfAsserting()
        {
            // Equality
            Assert.AreEqual(1, 1);
            Assert.That(1, Is.EqualTo(1));
            Assert.AreNotEqual(1, 2);
            Assert.That(1, Is.Not.EqualTo(2));

            // Boolean
            Assert.IsTrue(1 == 1);
            Assert.IsFalse(1 == 2);
            
            // Other
            object result = null;
            Assert.IsNull(result);

            Assert.IsNotNullOrEmpty("Hello World");

            Assert.That(2, Is.Not.AtLeast(3));
            
            var list = new[] {1, 3, 5, 9};
            Assert.That(list, Is.Unique);
        }
    }
}