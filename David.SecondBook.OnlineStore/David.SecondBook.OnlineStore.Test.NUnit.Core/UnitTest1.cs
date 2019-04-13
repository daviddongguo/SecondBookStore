using NUnit.Framework;
using System;

namespace Tests
{
    [TestFixture]
    public class Tests
    {
        private string TAG;

        [SetUp]
        public void Setup()
        {
            System.Console.Write("Test started.... ");
            TAG = "UNIQUE";
        }

        [Test]
        public void IsNull()
        {
            System.Console.WriteLine("....");

            Assert.That("", Is.Not.Null);
            Assert.That(true, Is.True);
            Assert.That("Hello!", Is.Not.Empty);

            Assert.That("Hello World!", Does.Contain("WORLD").IgnoreCase);
            Assert.That("Hello World!", Is.EqualTo("hello world!").IgnoreCase);
        }

        [TestCase(0)]
        public void ThrownException(int value)
        {
            System.Console.WriteLine("....");

            int result;
            Assert.Throws<DivideByZeroException>(() => result = 5 / value);
            int[] array = new int[5];
            Assert.Throws<IndexOutOfRangeException>(() => result = array[value - 1]);
        }

        [Test]
        public void Test_ShouldThrowEXcetption()
        {
            System.Console.WriteLine("divide by zero");

            // Arrange
            int a = 1, b = 0;
            // Act
            try
            {
                int expected = a / b;
            }
            catch (Exception e)
            {
                // Assert
                Assert.That(e.Message, Does.Contain("divide by zero"));
                Console.WriteLine(e.Message);
                return;
            }

            Assert.Fail("The expected exception was not thrown.");
        }


    }
}