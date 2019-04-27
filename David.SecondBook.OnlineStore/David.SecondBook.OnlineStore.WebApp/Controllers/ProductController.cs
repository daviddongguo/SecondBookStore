using David.SecondBook.OnlineStore.Domain.Abstract;
using David.SecondBook.OnlineStore.Domain.Entities;
using David.SecondBook.OnlineStore.WebApp.Models;
using System.Linq;
using System.Web.Mvc;

namespace David.SecondBook.OnlineStore.WebApp.Controllers
{
    public class ProductController : Controller
    {
        private IProductsRepository rep;

        public int PageSize = 3;

        public ProductController(IProductsRepository rep)
        {
            this.rep = rep;
        }

        //
        public ViewResult List(string category = null, int page = 1)
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
            return View(model);
        }

        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        public FileContentResult GetImage(int id)
        {
            Product prod = rep
            .ProductsList
            .FirstOrDefault(p => p.Id == id);
            if (prod != null)
            {
                return File(prod.ImageData, prod.ImageMimeType);
            }
            else
            {
                return null;
            }
        }

    }
}