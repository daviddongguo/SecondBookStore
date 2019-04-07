using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using David.SecondBook.OnlineStore.Domain.Abstract;
using David.SecondBook.OnlineStore.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace David.SecondBook.OnlineStore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IProductsRepository _rep = new MockProductsRepository();

        public IEnumerable<Product> Get()
        {
            return _rep.ProductsList;
        }
    }
}