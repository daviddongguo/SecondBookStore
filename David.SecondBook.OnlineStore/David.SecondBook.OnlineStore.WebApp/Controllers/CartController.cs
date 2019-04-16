using David.SecondBook.OnlineStore.Domain.Abstract;
using David.SecondBook.OnlineStore.Domain.Entities;
using David.SecondBook.OnlineStore.WebApp.Models;
using System.Linq;
using System.Web.Mvc;

namespace David.SecondBook.OnlineStore.WebApp.Controllers
{
    public class CartController : Controller
    {
        private IProductsRepository repository;
        private IOrderProcessor orderProcessor;

        public CartController(IProductsRepository repository, IOrderProcessor orderProcessor)
        {
            this.repository = repository;
            this.orderProcessor = orderProcessor;
        }

        public ViewResult Index(Cart cart, string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                ReturnUrl = returnUrl,
                Cart = cart
            });
        }
        public RedirectToRouteResult AddToCart(Cart cart, int Id, string returnUrl, int quantity = 1)
        {
            Product product = repository.ProductsList
            .FirstOrDefault(p => p.Id == Id);
            if (product != null)
            {
                cart.AddItem(product, quantity);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
        public RedirectToRouteResult UpdateCart(Cart cart, int Id, string returnUrl, int quantity)
        {
            Product product = repository.ProductsList
            .FirstOrDefault(p => p.Id == Id);
            if (product != null)
            {
                cart.UpdateItem(product, quantity);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(Cart cart, int Id, string returnUrl)
        {
            Product product = repository.ProductsList
            .FirstOrDefault(p => p.Id == Id);
            if (product != null)
            {
                cart.RemoveLine(product);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }

        [HttpGet]
        public ViewResult Checkout()
        {
            return View(new ShippingDetails());
        }

        [HttpPost]
        public ViewResult Checkout(Cart cart, ShippingDetails shippingDetails)
        {
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empty!");
            }
            if (ModelState.IsValid)
            {
                orderProcessor.ProcessOrder(cart, shippingDetails);
                cart.Clear();
                return View("Completed");
            }
            else
            {
                return View(shippingDetails);
            }
        }

    }
}