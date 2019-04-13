using David.SecondBook.OnlineStore.Domain.Entities;
using NUnit.Framework;
using System;

namespace Tests
{
    [TestFixture]
    public class Test_Database
    {
        private string TAG;

        [SetUp]
        public void Setup()
        {
            System.Console.Write("Test started.... ");
            TAG = "UNIQUE";
        }

        [Test]
        public void Test_Database_IsExisted()
        {
            using (var ctx = new EFDbContext())
            {
                var expected = ctx.ProductsList;

                foreach (var item in expected)
                {
                    Console.WriteLine(item.ToString());
                }

                Assert.That(expected, Is.Not.Null);
            }
        }        
    }
}