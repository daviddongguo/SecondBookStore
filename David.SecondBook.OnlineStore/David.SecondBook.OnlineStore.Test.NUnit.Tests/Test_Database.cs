using David.SecondBook.OnlineStore.Domain.Entities;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace David.SecondBook.OnlineStore.Test.NUnit.Tests
{
    [TestFixture]
    public class Test_Database
    {


        [Test]
        public void Test_datatbase_connection()
        {

            EFDbContext context;
            String productName = "Book for testing";
            using (context = new EFDbContext())
            {
                var product = new Product();
                product.Name = productName;
                var dbProduct = context.ProductsList.Add(product);
                context.SaveChanges();
                var answer = dbProduct.Name;
                Console.WriteLine(dbProduct.Name);

                context.ProductsList.Remove(dbProduct);
                context.SaveChanges();

                Assert.That(answer, Is.EqualTo(productName), "Some thing error ");
            };
        }

        //[Test]
        //public void Test_ProductControll_List()
        //{
        //    // Arrange
        //    Mock<IProductsRepository> mock = new Mock<IProductsRepository>();
        //    mock.Setup(m => m.ProductsList).Returns                                 // Setup object 
        //        (
        //            new Product[]
        //            {
        //            new Product { Name = "Mock Football", Price = 25 },
        //            new Product { Name = "Mock Surf board", Price = 179 },
        //            new Product { Name = "Mock Running shoes", Price = 95 }
        //             }
        //        );
        //    ProductController controller = new ProductController(mock.Object);      // Retrieve object

        //    // Act
        //    var result = (ViewResult)controller.List();
        //    var resultMsg = ((IEnumerable<Product>)result.Model).ToArray()[0].Name;

        //    // Assert
        //    Console.WriteLine(resultMsg);
        //    Assert.That(resultMsg.Contains("Mock Footbal"), resultMsg);

        //}
    }
}
