// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using David.SecondBook.OnlineStore.Domain.Abstract;
using David.SecondBook.OnlineStore.Domain.Entities;
using David.SecondBook.OnlineStore.WebApp.Controllers;
using Moq;
using NUnit.Framework;

namespace David.SecondBook.OnlineStore.NUnit.Tests
{
    [TestFixture]
    public class TestClass
    {
        [Test]
        public void TestMethod()
        {
            // TODO: Add your test code here
            var answer = 42;
            Assert.That(answer, Is.EqualTo(42), "Some useful error message");
        }


        [Test]
        public void Test_ProductControll_List()
        {
            // Arrange
            Mock<IProductsRepository> mock = new Mock<IProductsRepository>();
            mock.Setup(m => m.ProductsList).Returns                                 // Setup object 
                (
                    new Product[]
                    {
                    new Product { Name = "Mock Football", Price = 25, Category="0" },
                    new Product { Name = "Mock Surf board", Price = 179, Category="0" },
                    new Product { Name = "Mock Running shoes", Price = 95, Category="0" }
                     }
                );
            ProductController controller = new ProductController(mock.Object);      // Retrieve object

            // Act
            var result = (ViewResult)controller.List();
            var resultMsg = ((IEnumerable<Product>)result.Model).ToArray()[0].Name;

            // Assert
            Console.WriteLine(resultMsg);
            Assert.That(resultMsg.Contains("Mock Footbal"), resultMsg);

        }

    }
}
