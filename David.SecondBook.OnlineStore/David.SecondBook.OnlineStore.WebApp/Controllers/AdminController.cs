using David.SecondBook.OnlineStore.Domain.Abstract;
using David.SecondBook.OnlineStore.Domain.Entities;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace David.SecondBook.OnlineStore.WebApp.Controllers
{
    [Authorize]
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

        public ActionResult Edit(Product product, HttpPostedFileBase image = null)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    product.ImageMimeType = image.ContentType;
                    product.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(product.ImageData, 0, image.ContentLength);
                }
                repository.SaveProduct(product);
                TempData["message"] = string.Format("{0} has been saved", product.Name);
                return RedirectToAction("Index");
            }
            else
            {
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

        [HttpGet]
        public ViewResult Create()
        {
            return View("Edit", new Product());
        }

    }
}