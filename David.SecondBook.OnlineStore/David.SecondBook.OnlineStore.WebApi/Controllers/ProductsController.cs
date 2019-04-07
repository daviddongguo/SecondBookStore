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
        IProductsRepository _rep;

        public ProductsController(IProductsRepository rep)
        {
            _rep = rep;
        }
        [HttpGet("test")]
        public IActionResult Test()
        {
            return Ok("Tested Successfully.");
        }


        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_rep.ProductsList);
        }

        [HttpGet("id")]
        public IActionResult GetById(int id)
        {
            return Ok(_rep.FindById(id));
        }


        [HttpPost]
        public IActionResult Post([FromBody]Product product)
        {
            if (ModelState.IsValid)
            {
                _rep.Add(product);
                return StatusCode(StatusCodes.Status201Created);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut("id")]
        public void Put(int id, [FromBody]Product product)
        {
            _rep.Update(id, product);
        }

        [HttpDelete("id")]
        public void Delete(int id)
        {
            _rep.Delete(id);
        }

    }
}