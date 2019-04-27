// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

namespace David.SecondBook.OnlineStore.Test.NunitTest
{
    [TestFixture]
    public class TestExample
    {

        [SetUp]
        public void Setup()
        {
            System.Console.Write("Test started.... /n");
        }

        [Test]
        public void TestMethod()
        {
            // TODO: Add your test code here
            var answer = 42;
            Assert.That(answer, Is.EqualTo(42), "Some useful error message");
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

        // What is being tested
        // What circumstances or scenario
        // What is expected result
        [TestCase(0)]
        public void Should_ThrowEXcetption_When_AnyCondition(int value)
        {
            System.Console.WriteLine("divide by zero");

            // Arrange
            int a = 1;
            // Act
            try
            {
                int expected = a / value;
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
