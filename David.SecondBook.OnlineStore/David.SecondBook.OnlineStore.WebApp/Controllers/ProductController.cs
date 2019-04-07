using David.SecondBook.OnlineStore.Domain.Abstract;
using David.SecondBook.OnlineStore.WebApp.Models;
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

        private const int PageSize = 2;

        public ProductController(IProductsRepository rep)
        {
            this.rep = rep;
        }

        //
        public ViewResult List(string category, int page = 1)
        {
            var categoryProducts = rep
                .ProductsList
                .Where(p => category == null || p.Category == category);

            ProductsViewModel model = new ProductsViewModel
            {
                ProductsList = categoryProducts
            .OrderBy(p => p.Id)
            .Skip((page - 1) * PageSize)
            .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = categoryProducts.Count()
                },
                CurrentCategory = category
            };
            model.PagingInfo.TotalItems = categoryProducts.Count();
            return View(model);
        }

        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
    }
}