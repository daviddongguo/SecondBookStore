using David.SecondBook.OnlineStore.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace David.SecondBook.OnlineStore.WebApp.Controllers
{
    public class ProductController : Controller
    {
        private IProductsRepository rep;

        public ProductController(IProductsRepository rep)
        {
            this.rep = rep;
        }

        //
        public ViewResult List()
        {
            return View(rep.ProductsList);
        }

        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
    }
}