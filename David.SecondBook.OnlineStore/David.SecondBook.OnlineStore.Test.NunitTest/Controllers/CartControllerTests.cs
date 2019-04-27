using NUnit.Framework;
using David.SecondBook.OnlineStore.WebApp.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using David.SecondBook.OnlineStore.Domain.Abstract;
using Moq;
using David.SecondBook.OnlineStore.Domain.Entities;
using System.Web.Mvc;

namespace David.SecondBook.OnlineStore.WebApp.Controllers.Tests
{
    [TestFixture()]
    public class CartControllerTests
    {
        [Test()]
        public void CartControllerTest()
        {
            Assert.Fail();
        }

        [Test()]
        public void IndexTest()
        {
            Assert.Fail();
        }

        [Test()]
        public void AddToCartTest()
        {
            Assert.Fail();
        }

        [Test()]
        public void UpdateCartTest()
        {
            Assert.Fail();
        }

        [Test()]
        public void RemoveFromCartTest()
        {
            Assert.Fail();
        }

        [Test()]
        public void SummaryTest()
        {
            Assert.Fail();
        }

        //[Test()]
        //public void Checkout_GET_Test()
        //{
        //    // Arrange - create a mock order processor
        //    Mock<IOrderProcessor> mock = new Mock<IOrderProcessor>();
        //    // Arrange - create an instance of the controller
        //    CartController target = new CartController(null, mock.Object);
        //    // Act - try to checkout
        //    ViewResult result = target.Checkout();
        //    // Assert - check that the order has been passed on to the processor
        //    mock.Verify(m => m.ProcessOrder(It.IsAny<Cart>(), It.IsAny<ShippingDetails>()), Times.Once());
        //    // Assert - check that the method is returning the Completed view
        //    Assert.AreEqual("Completed", result.ViewName);
        //}

        [Test()]
        public void Checkout_POST_Test()
        {
            // Arrange - create a mock order processor
            Mock<IOrderProcessor> mock = new Mock<IOrderProcessor>();
            // Arrange - create a cart with an item
            Cart cart = new Cart();
            cart.AddItem(new Product(), 1);
            // Arrange - create an instance of the controller
            CartController target = new CartController(null, mock.Object);
            // Act - try to checkout
            ViewResult result = target.Checkout(cart, new ShippingDetails());
            // Assert - check that the order has been passed on to the processor
            mock.Verify(m => m.ProcessOrder(It.IsAny<Cart>(), It.IsAny<ShippingDetails>()), Times.Once());
            // Assert - check that the method is returning the Completed view
            Assert.AreEqual("Completed", result.ViewName);
            // Assert - check that I am passing a valid model to the view
            Assert.AreEqual(true, result.ViewData.ModelState.IsValid);
        }

    }
}