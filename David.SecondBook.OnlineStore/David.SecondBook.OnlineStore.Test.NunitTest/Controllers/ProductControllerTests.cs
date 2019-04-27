using David.SecondBook.OnlineStore.WebApp.Controllers;
using David.SecondBook.OnlineStore.Domain.Abstract;
using David.SecondBook.OnlineStore.Domain.Entities;
using David.SecondBook.OnlineStore.WebApp.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace David.SecondBook.OnlineStore.WebApp.Controllers.Tests
{
    [TestFixture()]
    public class ProductControllerTests
    {

        private const string TAG = "Mock Football";
        private Mock<IProductsRepository> mock;

        [SetUp]
        public void Setup()
        {
            System.Console.Write("Test started.... ");
            mock = new Mock<IProductsRepository>();
            mock.Setup(m => m.ProductsList).Returns(
                new List<Product>
                {
                    new Product { Name = TAG, Price = 25,},
                    new Product { Name = "Mock Surf board", Price = 179,},
                    new Product { Name = "Mock Running shoes", Price = 95,}
                });
        }

        [Test]
        public void ListTest_Should_When()
        {
            // Arrange
            var list = mock.Object.ProductsList;
            // Act
            foreach (var item in list)
            {
                Console.WriteLine(item.Name);
                if (item.Name.Contains(TAG))
                {
                    // Assert
                    Assert.That(item.Name.Contains(TAG), item.Name);
                }
            }
        }

        [Test]
        public void ListTest_List()
        {
            // Arrange
            ProductController controller = new ProductController(mock.Object);      // Retrieve object

            // Act
            var result = ((ProductsViewModel)controller.List().Model).ProductsList.ToList();
            var resultMsg = result.ToArray()[0].Name;

            // Assert
            Console.WriteLine(resultMsg);
            Assert.That(resultMsg.Contains("Mock Footbal"), resultMsg);

        }

        [Test]
        public void ListTest_Can_Paginate()
        {
            // Arrange
            var list = mock.Object;

            // Act
            ProductController controller = new ProductController(list);
            controller.PageSize = 2;
            var result = ((ProductsViewModel)controller.List(null, 2).Model).ProductsList.ToList();
            // Assert
            Product[] prodArray = result.ToArray();
            Assert.IsTrue(prodArray.Length == 1);
            Assert.AreEqual(prodArray[0].Name, "Mock Running shoes");
        }

        //[Test]
        //public void Indicates_Selected_Category()
        //{
            //// Arrange
            //// - create the mock repository
            //Mock<IProductsRepository> mock = new Mock<IProductsRepository>();
            //mock.Setup(m => m.ProductsList).Returns(new Product[]
            //{
            //        new Product {Id = 1, Name = "P1", Category = "Apples"},
            //        new Product {Id = 4, Name = "P2", Category = "Oranges"},
            //});
            //// Arrange - create the controller
            //NavController target = new NavController(mock.Object);
            //// Arrange - define the category to selected
            //string categoryToSelect = "Apples";
            //// Action
            //string result = target.Menu(categoryToSelect).ViewBag.SelectedCategory;
            //// Assert
        //    //Assert.AreEqual(categoryToSelect, result);
        //}

        [Test]
        public void Generate_Category_Specific_Product_Count()
        {
            // Arrange
            // - create the mock repository
            Mock<IProductsRepository> mock = new Mock<IProductsRepository>();
            mock.Setup(m => m.ProductsList).Returns(new Product[]
            {
                new Product {Id = 1, Name = "P1", Category = "Cat1"},
                new Product {Id = 2, Name = "P2", Category = "Cat2"},
                new Product {Id = 3, Name = "P3", Category = "Cat1"},
                new Product {Id = 4, Name = "P4", Category = "Cat2"},
                new Product {Id = 5, Name = "P5", Category = "Cat3"}
            });
            // Arrange - create a controller and make the page size 3 items
            ProductController target = new ProductController(mock.Object);
            target.PageSize = 3;
            // Action - test the product counts for different categories
            int res1 = ((ProductsViewModel)target.List("Cat1").Model).PagingInfo.TotalItems;
            int res2 = ((ProductsViewModel)target.List("Cat2").Model).PagingInfo.TotalItems;
            int res3 = ((ProductsViewModel)target.List("Cat3").Model).PagingInfo.TotalItems;
            int resAll = ((ProductsViewModel)target.List(null).Model).PagingInfo.TotalItems;
            // Assert
            Assert.AreEqual(res1, 2);
            Assert.AreEqual(res2, 2);
            Assert.AreEqual(res3, 1);
            Assert.AreEqual(resAll, 5);
        }


        [TestCase(1)]
        [TestCase(2)]
        [TestCase(100)]
        public void ProductControllerTest(int pageSize)
        {
            try
            {
                // Arrange
                using (ProductController controller = new ProductController(mock.Object)
                {
                    PageSize = pageSize
                })
                {
                    Assert.That(controller, Is.Not.Null);
                    Assert.That(controller.PageSize == pageSize, Is.True);
                }
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        [Test]
        public void Can_Send_Pagination_View_Model()
        {
            // Arrange
            Mock<IProductsRepository> mock = new Mock<IProductsRepository>();
            mock.Setup(m => m.ProductsList).Returns(new Product[]
            {
                new Product {Id = 1, Name = "P1"},
                new Product {Id = 2, Name = "P2"},
                new Product {Id = 3, Name = "P3"},
                new Product {Id = 4, Name = "P4"},
                new Product {Id = 5, Name = "P5"}
            });
            // Arrange
            ProductController controller = new ProductController(mock.Object);
            controller.PageSize = 3;
            // Act
            ProductsViewModel result = (ProductsViewModel)controller.List(null, 2).Model;
            // Assert
            PagingInfo pageInfo = result.PagingInfo;
            Assert.AreEqual(pageInfo.CurrentPage, 2);
            Assert.AreEqual(pageInfo.ItemsPerPage, 3);
            Assert.AreEqual(pageInfo.TotalItems, 5);
            Assert.AreEqual(pageInfo.TotalPages, 2);
        }

        [Test]
        public void Can_Create_Categories()
        {
            // Arrange
            // - create the mock repository
            Mock<IProductsRepository> mock = new Mock<IProductsRepository>();
            mock.Setup(m => m.ProductsList).Returns(new Product[]
            {
                new Product {Id = 1, Name = "P1", Category = "Apples"},
                new Product {Id = 2, Name = "P2", Category = "Apples"},
                new Product {Id = 3, Name = "P3", Category = "Plums"},
                new Product {Id = 4, Name = "P4", Category = "Oranges"},
            });
            // Arrange - create the controller
            NavController target = new NavController(mock.Object);
            // Act = get the set of categories
            string[] results = ((IEnumerable<string>)target.Menu().Model).ToArray();
            // Assert
            Assert.AreEqual(results.Length, 3);
            Assert.AreEqual(results[0], "Apples");
            Assert.AreEqual(results[1], "Oranges");
            Assert.AreEqual(results[2], "Plums");
        }

    }
}