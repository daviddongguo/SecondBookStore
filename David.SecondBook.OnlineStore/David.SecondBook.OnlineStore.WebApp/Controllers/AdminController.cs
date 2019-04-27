using David.SecondBook.OnlineStore.Domain.Abstract;
using David.SecondBook.OnlineStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace David.SecondBook.OnlineStore.WebApp.Controllers
{
    public class AdminController : Controller
    {
        private IProductsRepository repository;
        public AdminController(IProductsRepository repo)
        {
            repository = repo;
        }
        public ViewResult Index()
        {
            return View(repository.ProductsList);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Product product = this.repository.ProductsList.FirstOrDefault(p => p.Id == id);
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                this.repository.SaveProduct(product);
                TempData["message"] = string.Format("{0} has been saved", product.Name);
                return RedirectToAction("Index");
            }
            else
            {
                // there is something wrong with the data values
                return View(product);
            }

        }

        public ActionResult Details(int id)
        {
            Product product = this.repository.ProductsList.FirstOrDefault(p => p.Id == id);
            return View(product);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var dbProduct = this.repository.DeleteProduct(id);
            if (dbProduct != null)
            {                
                TempData["message"] = string.Format("-- {0} -- has been Deleted", dbProduct.Name);
                return RedirectToAction("Index");
            }
            else
            {
                TempData["message"] = string.Format("{0} has not been found", id);
                return RedirectToAction("Edit");
            }

        }

        public ViewResult Create()
        {
            return View("Edit", new Product());
        }

    }
}