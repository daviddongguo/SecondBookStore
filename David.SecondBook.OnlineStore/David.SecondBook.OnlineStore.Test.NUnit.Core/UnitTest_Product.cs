using David.SecondBook.OnlineStore.Domain.Abstract;
using David.SecondBook.OnlineStore.Domain.Entities;
using David.SecondBook.OnlineStore.WebApp.Controllers;
using David.SecondBook.OnlineStore.WebApp.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Web.Mvc;
using David.SecondBook.OnlineStore.WebApi.Controllers;

namespace Tests
{
    [TestFixture]
    public class UnitTest_Product
    {
        private string TAG;

        [SetUp]
        public void Setup()
        {
            System.Console.Write("Test started.... ");
            TAG = "UNIQUE";
        }

        [Test]
        public void Test_Product_List()
        {
            // Arrange
            Mock<IProductsRepository> mock = new Mock<IProductsRepository>();
            mock.Setup(m => m.ProductsList).Returns                                 // Setup object 
                (
                    new Product[]
                    {
                    new Product { Name = "Mock Football", Price = 25,},
                    new Product { Name = "Mock Surf board", Price = 179,},
                    new Product { Name = "Mock Running shoes", Price = 95,}
                    }
                );

            // Act

            // Assert
            foreach (var item in mock.Object.ProductsList)
            {
                Console.WriteLine(item.Name);
                if(item.Name.Contains("MOck Footbal")){
                Assert.That(item.Name.Contains("Mock Footbal"), item.Name);
                }
            }
        }
        [Test]
        public void Test_ValuesController()
        {
            // Arrange
            ValuesController controller = new ValuesController();      // Retrieve object

            // Act
            var result = controller.Get().Value.ToArray()[0];

            // Assert
            Console.WriteLine(result);
            Assert.That(result.ToString().Contains("value1"), result.ToString());

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
                    new Product { Name = "Mock Football", Price = 25 },
                    new Product { Name = "Mock Surf board", Price = 179 },
                    new Product { Name = "Mock Running shoes", Price = 95 }
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

        [Test]
        public void Can_Paginate()
        {
            // Arrange
            Mock<IProductsRepository> mock = new Mock<IProductsRepository>();
            mock.Setup(m => m.ProductsList).Returns(new Product[] {
new Product {Id = 1, Name = "P1"},
new Product {Id = 2, Name = "P2"},
new Product {Id = 3, Name = "P3"},
new Product {Id = 4, Name = "P4"},
new Product {Id = 5, Name = "P5"}
});
            ProductController controller = new ProductController(mock.Object);
            controller.PageSize = 3;
            // Act
            var result = (IEnumerable<Product>)controller.List("", 2).Model;
            // Assert
            Product[] prodArray = result.ToArray();
            Assert.IsTrue(prodArray.Length == 2);
            Assert.AreEqual(prodArray[0].Name, "P4");
            Assert.AreEqual(prodArray[1].Name, "P5");
        }





    }
}