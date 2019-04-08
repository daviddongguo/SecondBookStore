using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using David.SecondBook.OnlineStore.Domain.Entities;
using David.SecondBook.OnlineStore.WebApi.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace David.SecondBook.OnlineStore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        //IProductsRepository _rep;
        private ProductsDbContext _context;

        public ProductsController(ProductsDbContext context)
        {
            _context = context;
        }

        [HttpGet("test")]
        public IActionResult Test()
        {
            return Ok("Tested Successfully.");
        }


        // GET api/sync
        [HttpGet]
        public IActionResult Get()
        {
            return new ObjectResult(_context.Prodocts.OrderByDescending(m => m.Id).Take(10).ToList());
        }

        [HttpGet("id")]
        public IActionResult GetById(int id)
        {
            return Ok(_context.Prodocts);
        }


        [HttpPost]
        public IActionResult Post([FromBody]Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Prodocts.Add(product);
                _context.SaveChanges();
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
            _context.Update(product);
        }

        [HttpDelete("id")]
        public void Delete(int id)
        {
            Product dbProduct = _context.Prodocts.FirstOrDefault( s => s.Id == id);
            _context.Remove(dbProduct);
        }

    }
}